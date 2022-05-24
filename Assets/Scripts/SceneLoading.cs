using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public Slider Load_Slider;
    public GameObject Loadscene;
    public Text Load_Percentage;
    int Level = 1;
    public int Levelnumber = 1;

    public void StartLoadScene()
    {
        StartCoroutine(LoadLevel());
    }
    IEnumerator LoadLevel()
    {
        Loadscene.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + Level);
        op.allowSceneActivation = false;
        while (!op.isDone)
        {
            Load_Slider.value = op.progress;
            Load_Percentage.text = op.progress * 100 + "%";
            if (op.progress >= 0.9f)
            {
                Load_Slider.value = 1.0f;
                Load_Percentage.text = "AnyKeyDown";
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
        SceneManager.LoadScene(Levelnumber, LoadSceneMode.Single);
    }
}
