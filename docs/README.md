# Flag

A "feature" rich library for using feature flags.

## Features

### Integration with the Microsoft.Extensions.IConfiguration Interface

```cs
configuration.BuildFeatureFlagProvider();
```

The default source for feature flags will be under configuration key `FeatureFlags`. However, if necessary this can be overridden like in the example below.

```cs
configuration.BuildFeatureFlagProvider("Flags");
```

### An Injectable Feature Flag Repository

```cs
private readonly IFeatureFlagProvider _featureFlagProvider;

class MyService(IFeatureFlagProvider featureFlagProvider)
{
	_featureFlagProvider = featureFlagProvider;
}


public DoSomethingOnlyWhenEnabled()
{
	if(_featureFlagProvider.IsFeatureEnabled("feature"))
	{
		// do something
	}
}
```
