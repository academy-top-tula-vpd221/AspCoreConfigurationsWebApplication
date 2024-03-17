var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddInMemoryCollection(new Dictionary<string, string>
{
    {"name", "tom" },
    {"age", "32" },
});
builder.Configuration.AddJsonFile("config.json");
builder.Configuration.AddXmlFile("config.xml");
builder.Configuration.AddIniFile("config.ini");


var app = builder.Build();



//app.Configuration["name"] = "bob";
//app.Configuration["age"] = "25";

//app.MapGet("/", () => "Hello World!");
//app.Run(async (context) =>
//{
//    string name = app.Configuration["name"];
//    string age = app.Configuration["age"];
//    await context.Response.WriteAsync($"{name}, {age}");
//});

app.Map("/", () => "Index page");
app.Map("/config", (IConfiguration config) => {
    string name = config["employee:info:name"];
    string age = config["employee:info:age"];
    string position = config["employee:position"];
    string company = config["company"];

    string user = config["user"];
    string login = config["login"];

    return $"{config["city"]} {config["country"]}\n{config["name"]}\nEmploye: {name}, {age}, {position}\nCompany: {company}\nUser: {user} {login}";
});

app.Run();
