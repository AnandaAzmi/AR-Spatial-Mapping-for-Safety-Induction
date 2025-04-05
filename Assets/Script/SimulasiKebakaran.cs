using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimulasiKebakaran : MonoBehaviour
{
    public Button[] buttons;                  // Urutan tombol yang harus diklik
    public ParticleSystem particleEffect;     // Efek partikel yang akan dinyalakan

    private int currentIndex = 0;             // Indeks tombol yang sedang ditunggu

    void Start()
    {
        // Tambahkan listener untuk setiap tombol
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // capture index
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }

        // Pastikan efek partikel mati saat mulai
        if (particleEffect != null)
        {
            particleEffect.Stop();
        }
    }

    void OnButtonClicked(int clickedIndex)
    {
        // Jika tombol yang diklik sesuai urutan
        if (clickedIndex == currentIndex)
        {
            currentIndex++;

            // Jika semua tombol sudah diklik dengan urutan benar
            if (currentIndex >= buttons.Length)
            {
                if (particleEffect != null)
                {
                    particleEffect.Play();
                }

                Debug.Log("Urutan benar! Efek partikel dinyalakan.");
                currentIndex = 0; // Reset kalau ingin bisa dimainkan ulang
            }
        }
        else
        {
            // Salah urutan -> reset
            Debug.Log("Urutan salah! Reset.");
            currentIndex = 0;

            if (particleEffect != null)
            {
                particleEffect.Stop();
            }
        }
    }
}
