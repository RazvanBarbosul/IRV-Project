using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class FinnishTimer : MonoBehaviour {
    public ParticleSystem particles1;
    public ParticleSystem particles2;
    public ParticleSystem particles3;
    public ParticleSystem particles4;
    public ParticleSystem particles5;
    public ParticleSystem particles6;
    public ParticleSystem particles7;
    public AudioSource mus;
    private string script;

    private Timer tim;

    public Camera cam;

    public Camera end;
    public GameObject play;
    public GameObject mvm;


    public LayerMask mask;
    private float startTime = 0;
    private float t= 0.1f;
    // Use this for initialization
    void Start() {
        tim = Timer.FindObjectOfType<Timer>();
        particles1.Stop();
        particles2.Stop();
        particles3.Stop();
        particles4.Stop();
        particles5.Stop();
        particles6.Stop();
        particles7.Stop();
        startTime = Time.time;
    }
    private bool ok = false;
    private bool aud = true;

    

    // Update is called once per frame
    void Update() {
        
    }

   
    IEnumerator SongPLaying()
    {
        cam.enabled = false;
       mvm.GetComponent<FirstPersonController>().enabled = false;
       mvm.GetComponent<Teleport>().enabled = false;

         end.enabled = true;
        particles1.Play();
        particles2.Play();
        particles3.Play();
        particles4.Play();
        particles5.Play();
        particles6.Play();
        particles7.Play();
        while (startTime < 17)
        {
            yield return new WaitForSeconds(t);
            startTime += t;
        }
        Swtch();
        
    }
    private void Swtch()
    {
        //end.enabled = false;
        

          cam.enabled = true;
        mvm.GetComponent<FirstPersonController>().enabled = true;
        mvm.GetComponent<Teleport>().enabled = true;
        end.enabled = false;
        particles1.Stop();
        particles2.Stop();
        particles3.Stop();
        particles4.Stop();
        particles5.Stop();
        particles6.Stop();
        particles7.Stop();
        Destroy(play);
        tim.Restart();
        
    }

    private void OnTriggerEnter(Collider other) {
        
        //startTime = Time.time;
        if (tim.IsStarted())
        {
            SceneManager.LoadSceneAsync("Level3", LoadSceneMode.Additive);
            tim.Finnish();
            AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Finnish]);
            



            StartCoroutine(SongPLaying());
            
               
            
            
       
            
        }

    }

  
}



