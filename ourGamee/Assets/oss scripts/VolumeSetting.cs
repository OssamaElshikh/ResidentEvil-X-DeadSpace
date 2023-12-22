using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSetting : MonoBehaviour
{
   [SerializeField] AudioMixer mixer;
        const string Mixer_Music = "music";
        const string Mixer_SFX = "SFX_music";


    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(Mixer_Music, value);
    }
    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(Mixer_SFX, value);
    }

}
