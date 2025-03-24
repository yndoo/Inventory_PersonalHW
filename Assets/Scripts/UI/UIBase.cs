using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIBase : MonoBehaviour
{
    public bool IsInitActive;

    public abstract void Init();
    public abstract void Open(params object[] contexts);
}
