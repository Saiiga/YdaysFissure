using System.Collections;
using UnityEngine;


public abstract class Equipment : Bonus
{
    [SerializeField] private float waitingTimeToPickAfterDrop = 3.0f;
    [SerializeField] protected bool canBePick = true;

    public virtual void OnDrop(Player _player)
    {
        transform.position = _player.transform.position;
        meshRenderer.enabled = true;
        StartCoroutine(WaitingBeforeTake());
    }

    public override void OnPickUp(Player _player)
    {
        if(canBePick)
        {
            _player.SetEquipment(this);
            base.OnPickUp(_player);
            canBePick = false;
        }
    }

    private IEnumerator WaitingBeforeTake()
    {
        yield return new WaitForSeconds(3f);
        canBePick = true;
    }
    //TODO Remove on model

}
