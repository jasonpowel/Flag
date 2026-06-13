# Flag

A "feature" rich library for using feature flags.

## Features

### Extensive Integration with the Microsoft.Extensions.IConfiguration Interface

```cs
configuration.BuildFeatureFlagProvider();
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
