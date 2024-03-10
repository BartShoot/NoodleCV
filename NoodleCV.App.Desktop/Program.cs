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
            options.Dsn = "https://8b9b20062c053202ff1c972f8cd19108@o146603.ingest.us.sentry.io/4506836668973056";
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