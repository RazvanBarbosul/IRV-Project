using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public int itemID;
    public GameObject knf;
    public InventoryItem item;
    public InventoryEntry uiEntry;
    private bool canPick = false;
   


    // Use this for initialization
    void Start()
    {
        GameData.OnDataInit(Init);
        knf.GetInstanceID();
    }

    private void Init()
    {
        bool found = false;
        foreach (var item in GameData.Instance.pickups)
        {
            if (item.ID == itemID)
            {
                found = true;
                SetItem(item);
            }
        }
        if (!found)
        {
            Debug.LogWarning("Pickup Item has an invalid itemID");
            Destroy(gameObject,1);
            GameData.RemoveCallback(Init);
        }
    }

    void SetItem(InventoryItem item)
    {
        this.item = item;
        uiEntry.SetItem(item);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(new Vector3(0, Time.deltaTime * 70, 0));
            
       

        if (canPick && Input.GetKeyDown(KeyCode.E))
        {
            canPick = false;
            Destroy(knf,1);
            AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.Knife]);
            GameData.PickItem(item);
            InventoryPane.Refresh();
            Destroy(gameObject, 1);
            GameData.RemoveCallback(Init);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        canPick = true;
        uiEntry.gameObject.SetActive(canPick);
        Debug.Log(canPick + " itemID" + item.ID);
    }

    private void OnTriggerExit(Collider other)
    {
        canPick = false;
        uiEntry.gameObject.SetActive(canPick);
        Debug.Log(canPick + " itemID" + item.ID);
    }
}
