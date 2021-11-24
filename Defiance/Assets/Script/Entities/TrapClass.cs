using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClass : Item
{
    [SerializeField] private int damage;

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
}
