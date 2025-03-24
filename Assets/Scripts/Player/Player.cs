using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour, IPointerEnterHandler
{
    public PlayerInfo Info;
    public PlayerStat Stat;
    public InventoryUI Inventory;
    public MeshRenderer HairMeshRenderer;
    public Material OriginalMat;

    public PlayerStateMachine playerStateMachine;

    private NavMeshAgent _agent;
    private Rigidbody _rigidbody;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Å×½ºÆ®");
    }

    private void Awake()
    {
        Info = new PlayerInfo("Mandoo", 1, 0f, 10f);
        Stat = new PlayerStat(50, 10, 100, 0, 10);
        playerStateMachine = new PlayerStateMachine(this);
        _rigidbody = GetComponent<Rigidbody>();
        _agent = GetComponent<NavMeshAgent>();

        playerStateMachine.ChangeState(playerStateMachine.PlayerSearchingState);
    }

    private void Update()
    {
        playerStateMachine.Update();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity += transform.forward * 0.5f;
    }
}

 