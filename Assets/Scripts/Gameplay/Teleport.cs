using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Teleport : MonoBehaviour {
    public Vector3 pos;
    public GameObject player;
    public Text loadC;
    public Text savC;
    public int saveCounter = 0;
    public int loadCounter = 0;
    public bool isRewinding = false;
    public bool isSaved = false;
    List<Vector3> positions;
    // Use this for initialization
    void Start () {
        pos = player.transform.position;
        positions = new List<Vector3>();
    }

    private void FixedUpdate()
    {
        

        if (isRewinding)
        {            
            Rewind();
            
        }
        else
           if (isSaved) {

            isSaved = false;
            Record();
            isSaved = true;
        }
    }

    void Record()
    {
       
        positions.Insert(0, transform.position);
    }

    void Rewind()
    {
        if (positions.Count > 0)
        {
            transform.position = positions[0];
            positions.RemoveAt(0);
           
        }
        else StopRewind();
        
    }

    // Update is called once per frame
    void Update () {
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            SavePos();
            
        }
        

        if (Input.GetKeyDown(KeyCode.X))
        {
            //LoadPos();
            isRewinding = true;
            StartRewind();
            //if (Input.GetKeyUp(KeyCode.X))
             //   StopRewind();

        }
    }

    void StartRewind()
    {
        if (isSaved)
        {
            isRewinding = true;
            if (isRewinding)
            {
                AudioManager.PlaySFXLoop(AudioResources.Instance.SFX[(int)SFX.Rewind]);
                loadCounter++;
                loadC.text = loadCounter.ToString();
            }
        }
        
    }

    void StopRewind()
    {
        isRewinding = false;
        AudioManager.StopSFXLoop(AudioResources.Instance.SFX[(int)SFX.Rewind]);
        Reset();
    }

    private void Reset()
    {
        positions.Clear();
        positions = new List<Vector3>();
       // Record();
       // positions[0] = pos;
    }

    public void SavePos()
    {
        isSaved = true;
        pos = player.transform.position;
        saveCounter++;
        savC.text = saveCounter.ToString();
        positions[0] = pos;
        Reset();
        Record();
        
       // Debug.Log(pos);
        
       // Debug.Log(saveCounter);

    }

    public void LoadPos()
    {
        player.transform.position = pos;
        loadCounter++;
        loadC.text = loadCounter.ToString();
    }
}
