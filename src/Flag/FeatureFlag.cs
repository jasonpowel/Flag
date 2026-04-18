namespace Flag;

public record struct FeatureFlag(string Name, bool IsEnabled)
{
	public static FeatureFlag Create(string name, bool isEnabled)
	{
		return new FeatureFlag(name, isEnabled);
	}
};