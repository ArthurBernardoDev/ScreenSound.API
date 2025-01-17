using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using ScreenSound.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();
builder.Services.AddTransient<DAL<Musica>>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.addEndpontsArtistas();
app.AddEndpointMusicas();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
