using System.Net.Http.Headers;
using VYP.Models;
using System.Text.Json;

static string Get()
{
    string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "Data\\jsconfig1.json";
    string content = File.ReadAllText(jsonpath);

    return content;
}

static void Write(User newusr)
{
    string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "Data\\jsconfig1.json";
    string content = File.ReadAllText(jsonpath);

    UserList userlist = JsonSerializer.Deserialize<UserList>(content);
    Console.WriteLine(userlist.Users.Count);
    int maxid = userlist.Users.Max(x => x.id);

    newusr.id = ++maxid;

    userlist.Users.Add(newusr);
    string jsonstring = JsonSerializer.Serialize(userlist); 
    File.WriteAllText(jsonpath, jsonstring);
    Console.WriteLine("Data Added Succesfully");
}

static string EmailControl()
{
    string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "Data\\jsconfig1.json";
    string content = File.ReadAllText(jsonpath);
    UserList userlist = JsonSerializer.Deserialize<UserList>(content);
    while (true)
    {
        Console.WriteLine("Enter email:");
        string email = Console.ReadLine();
        bool isexist = false;

        for (int i = 1; i < userlist.Users.Count; i++)
        {
            if (userlist.Users[i].email == email)
            {
                Console.WriteLine("This email already exists. Please try again.");
                isexist = true; 
                break;
            }
        }
        if (isexist)
        {
            continue;
        }
        return email;
    }
}

static void Main()
{
    string jsonpath = AppDomain.CurrentDomain.BaseDirectory + "Data\\jsconfig1.json";
    string content = File.ReadAllText(jsonpath);
    UserList userlist = JsonSerializer.Deserialize<UserList>(content);

    Get();

    Console.WriteLine("Enter username:");
    string username = Console.ReadLine();
    string email = EmailControl();
    Console.WriteLine("Enter password:");
    string password = Console.ReadLine();
        User newusr = new User()
        {
            username = username,
            email = email,
            password = password
        };
    Write(newusr);
    Console.WriteLine();

}

Main();