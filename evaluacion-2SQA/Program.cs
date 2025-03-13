using UserApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Registro de HttpClient para UserService
builder.Services.AddHttpClient<UserService>();

// Registrar UserService como Scoped
builder.Services.AddScoped<UserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

// El orden correcto de los middlewares:
app.UseRouting();  // Asegúrate de tener esta línea antes de UseEndpoints()

app.UseAuthorization();

app.MapStaticAssets();

// Asegúrate de tener UseEndpoints después de UseRouting
app.UseEndpoints(endpoints =>
{
    // Aquí cambiamos la ruta predeterminada para que apunte a HomeController
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
