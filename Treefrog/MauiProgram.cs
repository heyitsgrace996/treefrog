using Microsoft.Extensions.Logging;
using Treefrog.Models;
using Treefrog.ViewModels;
using Treefrog.Services;
using Microsoft.Maui.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Treefrog.Views;

namespace Treefrog;

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



		builder.Services.AddSingleton<IMenuService, MenuService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();

        builder.Services.AddTransient<ColdDrinksViewModel>();
        builder.Services.AddTransient<HotFoodViewModel>();
        builder.Services.AddTransient<BakeryViewModel>();
        builder.Services.AddTransient<HotDrinksViewModel>();
        builder.Services.AddTransient<BasketViewModel>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddTransient<MainPageViewModel>();
        builder.Services.AddTransient<OrderConfViewModel>();
        builder.Services.AddTransient<OrderHistoryViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<RewardsViewModel>();
        builder.Services.AddTransient<TestViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ColdDrinksPage>();
        builder.Services.AddTransient<HotFoodPage>();
        builder.Services.AddTransient<BakeryPage>();
        builder.Services.AddTransient<HotDrinksPage>();
        builder.Services.AddTransient<BasketPage>();
        builder.Services.AddTransient<CheckoutPage>();
        builder.Services.AddTransient<OrderConfPage>();
        builder.Services.AddTransient<OrderHistoryPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<RewardsPage>();
        builder.Services.AddTransient<TestPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

