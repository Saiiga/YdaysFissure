using System.Collections;
using UnityEngine;


public class Heart : InstantBonus
{
    public override void OnPickUp(Player _player = null)
    {
        _player.AddHP(1);
        Destroy(this);
    }
}
