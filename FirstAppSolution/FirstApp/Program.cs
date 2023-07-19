using FirstApp.Models;

Console.WriteLine("Starting Up The Api");
var builder = WebApplication.CreateBuilder(args);
// configuration for the API goes here



Console.WriteLine("About to Start the Api");
var app = builder.Build();

// GET /sayhi
app.MapGet("/sayhi", () => Results.Ok("Yep! Hello, Good To See You!"));

app.MapGet("/status", () =>
{
    var response = new StatusResponseModel(DateTime.Now, "Looks Good", "Operating Normally");
    return Results.Ok(response);
});

app.Run(); // Blocking call - this will start server adn run FOREVER (or until we kill it)
Console.WriteLine("Api is down.");