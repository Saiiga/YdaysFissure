using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] private IList<Item> items;
    [SerializeField] private Equipment equipment = null;

    public void AddItem(Item _item)
    {
        items.Add(_item);
    }

    public void RemoveItem(Item _item)
    {
        items.Remove(_item);
    }

    public void RemoveItem(string _name)
    {
        foreach(Item item in items)
        {
            if(item.tag.Contains(_name))
            {
                items.Remove(item);
                break;
            }
        }
    }

    public override void OnHit(int _dmg)
    {
        hp -= Mathf.Abs(_dmg - defense);
        if (hp == 0)
            OnDeath();
    }

    public override void OnDeath()
    {
        //TODO Nothing for now; Death cinematic or other
    }

    public bool CanUnlockDoor()
    {
        //TODO
        return false;
    }

    public void SetEquipment(Equipment _equipment)
    {
        if (equipment != null)
            equipment.OnDrop(this);
        
        equipment = _equipment;
        equipment.OnPickUp(this);
    }
}
