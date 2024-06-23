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
				fonts.AddFont("VintageRemington-3zdp6.ttf", "VintageRemington");
				fonts.AddFont("PumpkinPieLattesBold-WyGGz.ttf", "PumpkinPie");
				fonts.AddFont("RosmatikaRegular-BWA45.ttf", "Rosma");
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansR");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansB");
				fonts.AddFont("DuckAndTiger-ax905.ttf", "Duck");
				fonts.AddFont("Crashnumberingserif-KVjW.ttf","Num");
			});



		builder.Services.AddSingleton<IMenuService, MenuService>();
        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingleton<IBasketService, BasketService>();
        builder.Services.AddSingleton<IOrderService, OrderService>();
        builder.Services.AddSingleton<Menu>();


        builder.Services.AddTransient<ColdDrinksViewModel>();
        builder.Services.AddTransient<HotFoodViewModel>();
        builder.Services.AddTransient<BakeryViewModel>();
        builder.Services.AddTransient<HotDrinksViewModel>();
        builder.Services.AddTransient<BasketViewModel>();
        builder.Services.AddTransient<CheckoutViewModel>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<OrderConfViewModel>();
        builder.Services.AddTransient<OrderHistoryViewModel>();
        builder.Services.AddTransient<ProfileViewModel>();
        builder.Services.AddTransient<TestViewModel>();
        builder.Services.AddTransient<MenuItemViewModel>();


        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<ColdDrinksPage>();
        builder.Services.AddTransient<HotFoodPage>();
        builder.Services.AddTransient<BakeryPage>();
        builder.Services.AddTransient<HotDrinksPage>();
        builder.Services.AddSingleton<CheckoutPage>();
        builder.Services.AddSingleton<OrderConfPage>();
        builder.Services.AddTransient<OrderHistoryPage>();
        builder.Services.AddTransient<ProfilePage>();
        builder.Services.AddTransient<TestPage>();
        builder.Services.AddTransient<AboutPage>();
        builder.Services.AddTransient<ContactPage>();
        builder.Services.AddTransient<BasketPage>();
        

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

