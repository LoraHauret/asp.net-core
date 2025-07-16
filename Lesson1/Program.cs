
//практическая работа в классе
// Создать собственный терминальный компонент, используя метод Run. Определить класс Person, содержащий 5 свойств. Создать коллекцию объектов класса. Вернуть коллекцию объектов в виде таблицы.
/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<Person> persons = new List<Person>();
Random rnd = new Random();
int count = rnd.Next(20) + 1;

for(int i = 0; i < count; i++)
{
    Person person = new Person ($"Name{i + 1}", $"LstName{i + 1}",$"Address#{i + 1}",$"{i+1}person@gmail.com", rnd.Next(100000000) );
    persons.Add(person);
}
var html = "<table border='1'>" +
    "<tr>" +
    "<th>First Name</th>" +
    "<th>Last Name</th>" +
    "<th>Address</th>" +
    "<th>Email</th>" +
    "<th>Phone Number</th>" +
    "</tr>";

foreach (var p in persons)
{
    html += $"<tr><td>{p.FirstName}</td><td>{p.LastName}</td><td>{p.Address}</td><td>{p.Email}</td><td>{p.PhoneNumber}</td></tr>";
}

html += "</table>";

app.Run(async context =>
{
    context.Response.ContentType = "text/html";
    await context.Response.WriteAsync(html);
});


app.MapGet("/", () => "Hello World!");

app.Run();

class Person
{  
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address {  get; set; }
    public string Email{ get; set; }
    public int PhoneNumber{ get; set; }
    public Person() { }
    public Person(string firstName, string lastName, string address, string email, int phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
*/

/*1. Определить сайт для создания приглашений пользователей. На главной странице сайта выводим приветствие в виде отдельно HTML страницы с использованием стилей. На этой странице добавляем ссылку на форму приглашения. На форме приглашения, пользователь вводит имя, email и номер телефона. После отправки приглашения, данные добавляем в коллекцию класса и проводим переадресацию на страницу с благодарностью за регистрацию.*/

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var invitees = new List<Invitee>();
app.UseStaticFiles(); // подтягивает файлы из локальных ресурсов 

app.MapGet("/", async context =>
{
    var html = """
        <html>
        <head><title>Приветствие</title></head>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        <body>
            <h1">Добро пожаловать!</h1>
            <a href="/invite">Перейти к форме</a> 
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.MapGet("/invite", async context =>
{
    var html = """
        <html>
        <head>
        <title>Форма</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Введите данные</h2>
            <form method="post" action="/submit">
                <div>Имя: <input name="name" /><div/>
                 <div>Email: <input name="email" /><br/> <div>
                 <div>Телефон: <input name="phone" /><br/> <div>
                <button type="submit">Отправить</button>
            </form>
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.MapPost("/submit", async context =>
{
    var form = await context.Request.ReadFormAsync();
    var invitee = new Invitee
    {
        Name = form["name"],
        Email = form["email"],
        Phone = form["phone"]
    };
    invitees.Add(invitee);

    context.Response.Redirect("/thankyou"); // перенаправление
});

app.MapGet("/thankyou", async context =>
{
    var html = """
        <html>
        <head>
        <title>Спасибо</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Спасибо за регистрацию!</h2>
            <a href="/">Вернуться на главную</a>
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});
app.Run();

record Invitee
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

*/




/*
 2.Реализовать обработку POST запроса с возвращением ответа. Когда вы запустите приложение и сделаете POST-запрос к URL "/api/greeting" с телом запроса, содержащим строку (например, {"name": "John"}), вы должны получить ответ с персонализированным приветствием (например, "Hello, John!").
 */
/*
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();

app.MapGet("/", () => "Сервер запущен. Ожидается отправка POST-запроса на /api/greeting");

// отсылка с клиента через Postman в виде Json файла.
// {
// "name": "John"
// }

app.MapPost("/api/greeting", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync(); // читаю, что пришло

    var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body); // раскладываю на name и его значение
    string name = data?["name"] ?? "stranger";

    var html = $"""
        <html>
        <head>
        <title>Приветствие</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Hello, {name}!</h2>
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.Run();*/

//// вариант с взятием имени с формы. 

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();

app.MapGet("/", async context =>
{
    var html = """
        <html>
        <head>
        <meta charset="utf-8">
        <title>Форма</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Введите данные</h2>
            <form method="post" action="/submit">
                <div>Имя: <input name="name" /><div/>
                <button type="submit">Отправить</button>
            </form>
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.MapPost("/submit", async context =>
{
    var form = await context.Request.ReadFormAsync();

    var name = form["name"].ToString();

    var html = $"""
        <html>
        <head>
            <meta charset="utf-8">
            <title>Спасибо</title>
            <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Привет, {name}!</h2>
        </body>
        </html>
        """;

    context.Response.ContentType = "text/html; charset-utf-8";
    await context.Response.WriteAsync(html);
});

app.Run();

*/


/*
3. Используя JavaScript или любой другой Фреймворк или PostMan, отправьте JSON объект на любое действие в C#. После получение, отобразите это значение на новой странице.
 */

/*
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();


app.MapGet("/", async context =>
{
    var html = """
        <html>
        <head>
            <title>JSON</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
            <script>
                async function sendData() {
                    const name = document.getElementById("name").value;

                    const response = await fetch("/api/show", {
                        method: "POST",
                        headers: {
                            "Content-Type": "application/json"
                        },
                        body: JSON.stringify({ name: name })
                    });

                    const html = await response.text();
                    document.open();
                    document.write(html);
                    document.close();
                }
            </script>
        </head>
        <body>
            <h2>Введите имя:</h2>
            <input type="text" id="name" />
            <button onclick="sendData()">Отправить</button>
        </body>
        </html>
        """;

    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.MapPost("/api/show", async context =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync();

    var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body);
    var name = data?["name"] ?? "гость";

    var html = $"""
        <html>
        <head>
            <title>Приветствие</title>
            <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>Привет, {name}!</h2>
        </body>
        </html>
        """;

    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});


app.Run();

*/

/*
 1.	Реализуйте конечную точку API, которая принимает строковый параметр и возвращает длину строки. Запрос к точке выглядит следующим образом:

https://localhost:XXXX/api/length/Hello-World

Или так:

https://localhost:XXXX/api?Hello-World


*/

using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context => {
    var html = """
        <html>
        <head>
        <title>Приветствие</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>сервер запущен</h2>
        </body>
        </html>
        """;
    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});

app.MapGet("/api/length", (string text) =>
{
    return Results.Ok(new { length = text.Length });
});

app.Run();

// Postman
/* http://localhost:5206/api/length?text=hello, everyone  
 */