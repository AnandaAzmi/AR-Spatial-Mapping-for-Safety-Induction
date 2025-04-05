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
    }
    public void ActivateCanvas()
    {
        gemSimCanvas.SetActive(true);
        step = 0;
        tutorialText.text = tutorialSteps[step];
        nextButton.interactable = true;
        characterAnimator.SetTrigger("Talk");
    }
    void NextStep()
    {
        
            if (step < tutorialSteps.Length - 1)
            {
                step++;
                tutorialText.text = tutorialSteps[step];

                // Debug trigger animasi
                switch (step)
                {
                    case 1:
                        Debug.Log("Trigger: Point");
                        characterAnimator.SetTrigger("Point");
                        break;
                    case 2:
                        Debug.Log("Trigger: Talk");
                        characterAnimator.SetTrigger("Talk");
                        break;
                    case 3:
                        Debug.Log("Trigger: Idle");
                        characterAnimator.SetTrigger("Idle");
                        break;
                    case 4:
                        Debug.Log("Trigger: Excited");
                        characterAnimator.SetTrigger("Excited");
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
}
