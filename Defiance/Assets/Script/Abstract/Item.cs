using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected BoxCollider hitBox;
    private Material material;
    [SerializeField] protected bool isTakable;
    [SerializeField] protected bool isActionnable = false;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider>();
        material = GetComponent<Material>();
    }

    public abstract void Action();
}