using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Flag;

public sealed class FeatureFlagProvider : IReadOnlyDictionary<string, FeatureFlag>, IFeatureFlagProvider
{
	private readonly IDictionary<string, FeatureFlag> _dictionary;

	public FeatureFlagProvider(IDictionary<string, FeatureFlag> dictionary)
	{
		_dictionary = dictionary;
	}

	public FeatureFlag this[string key] => _dictionary[key];

	public IEnumerable<string> Keys => _dictionary.Keys;

	public IEnumerable<FeatureFlag> Values => _dictionary.Values;

	public int Count => _dictionary.Count;

	public bool ContainsKey(string key)
	{
		return _dictionary.ContainsKey(key);
	}

	public IEnumerator<KeyValuePair<string, FeatureFlag>> GetEnumerator()
	{
		return _dictionary.GetEnumerator();
	}

	public bool TryGetValue(string key, [MaybeNullWhen(false)] out FeatureFlag value)
	{
		return _dictionary.TryGetValue(key, out value);
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return _dictionary.GetEnumerator();
	}

	public bool IsFeatureEnabled(string featureName)
	{
		if (string.IsNullOrWhiteSpace(featureName))
		{
			return false;
		}

		if (TryGetValue(featureName, out FeatureFlag flag))
		{
			return flag.IsEnabled;
		}
		else
		{
			return false;
		}
	}
}