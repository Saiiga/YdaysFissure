using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected BoxCollider hitBox;
    [SerializeField] protected MeshRenderer meshRenderer;
    [SerializeField] protected bool isTakable;
    [SerializeField] protected bool isActionnable = false;

    private void Start()
    {
        hitBox = GetComponent<BoxCollider>();
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public abstract void Action(Player _player = null);
}