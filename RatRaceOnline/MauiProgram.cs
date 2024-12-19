using Microsoft.Extensions.Logging;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;



namespace RatRace3
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .ConfigureSyncfusionCore()
                
                .UseMauiApp<App>()
          
         
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OPTIEngraversOldEnglish.otf", "EngraversOldEnglish");
                    fonts.AddFont("Harmoni.otf", "TANharmoni");
                    fonts.AddFont("CentaurMTStd-Italic.ttf", "CentaurMTStd-Italic");
                    fonts.AddFont("CentaurMTStd-BoldItalic.ttf", "CentaurMTStd-BoldItalic");
                });
           

         
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
