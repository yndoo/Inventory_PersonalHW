using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.Show(EUIType.UserInfoUI, "PlayerName", "1", "5", "10");   
    }
}
