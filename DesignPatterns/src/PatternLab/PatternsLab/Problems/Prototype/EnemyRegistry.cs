using System.Collections.Generic;

namespace PatternsLab.Problems.Prototype;

public class EnemyRegistry
{
    private readonly Dictionary<string, Enemy> _prototypes = new();

    public void Register(string key, Enemy prototype)
    {
        _prototypes[key] = prototype;
    }
    public Enemy CreateEnemy(string key)
    {
        if (_prototypes.TryGetValue(key, out var prototype))
        {
            return prototype.clone();
        }
        throw new KeyNotFoundException($"Enemy prototype with key '{key}' not found.");
    }
}