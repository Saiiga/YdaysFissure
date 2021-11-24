using System.Collections;
using UnityEngine;


public abstract class Equipment : Bonus
{

    public abstract void OnDrop(Player _player = null);
    //TODO Remove on model

}
