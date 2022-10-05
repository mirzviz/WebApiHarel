using JwtWebApiTutorial;
using JwtWebApiTutorial.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace WebApi.Services.CustomersService;

public class CustomerService : ICustomerService
{
    private readonly IMemoryCache _memoryCache;
    private string customersFilePath = Path.Combine(Directory.GetCurrentDirectory(), "DBs", "customers.json");

    public CustomerService(IMemoryCache memoryCache)
    {
        this._memoryCache = memoryCache;
    }

    public List<Customer> Get()
    {
        return _memoryCache.GetOrCreate("Customers", entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1);
            return Helper.getCustomersFromDB(customersFilePath);
        });
    }

    public void Put(int id, Customer customer)
    {
        _memoryCache.Remove("Customers");
        List<Customer> customers = Helper.getCustomersFromDB(customersFilePath);
        int index = customers.FindIndex(x => x.ID == id);
        if (index != -1)
            customers[index] = customer;

        string jsonCustomers = JsonConvert.SerializeObject(customers);
        using (var r = new StreamWriter(customersFilePath, false))
        {
            r.Write(jsonCustomers);
        }
    }
}
