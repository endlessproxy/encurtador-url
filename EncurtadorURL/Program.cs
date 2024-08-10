var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();







app.MapPost("/url", async (string url, string name) =>
{
    var _client = new HttpClient();
    
    var response = await _client.GetAsync($"https://ulvis.net/api.php?url={url}&custom={name}&private=1");
    var responseBody = await response.Content.ReadAsStringAsync();

    if (response.IsSuccessStatusCode)
    {
        return Results.Ok(responseBody);
    }
    
    return Results.BadRequest("Algo deu errado :(");
});







app.Run();