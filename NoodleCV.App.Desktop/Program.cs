﻿using System;
using Avalonia;
using Avalonia.Xaml.Interactivity;
using Sentry;

namespace NoodleCV.App.Desktop;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        SentrySdk.Init(options =>
        {
#if DEBUG
            options.Dsn = "";
#else
            options.Dsn = "https://8b9b20062c053202ff1c972f8cd19108@o146603.ingest.us.sentry.io/4506836668973056";
#endif
            options.AutoSessionTracking = true;
            options.IsGlobalModeEnabled = true;
            options.EnableTracing = true;
        });
        SentrySdk.CaptureMessage("Someone tried to launch application");

        GC.KeepAlive(typeof(Interaction).Assembly);
        GC.KeepAlive(typeof(ComparisonConditionType).Assembly);

        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}