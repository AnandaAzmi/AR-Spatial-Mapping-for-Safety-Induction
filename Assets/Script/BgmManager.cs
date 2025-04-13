using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmManager : MonoBehaviour
{
    public AudioSource bgmAudioSource;
    public Sprite iconSoundOn;
    public Sprite iconSoundOff;
    public Image buttonImage;

    private bool isPlaying = true;

    void Start()
    {
        if (bgmAudioSource != null)
        {
            isPlaying = bgmAudioSource.isPlaying;
            UpdateIcon();
        }
    }

    public void ToggleAudio()
    {
        if (bgmAudioSource == null) return;

        isPlaying = !isPlaying;

        if (isPlaying)
        {
            bgmAudioSource.Play();
        }
        else
        {
            bgmAudioSource.Pause();
        }

        UpdateIcon();
    }

    private void UpdateIcon()
    {
        if (buttonImage != null)
        {
            buttonImage.sprite = isPlaying ? iconSoundOn : iconSoundOff;
        }
    }
}
