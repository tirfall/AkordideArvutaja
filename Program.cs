var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run();

public partial class Program { }