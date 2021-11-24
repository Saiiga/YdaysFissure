using System.Collections;
using UnityEngine;

public class Helmet : Equipment
{
    public override void Action(Player _player = null)
    {
        // TODO: Handle on ceil trap
    }

    public override void OnDrop(Player _player = null)
    {
        Debug.Log("remove on model");
    }

    public override void OnPickUp(Player _player = null)
    {
        Debug.Log("add on model");
    }
}
