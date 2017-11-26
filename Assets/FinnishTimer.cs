using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishTimer : MonoBehaviour {
    private Timer tim;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnTriggerEnter(Collider other) {


       tim = Timer.FindObjectOfType<Timer>();
        tim.Finnish();
        AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Finnish]);
    }

  
}



