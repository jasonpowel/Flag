using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flag.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection BuildFeatureFlagProvider(
		this IServiceCollection services,
		string? configurationSectionKey = null)
	{

		//1. Get IConfiguration from ServiceProvider
		IServiceProvider serviceProvider = services.BuildServiceProvider();
		IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();

		configurationSectionKey ??= Constants.Constants.ConfigurationSectionKeys.FeatureFlags;
		IConfigurationSection configurationSection = configuration.GetSection(configurationSectionKey);

		//2. Create a dictionary to hold flags
		Dictionary<string, FeatureFlag> featureFlags = new();

		foreach (IConfigurationSection child in configurationSection.GetChildren())
		{
			bool isValid = bool.TryParse(child.Value, out bool isEnabled);

			if (!isValid)
			{
				throw new ArgumentException("Configuration Section for 'FeatureFlags' is invalid.");
			}

			featureFlags.Add(child.Key, FeatureFlag.Create(child.Key, isEnabled));
		}

		//Create feature flag provider and add to ServiceCollection
		FeatureFlagProvider featureFlagProvider = new FeatureFlagProvider(featureFlags);
		services.AddSingleton<IFeatureFlagProvider>(featureFlagProvider);
		return services;
	}
}