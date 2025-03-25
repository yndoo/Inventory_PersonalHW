using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Wandering�� ����� ��������? 
public class PlayerSearchingState : PlayerBaseState
{
    float MaxWanderDistance = 40f;
    float MinDetectDistance = 5f;

    Vector3 WanderTargetPos = Vector3.zero;

    public PlayerSearchingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {

    }

    public override void Enter()
    {
        base.Enter();
        // ��ǥ���� ã�� �̵�
        NavMeshAgent agent = stateMachine.Player.Agent;
        agent.speed = 5f;
        agent.isStopped = false;
        
        WanderTargetPos = GetWanderPosition();
        agent.SetDestination(WanderTargetPos);
    }

    public override void Update()
    {
        base.Update();
        // ������ �����ϸ� �������� ���ؼ� Move, �ƴϸ� �ٽ� Searching
        if(stateMachine.Player.IsItemDetected)
        {
            stateMachine.ChangeState(stateMachine.PlayerMoveState);
        }
        else if(stateMachine.Player.Agent.remainingDistance < 0.1f)
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
        while(Vector3.Distance(curTrans.position, hit.position) < MinDetectDistance)
        {
            NavMesh.SamplePosition(curTrans.position + (Random.onUnitSphere * Random.Range(3f, MaxWanderDistance)), out hit, MaxWanderDistance, NavMesh.AllAreas);
            if (++i >= 20) break;
        }

        return hit.position;
    }
}
