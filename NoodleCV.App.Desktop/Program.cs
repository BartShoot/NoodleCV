using System;
using Avalonia;
using Sentry;

namespace NoodleCV.App.Desktop;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        SentrySdk.Init(options =>
        {
            if (Environment.GetEnvironmentVariable("SENTRY_DSN") == null)
            {
                options.Dsn = "";
            }

            options.AutoSessionTracking = true;
            options.IsGlobalModeEnabled = true;
            options.EnableTracing = true;
        });
        SentrySdk.CaptureMessage("Someone tried to launch application");

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}