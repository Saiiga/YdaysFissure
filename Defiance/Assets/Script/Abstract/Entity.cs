using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody hitbox;
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] protected int hp { get; set; }
    [SerializeField] protected float moveSpeed { get; set; }
    [SerializeField] protected int defense { get; set; }
    [SerializeField] protected int attack { get; set; }
    protected Vector3 targetVelocity { get; set; }

    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnHit(int dmg);

    public abstract void OnDeath();

    protected void Foward()
    {
        float movement =  moveSpeed * Time.deltaTime;

        targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, movement);
        hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
    }

    protected void Backward()
    {
        float movement = moveSpeed * Time.deltaTime;

        targetVelocity = new Vector3(hitbox.velocity.x, hitbox.velocity.y, -movement);
        hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
    }

    protected void Left()
    {
        float movement = moveSpeed * Time.deltaTime;

        targetVelocity = new Vector3(-movement, hitbox.velocity.y, hitbox.velocity.z);
        hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
    }

    protected void Right()
    {
        float movement = moveSpeed * Time.deltaTime;

        targetVelocity = new Vector3(movement, hitbox.velocity.y, hitbox.velocity.z);
        hitbox.velocity = Vector3.SmoothDamp(hitbox.velocity, targetVelocity, ref velocity, .05f);
    }

    public void AddHP(int _hp)
    {
        hp += _hp;
    }

    public void LooseHP(int _hp)
    {
        hp -= _hp;
    }

    public void AddMoveSpeed(float _ms)
    {
        moveSpeed += _ms;
    }

    public void LooseMoveSpeed(float _ms)
    {
        moveSpeed -= _ms;
    }

    public void AddDefense(int _def)
    {
        defense += _def;
    }

    public void LooseDefense(int _def)
    {
        defense -= _def;
    }
}
