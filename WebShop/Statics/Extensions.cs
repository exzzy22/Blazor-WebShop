using System.Globalization;

namespace WebShop.Statics;

public static class Extensions
{
	public static string ToPriceString(this double price) => string.Format(CultureInfo.CurrentCulture, "{0:0.00}", price);
	public static string ToPriceString(this float price) => string.Format(CultureInfo.CurrentCulture, "{0:0.00}", price);

}
