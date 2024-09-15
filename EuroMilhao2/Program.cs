using EuroMilhao2.Context;
using EuroMilhao2.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using EuroMilhao2.Repositories;
using EuroMilhao2.Models;

var builder = WebApplication.CreateBuilder(args);



// criando com tempo de vida scoped - a cada request um nova instancia criada
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<IKeysGeradasRepository, KeysGeradasRepository>();//criando tipos de serviços
builder.Services.AddSingleton<ListDeKeysGeradas>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/KeysGeradas/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=KeysGeradas}/{action=Criar}/{id?}");



app.Run();
