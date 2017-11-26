using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    public Text timerText;
    public GameObject fin;
    
    private float startTime;
    private float t;
    private bool finnished = false;
    private bool started = false;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (finnished)
            return;
        if (started)
        {
             t = Time.time - startTime;
            string hours = ((int)t / 3600).ToString();
            string minutes = ((int)t / 60).ToString();
            string sec = (t % 60).ToString("f2");

            timerText.text = hours + ":" + minutes + ":" + sec;
        }
        
	}

    public void Finnish()
    {
        finnished = true;
        timerText.color = Color.yellow;
    }

    public void Starting()
    {
        started = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Starting();
        startTime = Time.time;
        AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.GoGoGo]);
    }
}
