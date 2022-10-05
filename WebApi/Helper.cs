using JwtWebApiTutorial.Models;
using Newtonsoft.Json;

namespace JwtWebApiTutorial;

static class Helper
{
    public static List<Customer> getCustomersFromDB(string customersFilePath)
    {
        List<Customer> customers = new();

        if(File.Exists(customersFilePath))
            using (StreamReader r = new(customersFilePath))
            {
                string json = r.ReadToEnd();
                customers = JsonConvert.DeserializeObject<List<Customer>>(json);
            }

        return customers;
    }

    public static List<User> getUsersFromDB(string usersFilePath)
    {
        List<User> users = new();

        if (File.Exists(usersFilePath))
            using (StreamReader r = new(usersFilePath))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }

        return users;
    }
}
