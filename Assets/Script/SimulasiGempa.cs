using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Animations;

public class SimulasiGempa : MonoBehaviour
{
    public GameObject gemSimCanvas;
    public TextMeshProUGUI tutorialText;
    public Button nextButton;
    public GameManager gameManager;
    public Animator characterAnimator;

    public AudioSource audioSource;
    public AudioClip[] dubbingClips;

    private string[] tutorialSteps = new string[]
    {
        "Halo! Nama saya Blazey, pemandu keselamatanmu hari ini. Kita akan belajar bagaimana melakukan evakuasi dengan aman dan cepat! Siap memulai?",
        "Ada beberapa hal yang harus kamu lakukan",
        "Jangan Panik, Selalu cari jalur evakuasi terdekat!" +
        "Jangan gunakan lift, selalu gunakan tangga darurat! ",
        "Untuk menemukan jalan keluar dengan cepat, kamu bisa memilih navigasi target yang tepat!",
        "Ayo, seberapa cepat kamu bisa keluar? Waktu mulai dari sekarang!"
    };

    private int step = 0;

    void Start()
    {
        tutorialText.text = tutorialSteps[step];
        nextButton.onClick.AddListener(NextStep);
        PlayDubbing(step);
    }
    public void ActivateCanvas()
    {
        gemSimCanvas.SetActive(true);
        step = 0;
        tutorialText.text = tutorialSteps[step];
        PlayDubbing(step);

        nextButton.interactable = true;
        characterAnimator.SetTrigger("GM1");
    }
    void NextStep()
    {
        
            if (step < tutorialSteps.Length - 1)
            {
                step++;
                tutorialText.text = tutorialSteps[step];
                PlayDubbing(step);

            // Debug trigger animasi
            switch (step)
                {
                    case 1:
                        Debug.Log("Trigger: GM3");
                        characterAnimator.SetTrigger("GM3");
                        break;
                    case 2:
                        Debug.Log("Trigger: GM4");
                        characterAnimator.SetTrigger("GM4");
                        break;
                    case 3:
                        Debug.Log("Trigger: GM5");
                        characterAnimator.SetTrigger("GM5");
                        break;
                    case 4:
                        Debug.Log("Trigger: GM6");
                        characterAnimator.SetTrigger("GM6");
                        break;
            }
            }
            else
            {
                nextButton.interactable = false;
                gameManager.PlayEndVFX();
                gemSimCanvas.SetActive(false);
            }
        
    }
    void PlayDubbing(int index)
    {
        Debug.Log("Playing dubbing step: " + index);

        if (dubbingClips != null && index < dubbingClips.Length && dubbingClips[index] != null)
        {
            audioSource.Stop();
            audioSource.clip = dubbingClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip missing or null at index: " + index);
        }
    }
}
