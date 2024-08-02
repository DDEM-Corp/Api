using Api.Application.UseCases;
using Api.Infrastructure.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApiDbContext>();
builder.Services.AddScoped<CreateSeason>();

var app = builder.Build();

app.MapGet("/seasons", (ApiDbContext dbContext) =>
{
    var temporadas = dbContext.Seasons.ToList();
    return Results.Ok(temporadas);
});

app.MapPost("/seasons", async (CreateSeasonInput request, CreateSeason createSeason) =>
{
    var output = await createSeason.Execute(request);
    return Results.Created($"/seasons/{output.Season.Id}", output.Season);
});

app.Run();
