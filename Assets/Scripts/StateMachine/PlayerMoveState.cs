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
        // TODO : 아이템 위치 받아놓기
    }

    public override void Update()
    {
        base.Update();
        // TODO : 아이템으로 달려가기
    }
}
