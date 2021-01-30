using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void GotoScene(string scene)
    {
        SceneLoad.TranscionesScene(scene);
    }

    public void ExitGame()
    {

        Application.Quit();

    }
}
public static class SceneLoad
{

    public static string SceneTO;
    public static string Interlude = "LoadingScreen";

    public static void TranscionesScene(string sceneT)
    {
        SceneTO = sceneT;
        SceneManager.LoadScene(SceneLoad.Interlude);
    }
    public static void Reset()
    {
        SceneTO = "Menu";
    }

}

