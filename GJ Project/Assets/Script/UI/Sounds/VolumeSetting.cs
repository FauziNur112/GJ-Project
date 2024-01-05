using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class VolumeSetting : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private AudioMixer m_AudioMixer;
    [SerializeField] private Slider MixerSliderSFX;
    [SerializeField] private Slider MixerSliderBGM;
    void Start()
    {
        if (PlayerPrefs.HasKey("VolumBGM"))
        {
            LoadBGM();
        } else
        {
            SetBGMVolume();
        }

        if (PlayerPrefs.HasKey("VolumSFX"))
        {
            LoadSFX();
        }
        else
        {
            SetSFXVolume();
        }
       
    }

    public void SetSFXVolume()
    {
        float volume = MixerSliderSFX.value;
        m_AudioMixer.SetFloat("Vol_SFX", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("VolumSFX", volume);
    }
    public void SetBGMVolume()
    {
        float volume = MixerSliderBGM.value;
        m_AudioMixer.SetFloat("Vol_BGM", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("VolumBGM", volume);
    }

    private void LoadSFX ()
    {
        MixerSliderSFX.value = PlayerPrefs.GetFloat("VolumSFX");
        SetSFXVolume();
    }

    private void LoadBGM()
    {
        MixerSliderBGM.value = PlayerPrefs.GetFloat("VolumBGM");
        SetBGMVolume();
    }

}
