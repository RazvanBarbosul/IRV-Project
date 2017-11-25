using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SoundLocation
{
    NotSet,

    Location1,
    Location2,
    Location3,

    // 
    Count
}


public class SoundTriggers : MonoBehaviour {

    public SoundLocation location;
    public bool entered = false;

    // Use this for initialization
    void Start () {
      
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (location == SoundLocation.Location1)
        {
            if (!entered)
            {
                Debug.Log("TriggerArea");
                AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Force]);
                entered = true;
            }
        }

        if (location == SoundLocation.Location2)
        {
            if (!entered)
            {
                Debug.Log("TriggerArea");
                AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Luck]);
                entered = true;
            }
        }

    }
}
