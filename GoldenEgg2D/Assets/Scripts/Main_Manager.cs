using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class Main_Manager : MonoBehaviour
{
    private static Main_Manager _instance;
    public static Main_Manager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Main_Manager>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    _instance = singletonObject.AddComponent<Main_Manager>();
                    singletonObject.name = typeof(Main_Manager).ToString() + " (Singleton)";
                }
            }
            return _instance;
        }
    }
    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject); // Keep this instance alive across scenes
    }

    

    
    

}
