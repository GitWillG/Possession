using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonImplementation : MonoBehaviour
{
    private static SingletonImplementation _instance;
    public static SingletonImplementation Instance { get { return _instance; } }

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            //Debug.Log("Instance was found");
        }
        else
        {
            _instance = this;
            //Debug.Log("Instance was not found");
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
