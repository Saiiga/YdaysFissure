using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected BoxCollider hitBox;
    private MeshRenderer meshRenderer;
    [SerializeField] protected bool isTakable;
    [SerializeField] protected bool isActionnable = false;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public abstract void Action();
}