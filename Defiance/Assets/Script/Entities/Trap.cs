using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Item
{
    [SerializeField] private readonly int damage;
    [SerializeField] private readonly string name;


    public override void Action(Player _player)
    {
        _player.OnHit(damage);
        Destroy(this);
    }

    public string GetName() { return name; }

    public int GetDamage() { return damage; }
}
