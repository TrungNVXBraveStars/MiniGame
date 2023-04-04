using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (T)FindAnyObjectByType<T>();
                if (instance == null)
                {
                    GameObject gameObject = new GameObject();
                    gameObject.name = typeof(T).Name;
                    instance = gameObject.AddComponent<T>();
                }
            }
            return instance;
        }
    }

}
