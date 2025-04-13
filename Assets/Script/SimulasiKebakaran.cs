using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class SimulasiKebakaran : MonoBehaviour
{
    public Button[] buttons;                      // Tombol-tombol
    public Animator animator;                     // Hanya satu Animator
    public string[] animationTriggers;            // Nama trigger animasi: "Play1", "Play2", "Play3"
    public AudioSource[] sfxSources;              // SFX per langkah
    public ParticleSystem particleEffect;         // Efek akhir

    private int currentIndex = 0;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }

        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
    }

    void OnButtonClicked(int clickedIndex)
    {
        if (clickedIndex == currentIndex)
        {
            // Mainkan animasi berdasarkan trigger sesuai urutan
            if (animator != null && currentIndex < animationTriggers.Length)
            {
                animator.SetTrigger(animationTriggers[currentIndex]);
            }

            // Mainkan SFX
            if (sfxSources != null && currentIndex < sfxSources.Length && sfxSources[currentIndex] != null)
            {
                sfxSources[currentIndex].Play();
            }

            currentIndex++;

            // Semua tombol berhasil diklik dengan urutan benar
            if (currentIndex >= buttons.Length)
            {
                if (particleEffect != null)
                {
                    particleEffect.Play();
                }

                Debug.Log("Semua urutan benar! Efek partikel aktif.");
                currentIndex = 0;
            }
        }
        else
        {
            Debug.Log("Salah urutan! Reset.");
            currentIndex = 0;

            if (particleEffect != null)
            {
                particleEffect.Stop();
            }
        }
    }
}
