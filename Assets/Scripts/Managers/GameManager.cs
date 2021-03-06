﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager Instance;

    public delegate void InitFunc(bool state);
    public static event InitFunc OnInit;
  //  public LevelInit leveInit;

    public static GameManager Get()
    {
        return Instance;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
            Init();
        }
        else
        {
            Destroy(gameObject);
            Debug.Log("GameManager Instance: " + (Instance == this));
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    private void Init()
    {
        AudioManager.Init();
        GameData.Load();
    }

    private void OnDestroy()
    {

    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.T))
        {
            SceneManager.LoadScene("Scene2");
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene("Init");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            OnInit(true);
        }
        */
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameData.Load();
            Debug.Log("Game Loade");
        }

       

        if (Input.GetKeyDown(KeyCode.N))
        {
            Debug.Log(Application.dataPath);
            Debug.Log(Application.persistentDataPath);
            Debug.Log(Application.streamingAssetsPath);
            GameData.NewGame();
        }
        
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameData.Save();
            Debug.Log("Game Saved");
            
        }
        
    }

    private void LateUpdate()
    {

    }

    private void FixedUpdate()
    {

    }

    public void OnTriggerEnter(Collider other)
    {

    }

}