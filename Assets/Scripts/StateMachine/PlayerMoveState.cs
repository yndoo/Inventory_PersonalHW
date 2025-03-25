using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        // 아이템 위치로 달려가기 
        stateMachine.Player.Agent.speed = 10f;
        stateMachine.Player.Agent.isStopped = false;
        stateMachine.Player.Agent.SetDestination(stateMachine.DetectedPosition);
    }

    public override void Update()
    {
        base.Update();
        if(stateMachine.Player.Agent.remainingDistance <= 0.1f)
        {
            stateMachine.ChangeState(stateMachine.PlayerSearchingState);
        }
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.Player.Agent.isStopped = true;
        stateMachine.Player.IsItemDetected = false;
    }
}
