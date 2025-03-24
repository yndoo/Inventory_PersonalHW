using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    private Player player;

    public PlayerSearchingState PlayerSearchingState {  get; private set; }

    public PlayerStateMachine(Player player)
    {
        this.player = player;

        PlayerSearchingState = new PlayerSearchingState(this);
    }
}
