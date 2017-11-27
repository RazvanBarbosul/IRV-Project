using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour {
    public Vector3 pos;
    public GameObject player;
    public Text loadC;
    public Text savC;
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
        savC.text = saveCounter.ToString();
        Debug.Log(saveCounter);

    }

    public void LoadPos()
    {
        player.transform.position = pos;
        loadCounter++;
        loadC.text = loadCounter.ToString();
    }
}
