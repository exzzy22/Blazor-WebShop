namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class ValueAdditionText : Attribute
{
	public string Text { get; set; }

	public ValueAdditionText(string text)
	{
		Text = text;
	}
}
