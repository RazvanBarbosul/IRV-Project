using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoad : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressTxt;
    private MenuManager m;

	public void LoadLevel( string level)
    {
        StartCoroutine(LoadAsyncron(level));
       // m.ContinueClick();
    }

    IEnumerator LoadAsyncron(string level)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        loadingScreen.SetActive(true);
       
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            progressTxt.text = (progress * 100f).ToString("f0") + "%";
            yield return null;
        }
        loadingScreen.SetActive(false);
        
    }
}
