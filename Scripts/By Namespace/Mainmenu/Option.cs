using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    public Toggle fullscreentoggle;
    public Dropdown resolutiondropdown;
    public Dropdown texturedropdown;
    public Slider soundslider;

    public AudioSource musicsource;
    public Resolution[] resolutions;
    public GameSetting gameSettings;

    void onenable()
    {
        gameSettings = new GameSetting();
        
        fullscreentoggle.onValueChanged.AddListener(delegate { onfullscreentoggle(); });
        resolutiondropdown.onValueChanged.AddListener(delegate { onresolutionchange(); });
        texturedropdown.onValueChanged.AddListener(delegate { ontexturequalitychange(); });
        soundslider.onValueChanged.AddListener(delegate { onsoundvolume(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutiondropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
    }

    public void onfullscreentoggle()
    {
       gameSettings.fullscreen = Screen.fullScreen = fullscreentoggle.isOn;
    }

    public void onresolutionchange()
    {
        Screen.SetResolution(resolutions[resolutiondropdown.value].width, resolutions[resolutiondropdown.value].height, Screen.fullScreen);
    }

    public void ontexturequalitychange()
    {
        QualitySettings.masterTextureLimit = gameSettings.texture = texturedropdown.value;
    }

    public void onsoundvolume()
    {
        musicsource.volume = gameSettings.soundvolume = soundslider.value;
    }

    public void savesetting()
    {

    }

    public void loadsetting()
    {

    }
}


