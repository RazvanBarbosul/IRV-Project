using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum AmbientalMusic
{
    SaveSound,
}

public enum BackgroundMusic
{
    MainMenu,
    Music2,
}

public enum SFX
{
   Force,
   Luck,
   Knife,
   DoorOpen,
   DoorClose,
   GoGoGo,
   Finnish,
   Rewind,
   Grenade,

}

public class AudioResources : MonoBehaviour
{

  //  public AudioSource collect_coin;
    public AudioSource[] backgroundMusic;
    public AudioSource[] ambientalMusic;
    public AudioSource[] SFX;
    public AudioSource[] voice;

    public static AudioResources Instance;

    void Awake()
    {
        Instance = this;
    }
}