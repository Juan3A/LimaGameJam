using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manu : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1280,720,false,60);
        
        AudioConfigurations.SetMusic(.5f,.5f);
    }

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

public static class AudioConfigurations
{

    public static float MusicVolume ;
    public static float GeneralVolume ;

    public static void SetMusic(float Volumen, float MusicVolumen_)
    {

        MusicVolume = MusicVolumen_;
        GeneralVolume = Volumen;
        AudioListener.volume = GeneralVolume;
        //Borrar "//" cuando la camara tenga musica
        //Camera.main.GetComponent<AudioSource>().volume = MusicVolume;
    }

}

