using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;


public class ReturnToMainMenu : MonoBehaviour {

    public GameObject loadingScreen, gameManager, player;
    public Slider slider;
    public Text progressTxt;
    public Camera cam;
    private MenuManager m;

    public void LoadLevel(string level)
    {
        StartCoroutine(LoadAsyncron(level));
    }

    IEnumerator LoadAsyncron(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        loadingScreen.SetActive(true);

      //  loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressTxt.text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
        loadingScreen.SetActive(false);
        player.GetComponent<FirstPersonController>().enabled = true;
        cam.enabled = true;
        Destroy(cam);
       // m.ContinueClick();
       // m.menuStop();
    }
}