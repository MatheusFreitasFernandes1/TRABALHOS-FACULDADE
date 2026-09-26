using Agendamento.Data;
using Agendamento.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(
        "User Id=PIM;Password=matheusfre123;Data Source=localhost:1521/xepdb1"
    ));

builder.Services.AddScoped<PacienteService>();
builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Paciente}/{action=Index}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Paciente}/{action=Index}/{id?}");

app.Run();
