namespace PatternsLab.Problems.Prototype;

public class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
};

public abstract class Enemy
{
    private string _modelData;

    public string Name { get; set; }
    public int Health { get; set; }
    public Weapon Weapon { get; set; }
    public List<string> Abilities { get; set; } = new();

    public string ModelId
    {
        get => _modelData; 
    }

    protected Enemy()
    {
        Console.WriteLine("   ...loading 3D model (slow)...");
        Thread.Sleep(500);
        _modelData = "MODEL_" + Guid.NewGuid().ToString("N")[..6];
    }

    protected Enemy(Enemy source)
    {
         this._modelData =  source._modelData; 
         this.Name = source.Name ;
         this.Health = source.Health;
         this.Weapon = source.Weapon; 
         this.Abilities = new List<string>(source.Abilities); 
    }
    
    public abstract Enemy clone(); 
}

public class Orc : Enemy
{
  
    public Orc() : base()
    {
        Name = "orc";
        Health = 100; 
        Weapon = new Weapon { Name = "Axe", Damage = 25 };
        Abilities.Add("Rage");
    }

    public Orc(Orc source) : base(source)
    {
      
    }
    public override Enemy clone()
    {
        Orc cloned = new Orc(this);
        return cloned; 
    }
}

public class Elf : Enemy
{
   

    public Elf()
    {
        Name = "elf";
        Health = 70; 
        Weapon = new Weapon { Name = "Bow", Damage = 18 };
        Abilities.Add("Stealth");
    }

    public Elf(Elf sourde) : base(sourde)
    {
        
    }
    public override Enemy clone()
    {
        Elf cloned = new Elf(this);
        return cloned; 
    }
    
}
public static class EnemyCopyHelper
{
    public static Enemy CopyEnemy(Enemy prototype)
    {
        return prototype.clone();
    }
}
