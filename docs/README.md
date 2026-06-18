# Flag

A "feature" rich library for using feature flags.

## Features

### Extensive Integration with the Microsoft.Extensions.IConfiguration Interface

```cs
configuration.BuildFeatureFlagProvider();
```

The default source for feature flags will be under configuration key `FeatureFlags`. However, if necessary this can be overridden like in the example below.

```cs
configuration.BuildFeatureFlagProvider("Flags");
```

You can also specify triggers for changes to feature flags

```cs
configuration.BuildFeatureFlagProvider(
	x => x.WithTriggers(
		triggers => triggers.For("DoNotWorkOnWeekends")
					.When(DateTime.UtcNow.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
					.RefreshRate(TimeSpan.Minutes(1))
					.Enable()
	));
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
