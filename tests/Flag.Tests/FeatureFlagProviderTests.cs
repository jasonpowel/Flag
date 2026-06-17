using FluentAssertions;

namespace Flag.Tests;

public class FeatureFlagProviderTests
{
    private const string EnabledFeatureName = "feature1";
    private const string DisabledFeatureName = "feature2";
    private readonly Dictionary<string, FeatureFlag> _featureFlags;
    private FeatureFlagProvider _sut;

    public FeatureFlagProviderTests()
    {
        _featureFlags = new()
        {
            [EnabledFeatureName] = FeatureFlag.Create(EnabledFeatureName, true),
            [DisabledFeatureName] = FeatureFlag.Create(DisabledFeatureName, false)
        };

        _sut = new FeatureFlagProvider(_featureFlags);
    }

    [Fact]
    public async Task IsFeatureEnabled_Should_Return_True_When_FeatureIsEnabled()
    {
        //Act
        bool isFeatureEnabled = _sut.IsFeatureEnabled(EnabledFeatureName);

        //Assert
        isFeatureEnabled.Should().BeTrue();
    }

    [Fact]
    public async Task IsFeatureEnabled_Should_Return_False_When_FeatureIsEnabled()
    {
        //Act
        bool isFeatureEnabled = _sut.IsFeatureEnabled(DisabledFeatureName);

        //Assert
        isFeatureEnabled.Should().BeFalse();
    }
}
