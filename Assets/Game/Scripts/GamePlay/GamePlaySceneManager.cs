using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlaySceneManager : MonoBehaviour
{
    public Slider loadSlider;
    public GameObject loadSceneObject;
    public Text loadPercentage;
    public int Level = 1;
    public int levelNumber = 1;

    public void StartLoadScene()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        loadSceneObject.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + Level);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            loadSlider.value = op.progress;
            loadPercentage.text = op.progress * 100 + "%";
            if (op.progress >= 0.9f)
            {
                loadSlider.value = 1.0f;
                loadPercentage.text = "AnyKeyDown";
                if (Input.anyKeyDown)
                {
                    op.allowSceneActivation = true;
                }
            }
            yield return null;
        }
    }

    public void LoadScene_withoutUI()
    {
        SceneManager.LoadScene(levelNumber, LoadSceneMode.Single);
    }
    
    public void TimeStop()
    {
        Time.timeScale = 0;
        TopDownCharacterController.ChangeBool(false);
        //AudioManager.PausePlayingBackgroundMusicAudio();
    }
    public void TimeStart()
    {
        Time.timeScale = 1;
        TopDownCharacterController.ChangeBool(true);
        //AudioManager.ContinuePlayingBackgroundMusicAudio();
    }
}
