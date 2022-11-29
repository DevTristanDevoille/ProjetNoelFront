using ProjetNoelWeb.WebApplication.Filters;
using ProjetNoelWeb.WebApplication.Services;
using ProjetNoelWeb.WebApplication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<DefaultActionFilter>();
})
    .AddRazorRuntimeCompilation(); // Add controler with views to app

builder.Services.AddScoped<IHttpService, HttpService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISquadService, SquadService>();
builder.Services.AddScoped<IListeService, ListeService>();
builder.Services.AddScoped<IIdeaService, IdeaService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "login",
        pattern: "",
        defaults: new { controller = "login", action = "index" });
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}
);

app.UseStaticFiles();

app.Run();
