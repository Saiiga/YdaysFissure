﻿using System.Collections;
using UnityEngine;

public class Helmet : Equipment
{
    public override void Action(Player _player = null)
    {
        // TODO: Handle on ceil trap
    }

    public override void OnDrop(Player _player = null)
    {
        meshRenderer.enabled = true;
        Debug.Log("remove on model");
    }

    public override void OnPickUp(Player _player = null)
    {
        meshRenderer.enabled = false;
        Debug.Log("add on model");
    }
}
