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
    int maxid = userlist.Users.Max(x => x.id);

    newusr.id = ++maxid;

    userlist.Users.Add(newusr);
    string jsonstring = JsonSerializer.Serialize(userlist); 
    File.WriteAllText(jsonpath, jsonstring);
    Console.WriteLine("Data Added Succesfully");
}

static void Main()
{
    Console.WriteLine(Get());
    Console.ReadKey();
    User user = new User()
    {
        username = "yusuf cihan yılmaz",
        email = "yusuf@gmail.com",
        password = "11111117"

    };
    Write(user);
    Console.ReadKey();
    Console.WriteLine(Get());
    Console.ReadKey();
    User user2 = new User()
    {
        username = "arda inanç",
        email = "arda@gmail.com",
        password = "12345678"
    };
    Write(user2);
    Console.ReadKey();
    Console.WriteLine(Get());
    Console.ReadKey();
}

Main();