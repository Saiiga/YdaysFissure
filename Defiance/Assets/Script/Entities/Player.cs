using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private Equipment equipment = null;
    [SerializeField] private List<Vector3> lastPositions = new List<Vector3>();

    private Vector3 VectorZero = Vector3.zero;

    public void Start()
    {
        animator.SetFloat("Speed", 0f);
        StartCoroutine(WaitingBeforeAddLastPosition());
    }

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

    public Item GetItem(string _name)
    {
        foreach(Item item in items)
        {
            if (item.tag.Contains(_name))
                return item;
        }
        return null;
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

    public void TryOpenGate(Gate _gate)
    {
        //TODO
        Item key = GetItem("key");
        if(key != null)
        {
            _gate.OpenTheGate();
            items.Remove(key);
            Debug.Log("porte ouverte");
        }
        else
        {
            TextManager.ShowDialog("Je dois trouver la clé avant !", transform);
            Debug.Log("porte fermé");
        }
    }

    public void SetEquipment(Equipment _equipment)
    {
        if (equipment != null)
            equipment.OnDrop(this);
        
        equipment = _equipment;
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
        Gate gate = other.GetComponent<Gate>();

        if (snake != null)
        {
            if(equipment != null && equipment.GetType() == typeof(Armor))
                DestroyEquipment();
            else
                OnDeath();// TODO: game over
        }

        if(trap != null)
        {
            if(equipment != null && equipment.GetType() == typeof(Helmet) && other.CompareTag("CeilTrap"))
                DestroyEquipment();
            else
               trap.Action(this);

        }

        if(gate != null)
        {
            TryOpenGate(gate);
        }
    }

    private void HandleMovement()
    {
        float movement = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Z))
        {
            targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, movement);
            transform.Translate(Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref VectorZero, .05f), Space.Self);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, -movement);
            transform.Translate(Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref VectorZero, .05f), Space.Self);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            targetVelocity = new Vector3(-movement, hitbox.velocity.y, hitbox.velocity.z);
            transform.Translate(Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref VectorZero, .05f), Space.Self);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            targetVelocity = new Vector3(movement, hitbox.velocity.y, hitbox.velocity.z);
            transform.Translate(Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref VectorZero, .05f), Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.down * 50 * Time.deltaTime);
        }

        SetAnimatorSpeed();
        // animator.SetFloat("Speed", moveSpeed);
    }

    public void SetAnimatorSpeed()
    {
        Debug.Log(animator.GetFloat("Speed"));

       if(Mathf.Abs(hitbox.velocity.x) > 0.1f || Mathf.Abs(hitbox.velocity.z) > 0.1f)
       {
           animator.SetFloat("Speed", 1.0f);
            Debug.Log("Speed Set");
       }
        else
        {
            animator.SetFloat("Speed", 0.0f);
            Debug.Log("Speed UnSet");
        }


    }
        // animator.SetFloat("Speed", 1);

    private IEnumerator WaitingBeforeAddLastPosition()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            lastPositions.Insert(0, transform.position);
        }

    }

    public void RemoveLastPosition()
    {
        lastPositions.RemoveAt(lastPositions.Count-1);
    }

    public List<Vector3> GetLastPosition() { return lastPositions; }
}
