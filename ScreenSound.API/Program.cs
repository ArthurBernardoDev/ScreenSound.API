using ScreenSound.Banco;
using ScreenSound.Modelos;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ScreenSoundContext>();
builder.Services.AddTransient<DAL<Artista>>();

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
var app = builder.Build();

app.MapGet("/Artistas", ([FromServices] DAL<Artista> dal) =>
{
    return Results.Ok(dal.Listar());
});

app.MapGet("/Artistas/{nome}", ([FromServices] DAL<Artista> dal, string nome) =>
{
    var artista =  dal.RecuperarPor(a => a.Nome.ToUpper().Equals(nome.ToUpper()));

    return artista is null ? Results.NotFound() : Results.Ok(artista);
});

app.MapPost("/Artistas", ([FromServices] DAL<Artista> dal, [FromBody] Artista artista) =>
{
    dal.Adicionar(artista);
    return Results.Ok();

});


app.Run();
