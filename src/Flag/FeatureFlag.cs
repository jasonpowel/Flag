namespace Flag;

public readonly record struct FeatureFlag
{
	private FeatureFlag(string name, bool isEnabled)
	{
		Name = name;
		IsEnabled = isEnabled;
	}

	public string Name { get; }
	public bool IsEnabled { get; }


	public static FeatureFlag Create(string name, bool isEnabled)
	{
		return new FeatureFlag(name, isEnabled);
	}
};