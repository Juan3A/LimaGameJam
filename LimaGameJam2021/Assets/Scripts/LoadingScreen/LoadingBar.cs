using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour
{
    private Image slide;

    public GameObject text;
    public Text loadingT;

    void Start()
    {
        slide = gameObject.GetComponent<Image>();
        loadingT = loadingT.gameObject.GetComponent<Text>();
        text.SetActive(false);
        StartCoroutine(LoadAsync());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadAsync()
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(SceneLoad.SceneTO);
        ao.allowSceneActivation = false;


        while (!ao.isDone)
        {

            slide.fillAmount = ao.progress+.1f;
            loadingT.text = (ao.progress+.1f) * 100 + " %";

            if (ao.progress >= .9f)
            {

                text.SetActive(true);

                if (Input.GetKeyDown(KeyCode.Space))
                {

                    ao.allowSceneActivation = true;
                    SceneLoad.Reset();
                }

                yield return null;
            }

        }
    }
}
