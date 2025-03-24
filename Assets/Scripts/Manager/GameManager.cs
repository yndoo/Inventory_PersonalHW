using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player;

    private void Start()
    {
        if(Player == null)
        {
            GameObject origin = ResourceManager.Instance.LoadResource("Player", "Prefab");
            if(origin != null )
            {
                Player = Instantiate(origin).GetComponent<Player>();
            }    
        }
    }
}
