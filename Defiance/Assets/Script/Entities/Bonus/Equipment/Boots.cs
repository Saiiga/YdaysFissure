using UnityEngine;

public class Boots : Equipment
{

    [SerializeField] private readonly float bonus;

    public override void Action(Player _player = null)
    {
    }

    public override void OnDrop(Player _player)
    {
        _player.LooseMoveSpeed(bonus);
        Debug.Log("add on model");
    }

    public override void OnPickUp(Player _player)
    {
        _player.AddMoveSpeed(bonus);
        Debug.Log("remove on model");
    }

}
