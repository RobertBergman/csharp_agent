using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Agent.Configuration;
using Agent.Agents;

namespace Agent
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                var host = CreateHostBuilder().Build();
                
                using var scope = host.Services.CreateScope();
                var agentOrchestrator = scope.ServiceProvider.GetRequiredService<IAgentOrchestrator>();
                
                Application.Run(new Form1(agentOrchestrator));
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("OpenAI API key"))
            {
                MessageBox.Show($"Configuration Error: {ex.Message}\n\nPlease ensure appsettings.json is present with a valid OpenAI API key.", 
                    "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application Error: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}", 
                    "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.SetBasePath(AppContext.BaseDirectory);
                    config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    
                    // Also try to load from the working directory
                    if (File.Exists(Path.Combine(Environment.CurrentDirectory, "appsettings.json")))
                    {
                        config.AddJsonFile(Path.Combine(Environment.CurrentDirectory, "appsettings.json"), optional: true, reloadOnChange: true);
                    }
                })
                .ConfigureServices((context, services) =>
                {
                    services.ConfigureServices(context.Configuration);
                });
        }
    }
}