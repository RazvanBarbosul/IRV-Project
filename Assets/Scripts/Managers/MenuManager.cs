using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public GameObject MenuPanel, GUIPanel, InvetoryPanel, SettingsPanel, player, gameManager, LoadingScreenPanel;
    private bool esc = false;
    private bool set = false;
    public Camera cam;
    public bool isLocked;
    public Slider slider;
    public Text progressTxt;
    public Slider sfxSlider;
    public Slider musicSlider;
    public Slider voiceSlider;
    public Slider ambientalSlider;
    public Button saveButton;


    private void SetCursorLock(bool isLocked)
    {
        this.isLocked = isLocked;
    }
     void Start()
    {
        gameManager.SetActive(true);
        isLocked = true;
        cam.enabled = false;
        cam.enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        menuStop();
        MenuPanel.gameObject.SetActive(false);
        ContinueClick();
        ConfigureSlider(sfxSlider, AudioManager.AudioChannel.SFX);
        ConfigureSlider(musicSlider, AudioManager.AudioChannel.Music);
        ConfigureSlider(voiceSlider, AudioManager.AudioChannel.Voice);
        ConfigureSlider(ambientalSlider, AudioManager.AudioChannel.Ambiental);

        saveButton.onClick.AddListener(SaveAudioSettings);
    }

     void Update()
    {
        CheckCursor();
      
        if (Input.GetKeyDown(KeyCode.Escape) )
        {
            if (!esc)
            {
                menuStart();
            }
           
        }
      
          
    }

    private void ConfigureSlider(Slider slider, AudioManager.AudioChannel channel)
    {
        if (!slider)
            return;

        slider.value = AudioManager.GetVolume(channel);

        slider.onValueChanged.AddListener((float value) => {
            AudioManager.SetVolume(channel, value);
        });
    }
    public void SaveAudioSettings()
    {
        AudioManager.SaveSettings();
        SettingsPanel.gameObject.SetActive(false);
        menuStart();
    }

    public void menuStart()
    {
        
            getPannel(MenuPanel);
            Time.timeScale = 0;
            esc = true;
            isLocked = false;
            player.GetComponent<FirstPersonController>().enabled = false;
           
             
        
    }

    public void menuStop()
    {
            MenuPanel.gameObject.SetActive(false);
            Time.timeScale = 1;
            esc = false;
            isLocked = true;
            player.GetComponent<FirstPersonController>().enabled = true;
            // SetCursorLock(!isLocked);
            
            
        
    }
    public void getPannel(GameObject pnl)
    {
        MenuPanel = pnl;
        MenuPanel.gameObject.SetActive(true);
        GUIPanel.gameObject.SetActive(false);
        InvetoryPanel.gameObject.SetActive(false);
        


    }
    public void CheckCursor()
    {
        if (isLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            player.GetComponent<FirstPersonController>().enabled = true;

        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<FirstPersonController>().enabled = false;
        }
    }


    public void getSettingsPanel(GameObject SettingsPanel)
    {
        SettingsPanel.gameObject.SetActive(true);
        MenuPanel.gameObject.SetActive(false);
        Debug.Log("Settings");
        set = true;
    }

    public void ContinueClick()
    {
        SettingsPanel.gameObject.SetActive(false);
        GUIPanel.gameObject.SetActive(true);
        InvetoryPanel.gameObject.SetActive(true);
        cam.enabled = true;
        player.GetComponent<FirstPersonController>().enabled = true;
        menuStop();
    }

    public void ReturnToMainMenu(string level)
    {

        MenuPanel.gameObject.SetActive(false);
        GUIPanel.gameObject.SetActive(true);
        InvetoryPanel.gameObject.SetActive(true);
        cam.enabled = false;
        cam.enabled = true;
        
        StartCoroutine(LoadAsyncron(level));
        
    }

    IEnumerator LoadAsyncron(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        LoadingScreenPanel.SetActive(true);

        //  loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressTxt.text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
        LoadingScreenPanel.SetActive(false);
        Destroy(gameManager);
    }

        public void ExitToWindows()
    {
        Application.Quit();
    }
}
