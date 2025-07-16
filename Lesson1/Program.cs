
//������������ ������ � ������
// ������� ����������� ������������ ���������, ��������� ����� Run. ���������� ����� Person, ���������� 5 �������. ������� ��������� �������� ������. ������� ��������� �������� � ���� �������.
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

/*1. ���������� ���� ��� �������� ����������� �������������. �� ������� �������� ����� ������� ����������� � ���� �������� HTML �������� � �������������� ������. �� ���� �������� ��������� ������ �� ����� �����������. �� ����� �����������, ������������ ������ ���, email � ����� ��������. ����� �������� �����������, ������ ��������� � ��������� ������ � �������� ������������� �� �������� � �������������� �� �����������.*/

/*
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var invitees = new List<Invitee>();
app.UseStaticFiles(); // ����������� ����� �� ��������� �������� 

app.MapGet("/", async context =>
{
    var html = """
        <html>
        <head><title>�����������</title></head>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        <body>
            <h1">����� ����������!</h1>
            <a href="/invite">������� � �����</a> 
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
        <title>�����</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������� ������</h2>
            <form method="post" action="/submit">
                <div>���: <input name="name" /><div/>
                 <div>Email: <input name="email" /><br/> <div>
                 <div>�������: <input name="phone" /><br/> <div>
                <button type="submit">���������</button>
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

    context.Response.Redirect("/thankyou"); // ���������������
});

app.MapGet("/thankyou", async context =>
{
    var html = """
        <html>
        <head>
        <title>�������</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������� �� �����������!</h2>
            <a href="/">��������� �� �������</a>
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
 2.����������� ��������� POST ������� � ������������ ������. ����� �� ��������� ���������� � �������� POST-������ � URL "/api/greeting" � ����� �������, ���������� ������ (��������, {"name": "John"}), �� ������ �������� ����� � ������������������� ������������ (��������, "Hello, John!").
 */
/*
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseStaticFiles();

app.MapGet("/", () => "������ �������. ��������� �������� POST-������� �� /api/greeting");

// ������� � ������� ����� Postman � ���� Json �����.
// {
// "name": "John"
// }

app.MapPost("/api/greeting", async (HttpContext context) =>
{
    using var reader = new StreamReader(context.Request.Body);
    var body = await reader.ReadToEndAsync(); // �����, ��� ������

    var data = JsonSerializer.Deserialize<Dictionary<string, string>>(body); // ����������� �� name � ��� ��������
    string name = data?["name"] ?? "stranger";

    var html = $"""
        <html>
        <head>
        <title>�����������</title>
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

//// ������� � ������� ����� � �����. 

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
        <title>�����</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������� ������</h2>
            <form method="post" action="/submit">
                <div>���: <input name="name" /><div/>
                <button type="submit">���������</button>
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
            <title>�������</title>
            <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������, {name}!</h2>
        </body>
        </html>
        """;

    context.Response.ContentType = "text/html; charset-utf-8";
    await context.Response.WriteAsync(html);
});

app.Run();

*/


/*
3. ��������� JavaScript ��� ����� ������ ��������� ��� PostMan, ��������� JSON ������ �� ����� �������� � C#. ����� ���������, ���������� ��� �������� �� ����� ��������.
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
            <h2>������� ���:</h2>
            <input type="text" id="name" />
            <button onclick="sendData()">���������</button>
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
    var name = data?["name"] ?? "�����";

    var html = $"""
        <html>
        <head>
            <title>�����������</title>
            <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������, {name}!</h2>
        </body>
        </html>
        """;

    context.Response.ContentType = "text/html; charset=utf-8";
    await context.Response.WriteAsync(html);
});


app.Run();

*/

/*
 1.	���������� �������� ����� API, ������� ��������� ��������� �������� � ���������� ����� ������. ������ � ����� �������� ��������� �������:

https://localhost:XXXX/api/length/Hello-World

��� ���:

https://localhost:XXXX/api?Hello-World


*/

using System.Xml.Linq;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context => {
    var html = """
        <html>
        <head>
        <title>�����������</title>
        <link rel="stylesheet" href="/css/StyleSheet.css">
        </head>
        <body>
            <h2>������ �������</h2>
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
