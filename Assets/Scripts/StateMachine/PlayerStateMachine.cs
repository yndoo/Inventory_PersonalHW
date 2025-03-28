using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player;
    public Vector3 DetectedPosition;

    public PlayerSearchingState PlayerSearchingState {  get; private set; }
    public PlayerMoveState PlayerMoveState { get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.Player = player;

        PlayerSearchingState = new PlayerSearchingState(this);
        PlayerMoveState = new PlayerMoveState(this);
    }
}
