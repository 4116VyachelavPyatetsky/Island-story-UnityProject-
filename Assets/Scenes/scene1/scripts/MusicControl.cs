using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class MusicControl : MonoBehaviour
{
    public string volumeParametr = "MasterVolume";
    public AudioMixer mixer;
    public Slider slider;

    float sliderValue = 1.0f;


    float slider_value_for_save = 1.0f;

    private const float multip = 20;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandlerSlider);
        if (PlayerPrefs.HasKey(volumeParametr))
        {
            slider.value = PlayerPrefs.GetFloat(volumeParametr);
            slider_value_for_save = PlayerPrefs.GetFloat(volumeParametr);
            var volumeValue = Mathf.Log10(slider_value_for_save) * multip;
            mixer.SetFloat(volumeParametr, volumeValue);

        }
    }


    private void HandlerSlider(float value)
    {
        slider_value_for_save = value;
        //var volumeValue = -60.0f + 80*value ;
        var volumeValue = Mathf.Log10(value) * multip;
        mixer.SetFloat(volumeParametr,volumeValue);
    }
    public void OffOnMusic()
    {
        if (slider.value > 0.01f)
        {
            sliderValue = slider.value;
            mixer.SetFloat(volumeParametr, 0);
            slider.value = 0.00001f;
            slider_value_for_save= 0.00001f;
        }
        else
        {
            slider.value = sliderValue;
            slider_value_for_save = sliderValue;
            var volumeValue = Mathf.Log10(sliderValue) * multip;
            mixer.SetFloat(volumeParametr, volumeValue);
        }
    }

    void OnApplicationQuit()
    {
        Save();
    }
    private void OnDisable()
    {
        Save();
    }
    private void OnApplicationPause(bool focus)
    {
        if (!focus)
        {
            Save();
        }
    }
    void Save()
    {
        PlayerPrefs.SetFloat(volumeParametr, slider_value_for_save);
    }
    private void OnDestroy()
    {
        Save();
    }

}
