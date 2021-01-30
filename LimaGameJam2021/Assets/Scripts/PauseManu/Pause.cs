using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    #region Configs

        public Slider MusicSlider;
        public Slider VolumeSlider;

        public Text MusicText;
        public Text VolumeText;

        private Resolution[] res;
        public Dropdown _res;

        private int[] fps;
        public Dropdown _fps;

        private bool fullscreen;
        public Toggle _fullscreen;

        public Dropdown _quatex;

    #endregion

    public GameObject pauseManu;
    public GameObject Inventory;

    private bool deployed = false;
    private bool InvDeployed = false;

    void Start()
    {
        #region Audio
        MusicSlider.value = AudioConfigurations.MusicVolume;
        VolumeSlider.value = AudioConfigurations.GeneralVolume;

        MusicText.text = MusicSlider.value * 100 + "%";
        VolumeText.text = VolumeSlider.value * 100 + "%";

        MusicSlider.onValueChanged.AddListener(delegate
        {
            AudioConfigurations.SetMusic(AudioConfigurations.GeneralVolume,MusicSlider.value);
            MusicText.text = MusicSlider.value * 100 + "%";
        });

        VolumeSlider.onValueChanged.AddListener(delegate
        {
            AudioConfigurations.SetMusic(VolumeSlider.value,AudioConfigurations.MusicVolume);
            VolumeText.text = VolumeSlider.value * 100 + "%";
        });

        AudioConfigurations.SetMusic(AudioConfigurations.GeneralVolume,AudioConfigurations.MusicVolume);
        #endregion

        #region Graphics
        pauseManu.SetActive(false);


        _fullscreen.onValueChanged.AddListener(delegate
        {

            fullscreen = _fullscreen.isOn;
            SetFullScrn();

        });

        res = Screen.resolutions;

        List<string> reses = new List<string>();

        for (int i = 0; i < res.Length; i++)
        {
            reses.Add(res[i]+"");
        }

        _res.AddOptions(reses);
        _res.onValueChanged.AddListener(delegate
        {
            SetRes(_res.value);

        });

        fps = new int[3];
        fps[0] = 30;
        fps[1] = 60;
        fps[2] = 120;

        List<string> fpses = new List<string>();

        for (int i = 0; i < fps.Length; i++)
        {
            fpses.Add(fps[i]+"");
        }

        _fps.AddOptions(fpses);
        _fps.onValueChanged.AddListener(delegate
        {

            SetFPS(_fps.value);

        });

        List<string> qualityTextures = new List<string>();

        qualityTextures.Add("Full");
        qualityTextures.Add("Half");
        qualityTextures.Add("Quarted");
        qualityTextures.Add("Eight");

        _quatex.AddOptions(qualityTextures);
        _quatex.onValueChanged.AddListener(delegate
        {

            QualitySettings.masterTextureLimit = _quatex.value;

        });
        #endregion



    }

    #region Audio&GraphicsFunctions
    private void SetFPS(int ind)
    {
        Resolution aux = Screen.currentResolution;

        Screen.SetResolution(aux.width,aux.height,fullscreen,fps[ind]);
    }

    private void SetFullScrn()
    {
        Resolution aux = Screen.currentResolution;

        Screen.SetResolution(aux.width,aux.height,fullscreen);
    }

    private void SetRes(int rs)
    {
        Resolution aux = res[rs];

        Screen.SetResolution(aux.width,aux.height,fullscreen);
    }

    public void GoToMenu()
    {
        SceneLoad.TranscionesScene("Menu");
    }

    public void ExitG()
    {
        Application.Quit();
    }

    public void ResumeG()
    {
        Time.timeScale = 1;
        pauseManu.SetActive(false);
        deployed = false;
    }
    #endregion

    public void ResumenAfterInvetory()
    {
        Time.timeScale = 1;
        Inventory.SetActive(false);
        InvDeployed = false;
    }

    void Update()
    {
        #region Manu Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!deployed && !InvDeployed)
            {
                Time.timeScale = 0;
                pauseManu.SetActive(true);
                deployed = true;
            }
            else
            {
                ResumeG();
            }
        }
        #endregion

        #region Inventory

        if (Input.GetKeyDown(KeyCode.C))
        {

            if (!deployed && !InvDeployed)
            {
                Time.timeScale = 0;
                Inventory.SetActive(true);
                InvDeployed = true;
            }
            else
            {
                ResumenAfterInvetory();
            }
        }
        #endregion
    }

}
