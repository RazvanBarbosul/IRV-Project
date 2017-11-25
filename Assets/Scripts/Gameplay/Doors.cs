using UnityEngine;
using System.Collections;

public class Doors : MonoBehaviour
{

    public float timeleft = 0;

    public RaycastHit hit;

    public Transform currentdoor;

    public bool open = false;

    public bool IsOpeningDoor = false;

    public Transform cam;

    public LayerMask mask;




    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && timeleft == 0.0f)
        { CheckDoor();
            if (open) AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.DoorClose]);
            else AudioManager.PlaySFX(AudioResources.Instance.SFX[(int)SFX.DoorOpen]);
        }

        if (IsOpeningDoor)
            OpenAndCloseDoor();
    }

    public void CheckDoor()
    {
        if (Physics.Raycast(cam.position, cam.forward, out hit, 5, mask))
        {
          
            open = false;
            if (hit.transform.parent.localRotation.eulerAngles.y > 45) 
            open = true;
            else open = false;
            
            

            IsOpeningDoor = true;
            currentdoor = hit.transform.parent;
        }
    }

    public void OpenAndCloseDoor()
    {
        timeleft += Time.deltaTime;

        if (open)
        {
            
            currentdoor.localRotation = Quaternion.Slerp(currentdoor.localRotation, Quaternion.Euler(0, 0, 0), timeleft);
            
        }
        else
        {
            
            currentdoor.localRotation = Quaternion.Slerp(currentdoor.localRotation, Quaternion.Euler(0, 90, 0), timeleft);
            

        }

        if (timeleft > 1)
        {
            timeleft = 0;
            IsOpeningDoor = false;
        }

    }
}