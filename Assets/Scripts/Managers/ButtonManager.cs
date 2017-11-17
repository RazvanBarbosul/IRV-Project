using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public GameObject Panel, Panel2, P3, p;

    
    public void getPannel(GameObject pnl)
    {
        Panel2 = pnl;
        Panel2.gameObject.SetActive(true);
    }

    public void getPannel2(GameObject pnl)
    {
        P3 = pnl;
        P3.gameObject.SetActive(true);
    }


    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadSceneAsync(newGameLevel);
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }

    public void SettingsBtn(GameObject pan)
    {
        Panel = pan;

        Panel.gameObject.SetActive(false);
        getPannel(Panel2);
         }

    public void BackBtn(GameObject pan)
    {      
        p = pan;
        p.gameObject.SetActive(false);
        
        getPannel(P3);
    }

    public void Start()
    {
        Panel2.gameObject.SetActive(false);
        AudioManager.PlayBackgroundMusic(AudioResources.Instance.backgroundMusic[(int)BackgroundMusic.MainMenu]);

    }
}
