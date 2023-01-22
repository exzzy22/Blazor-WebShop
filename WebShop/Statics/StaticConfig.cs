using Domain.Models;

namespace WebShop.Statics;

public static class StaticConfig
{
	private static CurrencyVM _currency;

	public static CurrencyVM Currency
	{
		get
		{
			return _currency;
		}

		set
		{
			if (value != _currency)
			{
				_currency = value;
				NotifyPropertyChanged();
			}
		}
	}
	public static event PropertyChangedEventHandler? PropertyChanged;

	private static void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
	{
		PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
	}
}
