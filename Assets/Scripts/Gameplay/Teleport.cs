using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    public Vector3 pos;
    public GameObject player;
    public int saveCounter = 0;
    public int loadCounter = 0;
    // Use this for initialization
    void Start () {
        
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SavePos();
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            LoadPos();

        }
    }

    public void SavePos()
    {
       
            pos = player.transform.position;
        Debug.Log(pos);
        saveCounter++;
        Debug.Log(saveCounter);

    }

    public void LoadPos()
    {
        player.transform.position = pos;
        loadCounter++;
    }
}
