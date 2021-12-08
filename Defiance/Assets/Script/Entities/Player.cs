using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] private IList<Item> items;
    [SerializeField] private Equipment equipment = null;

    private Vector3 velocity = Vector3.zero;

    public void FixedUpdate()
    {
        HandleMovement();
    }

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

    public void DestroyEquipment()
    {
        if(equipment != null)
        {
            // TODO: add animation explosion
            Destroy(equipment);
            equipment = null;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Snake snake = other.GetComponent<Snake>();
        Trap trap = other.GetComponent<Trap>();

        if (snake != null)
        {
            if(equipment != null && equipment.GetType() != typeof(Armor))
                DestroyEquipment();
            else
            {
                // TODO: game over
            }
        }

        if(trap != null)
        {
            if(equipment != null && equipment.GetType() == typeof(Helmet) && other.CompareTag("CeilTrap"))
                DestroyEquipment();
            else
                LooseHP(trap.GetDamage());

        }
    }

    private void HandleMovement()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
        {
            targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, movement);
            hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, -movement);
            hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
        }
        if(Input.GetKey(KeyCode.Q))
        {
            targetVelocity = new Vector3(-movement, hitbox.velocity.y, hitbox.velocity.z);
            hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            targetVelocity = new Vector3(movement, hitbox.velocity.y, hitbox.velocity.z);
            hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
        }
        animator.SetFloat("movementX", hitbox.velocity.x);
        animator.SetFloat("movementY", hitbox.velocity.y);
        animator.SetFloat("movementZ", hitbox.velocity.z);

    }
}
