using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericSingleton<T> : MonoBehaviour where T:GenericSingleton<T>
{
    static T instance;
    public static T Instance{get{return instance;}}
    void Awake() {
        if(instance == null){
            instance = (T)this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this);
    }
}
