using AlfabetizaAPI;
using AlfabetizaAPI.Context;
using AlfabetizaAPI.Helpers;
using AlfabetizaAPI.Repository;
using AlfabetizaAPI.Repository.Interface;
using AlfabetizaAPI.Services.Interfaces;
using AlfabetizaAPI.Services.Token;
using AlfabetizaAPI.Services.Work;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


//Colocar esse bloco de codigo para funcionar a autenticacao por token
var key = Encoding.ASCII.GetBytes(Settings.Secret);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x => {
    x.RequireHttpsMetadata = false;
    x.SaveToken = false;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddDbContext<AlfabetizaContext>(options => {
    options.UseNpgsql("User ID=postgres;Password=190123;Host=localhost;Port=8077;Database=alfabetiza;");
});
builder.Services.AddScoped<ICalculate, Calculate>();
builder.Services.AddScoped<IBaseRepository, BaseRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICrypto, Crypto>();
builder.Services.AddScoped<ITokenServices, TokenServices>();

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AlfabetizaProfile());
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication(); //Coloca esse use antes do de baixo para poder funcionar o token
app.UseAuthorization();

app.MapControllers();
app.UseHttpsRedirection();

app.Run();
