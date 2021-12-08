using UnityEngine;

public class Armor : Equipment
{
    public override void Action(Player _player = null)
    {
    }

    public override void OnDrop(Player _player = null)
    {
        // TODO: add on model
        meshRenderer.enabled = true;

    }

    public override void OnPickUp(Player _player = null)
    {
        // TODO: remove on model
        meshRenderer.enabled = false;

    }


}
