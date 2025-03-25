using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public Player Player;
    public bool IsGameCleared;

    protected override void Awake()
    {
        base.Awake();
        if(Player == null)
        {
            GameObject origin = ResourceManager.Instance.LoadResource("Player", "Prefab");
            if(origin != null )
            {
                Player = Instantiate(origin).GetComponent<Player>();
            }    
        }
    }

    private void Start()
    {
        UIManager.Instance.LoadUI();
    }

    public void GameClear()
    {
        if (IsGameCleared) return;
        IsGameCleared = true;
        UIManager.Instance.GetUIObject(0).SetActive(true);
    }
}
