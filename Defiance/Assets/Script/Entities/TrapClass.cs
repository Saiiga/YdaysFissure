using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapClass : Item
{
    [SerializeField] private float damage;

    public override void Action()
    {
        throw new System.NotImplementedException();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<Player>().OnHit(damage);
        }
    }
}
