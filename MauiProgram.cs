﻿using aburbanoS5A.Repositories;
using Microsoft.Extensions.Logging;

namespace aburbanoS5A
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            string dbPath = FileAccesHelper.GetLocalFolderPath("personas.db");
            builder.Services.AddSingleton<Repositories.PersonRepository> 
                (s => ActivatorUtilities.CreateInstance<Repositories.PersonRepository>(s,dbPath));

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
