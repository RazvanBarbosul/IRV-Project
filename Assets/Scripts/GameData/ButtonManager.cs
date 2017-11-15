using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

    public void NewGameBtn(string newGameLevel)
    {
        SceneManager.LoadSceneAsync(newGameLevel);
    }

    public void QuitGameBtn()
    {
        Application.Quit();
    }

    public void SettingsBtn(Transform menuTransform)
    {
       
        Camera.main.transform.LookAt(menuTransform.position);
    }
}
