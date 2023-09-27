using ServiceBusManager.Data.Services;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            AddTransient(builder.Services);
            AddScoped(builder.Services);
            AddSingleton(builder.Services);

            builder.Services.AddSignalR(e =>
            {
                e.MaximumReceiveMessageSize = 102400000; // TODO - REFACTOR INTO HUB - https://stackoverflow.com/questions/60311852/error-connection-disconnected-with-error-error-server-returned-an-error-on-cl
            });

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

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

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
        }
        private static void AddSingleton(IServiceCollection services)
        {
            services.AddSingleton<IConnectionManager, ConnectionManager>();
            services.AddSingleton<IHotkeyManager, HotkeyManager>();
        }
    }
}