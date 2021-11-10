using Assets.Script.Entities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClass : Item
{
    [SerializeField] private int damage;

    public override void Action()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().OnHit(damage);
        }
    }
}
