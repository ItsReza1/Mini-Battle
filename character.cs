using System;
using System.Diagnostics;

public class Character
{
    public string Name { get; set; }
    public int MaxHp { get; set; }
    public int CurrentHp { get; set; }
    public int AttackPower { get; set; }
    public int HealPower { get; set; }

    public bool RageActive { get; set; } = false;

    // Vi skapar konstrukor för att skapa karaktären
    public Character(string name, int maxHp, int attackPower, int healPower)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp; // 
        AttackPower = attackPower;
        HealPower = healPower;
    }

    // Nu ska vi skapa metod för att attackera
    public void Attack(Character target, Random rand)
{
    int damage = AttackPower;

    
    if (rand.Next(1, 101) <= 20)  
    {
        damage = (int)(damage * 1.25);
        Console.WriteLine($" Träff, {Name} gör extra skada! ");
    }

    target.TakeDamage(damage);
    Console.WriteLine($"{Name} attackerar {target.Name} för {damage} skada.");
}


    // Metod för att ta skada
    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;
        if(CurrentHp < 0)
        {
            CurrentHp = 0;
        }
    }
    
    
    // Metod för att hela
    public void Heal()
    {
        CurrentHp += HealPower;
        if(CurrentHp > MaxHp) //Vi kollar så det inte går över max HP
        {
            Console.WriteLine($"{Name} healar sig och får sitt {HealPower}");
            
        }
    }
    
    public void checkRage()
    {
        if(!RageActive && CurrentHp <(MaxHp / 2))
        {
            RageActive = true;
            AttackPower =(int)(AttackPower * 1.5);
            Console.WriteLine($"Rage mode är aktiverad för {Name} Attackraften ökar med 50%");
        }
    }


   

   
}