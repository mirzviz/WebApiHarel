using JwtWebApiTutorial.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Services.CustomersService;

public interface ICustomerService
{
    List<Customer> Get();
    public void Put(int id, Customer customer);
}
