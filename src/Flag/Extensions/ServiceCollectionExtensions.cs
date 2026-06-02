using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flag.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection BuildFeatureFlagProvider(this IServiceCollection services)
	{

		//1. Get IConfiguration from ServiceProvider
		IServiceProvider serviceProvider = services.BuildServiceProvider();
		IConfiguration configuration = serviceProvider.GetRequiredService<IConfiguration>();
		IConfigurationSection configurationSection = configuration.GetSection("FeatureFlags");

		//2. Create a dictionary to hold flags
		Dictionary<string, FeatureFlag> featureFlags = new Dictionary<string, FeatureFlag>();

		bool isValid = false;

		foreach (IConfigurationSection child in configurationSection.GetChildren())
		{
			isValid = bool.TryParse(child.Value, out bool isEnabled);

			if (!isValid)
			{
				throw new ArgumentException("Configuration Section for 'FeatureFlags' is invalid.");
			}

			featureFlags.Add(child.Key, FeatureFlag.Create(child.Key, isEnabled));
		}

		//create FeatureFlagProvider class



		return services;
	}
}