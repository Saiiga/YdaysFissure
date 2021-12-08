using System.Collections;
using UnityEngine;


public class Heart : InstantBonus
{
    public override void Action(Player _player)
    {
        _player.AddHP(1);
    }
}
