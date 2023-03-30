
using TestCobbleStone.Data;
using TestCobbleStone.Services;

// path to the CSV File **
string pokemonFilePath = "C:\\Users\\serge\\Documents\\pokemon.csv";

// data from CSV File **
var pokemons = CsvFileReader.GetPokemons(pokemonFilePath);

// add dependancy **
var pokemonService = new PokemonServices(pokemons);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//added dependancy **
builder.Services.AddSingleton(pokemonService);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
