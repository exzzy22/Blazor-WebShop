namespace ViewModels.ValidationAttributes;

[AttributeUsage(AttributeTargets.Property)]
public class NameForDisplay : Attribute
{
	public string Name { get; set; }

	public NameForDisplay(string name)
	{
		Name = name;
	}
}
