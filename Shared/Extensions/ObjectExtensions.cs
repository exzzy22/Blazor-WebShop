using System.Reflection;
using System.Text;

namespace Shared.Extensions;

public static class ObjectExtensions
{
	public static string ToQueryString(this object obj)
	{ 
		Dictionary<string, object> dict = ObjectToDictionary(obj);
		if (dict.Keys.Count == 0)
			return "";
		else
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("?");
			foreach (var kvp in dict)
			{
				sb.AppendFormat("{0}={1}&", kvp.Key, kvp.Value);
			}
			return sb.ToString().TrimEnd('&');
		}
	}

	static Dictionary<string, object> ObjectToDictionary(object obj)
	{
		Dictionary<string, object> dict = new ();

		if (obj == null)
			return dict;

		PropertyInfo[] properties = obj.GetType().GetProperties();

		foreach (PropertyInfo property in properties)
		{
			object value = property.GetValue(obj);
			if (value != null)
			{
				if (property.PropertyType.IsClass && property.PropertyType != typeof(string))
				{
					dict.Merge(ObjectToDictionary(value), property.Name + ".");
				}
				else
				{
					dict.Add(property.Name, value);
				}
			}
		}
		return dict;
	}

	static void Merge(this Dictionary<string, object> dict, Dictionary<string, object> dict2, string prefix)
	{
		foreach (var kvp in dict2)
		{
			dict.Add(prefix + kvp.Key, kvp.Value);
		}
	}
}
