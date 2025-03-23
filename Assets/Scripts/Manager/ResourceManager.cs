using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ResourceManager : Singleton<ResourceManager>
{
    private Dictionary<string, GameObject> ResDictionary = new Dictionary<string, GameObject>(); // 키 = 에셋이름
    public GameObject LoadResource(string name, string path) 
    {
        if (ResDictionary.ContainsKey(name))
        {
            return ResDictionary[name];
        }
        GameObject go = Resources.Load($"{path}/{name}") as GameObject;
        ResDictionary[name] = go;
        return go;
    }
}
