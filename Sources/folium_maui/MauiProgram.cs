using Microsoft.Extensions.Logging;

namespace folium_maui;

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
                fonts.AddFont("Arvo-Bold.ttf", "Arvo-Bold");
                fonts.AddFont("Arvo-Italic.ttf", "Arvo-Italic");
                fonts.AddFont("Arvo-BoldItalic.ttf", "Arvo-BoldItalic");
                fonts.AddFont("Arvo-Regular.ttf", "Arvo-Regular");
				fonts.AddFont("SignikaNegative-Bold.ttf", "SignikaNegative-Bold");
                fonts.AddFont("SignikaNegative-Light.ttf", "SignikaNegative-Light");
                fonts.AddFont("SignikaNegative-Medium.ttf", "SignikaNegative-Medium");
                fonts.AddFont("SignikaNegative-Regular.ttf", "SignikaNegative-Regular");
                fonts.AddFont("SignikaNegative-SemiBold.ttf", "SignikaNegative-SemiBold");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
