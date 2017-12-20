using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour {

    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosion;
    public MeshRenderer mr;
    public ParticleSystem particles1;
    // Use this for initialization
    void Start () {
        countdown = delay;
	}
	
	// Update is called once per frame
	void Update () {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
	}

    void Explode()
    {
        //explosion.PlayAnimation()
        particles1.Play();
        AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Grenade]);
        mr.enabled = false;
        Destroy(gameObject,4);
        
    }
}
