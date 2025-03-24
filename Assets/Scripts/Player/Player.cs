using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerInfo Info;
    public PlayerStat Stat;
    public InventoryUI Inventory;
    public MeshRenderer HairMeshRenderer;
    public Material OriginalMat;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        Info = new PlayerInfo("Mandoo", 1, 0f, 10f);
        Stat = new PlayerStat(50, 10, 100, 0, 10);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity += transform.forward * 0.5f;
    }
}

 