using System.Collections;
using UnityEngine;

public  abstract class Bonus : Item
{
    public void Start()
    {
        isTakable = true;
    }
    public abstract void OnPickUp(Player _player = null);

}
