using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.Configuration;

namespace Flag.Extensions;

public static class ConfigurationManagerExtensions
{
	public static IConfiguration BuildFeatureFlagProvider(this IConfiguration configuration)
	{
		//1. Get 'FeatureFlags' section
		IConfigurationSection configurationSection = configuration.GetSection("FeatureFlags");

		//2. Ensure section is in the right format
		Dictionary<string, FeatureFlag> featureFlags = new Dictionary<string, FeatureFlag>();

		bool isValid = false;

		foreach (IConfigurationSection child in configurationSection.GetChildren())
		{
			isValid = bool.TryParse(child.Value, out bool isEnabled);
			featureFlags.Add(child.Key, FeatureFlag.Create(child.Key, isEnabled));
		}

		if (!isValid)
		{
			throw new ArgumentException("Configuration Section for 'FeatureFlags' is invalid.");
		}

		return configuration;
	}
}