using ServiceBusManager.Web.Services.Interfaces;
using ServiceBusManager.Web.Services;
using ServiceBusManager.Web.Components;

namespace ServiceBusManager.Web;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddRazorComponents()
            .AddInteractiveServerComponents();

        AddTransient(builder.Services);
        AddScoped(builder.Services);
        AddSingleton(builder.Services);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseAntiforgery();

        app.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode();

        app.Run();
    }
    private static void AddTransient(IServiceCollection services)
    {

    }
    private static void AddScoped(IServiceCollection services)
    {
        services.AddScoped<IJSLogger, JSLogger>();
        services.AddScoped<IScreenInformationService, ScreenInformationService>();
        services.AddScoped<IServiceBusClientAdminManager, ServiceBusClientAdminManager>();
        services.AddScoped<ILocalStorageManager, LocalStorageManager>();
        services.AddScoped<IConnectionManager, ConnectionManager>();
        services.AddScoped<IHotkeyManager, HotkeyManager>();
    }
    private static void AddSingleton(IServiceCollection services)
    {

    }
}
