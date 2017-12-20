using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour {
    public float throwForc = 40f;
    public GameObject grenadePrefab;
	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowG();
        }
	}

    void ThrowG()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForc, ForceMode.VelocityChange);
    }
}
