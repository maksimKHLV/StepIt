using System;
using System.Collections.Generic;


abstract class Warrior
{
    public string Name { get; protected set; }
    public int Health { get; set; }
    public int Damage { get; set; }

    public Warrior(string name, int health, int damage)
    {
        Name = name;
        Health = health;
        Damage = damage;
    }

    public abstract void Attack();
}


class LightCavalry : Warrior
{
    public LightCavalry(string name, int health, int damage) : base(name, health, damage) { }

    public override void Attack()
    {
        Console.WriteLine($"Легкая конница {Name} атакует на {Damage} урона");
    }
}


class HeavyCavalry : Warrior
{
    public HeavyCavalry(string name, int health, int damage) : base(name, health, damage) { }

    public override void Attack()
    {
        Console.WriteLine($"Тяжелая конница {Name} атакует на {Damage} урона");
    }
}


class LightInfantry : Warrior
{
    public LightInfantry(string name, int health, int damage) : base(name, health, damage) { }

    public override void Attack()
    {
        Console.WriteLine($"Легкая пехота {Name} атакует на {Damage} урона");
    }
}


class HeavyInfantry : Warrior
{
    public HeavyInfantry(string name, int health, int damage) : base(name, health, damage) { }

    public override void Attack()
    {
        Console.WriteLine($"Тяжелая пехота {Name} атакует на {Damage} урона");
    }
}


abstract class CountryFactory
{
    public abstract LightCavalry CreateLightCavalry();
    public abstract HeavyCavalry CreateHeavyCavalry();
    public abstract LightInfantry CreateLightInfantry();
    public abstract HeavyInfantry CreateHeavyInfantry();
}


class RussianFactory : CountryFactory
{
    public override LightCavalry CreateLightCavalry()
    {
        return new LightCavalry("Донские казаки", 100, 10);
    }

    public override HeavyCavalry CreateHeavyCavalry()
    {
        return new HeavyCavalry("Стрелецкое войско", 200, 20);
    }

    public override LightInfantry CreateLightInfantry()
    {
        return new LightInfantry("Московские крестьяне", 80, 5);
    }

    public override HeavyInfantry CreateHeavyInfantry()
    {
        return new HeavyInfantry("Строгановские ратники", 150, 15);
    }
}