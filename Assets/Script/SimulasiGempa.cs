using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SimulasiGempa : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public Button nextButton;
    public GameManager gameManager;

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

    void NextStep()
    {
        if (step < tutorialSteps.Length - 1)
        {
            step++;
            tutorialText.text = tutorialSteps[step];
        }
        else
        {
            nextButton.interactable = false;
            gameManager.PlayEndVFX();
            Destroy(gameObject);
        }
    }
}
