using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CineCamera : MonoBehaviour
{
    CinemachineVirtualCamera VCamera;

    private void Awake()
    {
        VCamera = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        VCamera.Follow = GameManager.Instance.Player.transform;
    }
}
