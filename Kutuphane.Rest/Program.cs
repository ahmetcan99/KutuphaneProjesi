global using Kutuphane.Rest.Data;
global using Microsoft.EntityFrameworkCore;
using Kutuphane.Rest.Models;
using Kutuphane.Rest.RepositoryPatern;
using Kutuphane.Rest.RepositoryPatern.Interfaces;

var builder = WebApplication.CreateBuilder(args);

//auto mapper implemente
object value = builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IRepositoryKitap, RepositoryKitap>();
builder.Services.AddScoped<IRepositoryDurum, RepositoryDurum>();
builder.Services.AddScoped<IRepositoryYayinEvi, RepositoryYayinEvi>();
builder.Services.AddScoped<IRepositoryUye, RepositoryUye>();
builder.Services.AddScoped<IRepositoryKitapHareket, RepositoryKitapHareketi>();

builder.Services.AddControllers();
//dbcontext bağlantısı 
builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connections")));

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

app.UseAuthorization();

app.MapControllers();


app.Run();
