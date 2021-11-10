using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField] protected Rigidbody hitbox;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] protected int hp;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected int defense;
    [SerializeField] protected int attack;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public abstract void OnHit();
}
