namespace Flag;

public interface IFeatureFlagProvider
{
	public bool IsFeatureEnabled(string featureName);
}