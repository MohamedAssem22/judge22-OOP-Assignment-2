using PatternsLab.Problems.Builder;
using PatternsLab.Problems.Prototype;
using PatternsLab.Problems.Singleton;
using System.Text.RegularExpressions;
namespace PatternLab;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n=== PROTOTYPE: BEFORE ===\n");
         
        var registry = new EnemyRegistry();
        
        registry.Register("StandardOrc", new Orc());
        registry.Register("EliteElf", new Elf());
      
        Enemy Orc = registry.CreateEnemy("StandardOrc");
        Enemy Elf = registry.CreateEnemy("EliteElf");
        
        // var sw = Stopwatch.StartNew();
        var army = new List<Enemy>();
        for (int i = 1; i <= 5; i++)
        {
            var orc = new Orc();
            orc.Name = $"Orc-{i}";
            army.Add(orc);
        }
        // Console.WriteLine($"Created 5 orcs in {sw.ElapsedMilliseconds} ms\n");
      
        Enemy original = new Orc();
        original.Name = "Boss Orc";
        Enemy copy = EnemyCopyHelper.CopyEnemy(original);

        Console.WriteLine($"\nOriginal model id: {original.ModelId}");
        Console.WriteLine($"Copy model id:     {copy.ModelId}");

        copy.Weapon.Damage = 999;
        Console.WriteLine($"\nWe changed the COPY's weapon damage to 999.");
        Console.WriteLine($"Original's weapon damage is now: {original.Weapon.Damage}");
    }
}