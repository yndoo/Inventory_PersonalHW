using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Wandering에 가까운 느낌으로? 
public class PlayerSearchingState : PlayerBaseState
{
    float MaxWanderDistance = 20f;
    float MaxDetectDistance = 4f;

    Vector3 WanderTargetPos = Vector3.zero;

    public PlayerSearchingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        // 목표지점 찾아 이동
        WanderTargetPos = GetWanderPosition();
        stateMachine.Player.Agent.SetDestination(WanderTargetPos);
    }

    public override void Update()
    {
        base.Update();
        // TODO : 아이템 감지하면 아이템을 향해서 Move, 아니면 다시 Searching
        if(stateMachine.Player.HasItem)
        {
            //tateMachine.ChangeState(stateMachine.PlayerMoveState); // TODO
            stateMachine.ChangeState(stateMachine.PlayerSearchingState);
        }
        else
        {
            stateMachine.ChangeState(stateMachine.PlayerSearchingState);
        }
    }

    private Vector3 GetWanderPosition()
    {
        Transform curTrans = stateMachine.Player.transform;

        NavMeshHit hit;
        NavMesh.SamplePosition(curTrans.position + (Random.onUnitSphere * Random.Range(5f, MaxWanderDistance)), out hit, MaxWanderDistance, NavMesh.AllAreas);

        int i = 0;
        while(Vector3.Distance(curTrans.position, hit.position) < MaxDetectDistance)
        {
            NavMesh.SamplePosition(curTrans.position + (Random.onUnitSphere * Random.Range(3f, MaxWanderDistance)), out hit, MaxWanderDistance, NavMesh.AllAreas);
            if (++i >= 20) break;
        }

        return hit.position;
    }
}
