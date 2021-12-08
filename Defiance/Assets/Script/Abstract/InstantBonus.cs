using System.Collections;
using UnityEngine;


public abstract class InstantBonus : Bonus
{

    public override void OnPickUp(Player _player)
    {
        Action(_player);
        base.OnPickUp(_player);
        Destroy(this);
    }
}
