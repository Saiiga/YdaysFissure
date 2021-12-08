using System.Collections;
using UnityEngine;

public  abstract class Bonus : Item
{
    public void Start()
    {
        isTakable = true;
    }
    public abstract void OnPickUp(Player _player = null);
    //TODO Add on model

    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
            OnPickUp(player);
    }

}
