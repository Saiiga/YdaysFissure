using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClass : Item
{
    [SerializeField] private readonly int damage;
    [SerializeField] private readonly string name;


    public override void Action(Player _player)
    {
        _player.OnHit(damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Action(other.GetComponent<Player>());
        }
    }

    public string GetName() { return name; }

    public int GetDamage() { return damage; }
}
