using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PengenalanK3 : MonoBehaviour
{
    public Canvas tutorialCanvas;
    public TextMeshProUGUI tutorialText;
    public Button nextButton;
    public Animator characterAnimator;

    private string[] tutorialSteps = new string[]
    {
        "Di depanmu sudah ada peralatan keselamatan yang harus kamu ketahui! Ikuti baik baik ya..",
        "Lihatlah benda yang warna merah itu !!",
        "Ini adalah APAR (Alat Pemadam Api Ringan)." +
        "Jika terjadi kebakaran kecil, gunakan APAR dengan teknik T.A.T.S.",
        "Tarik pin, Arahkan ke api, Tekan tuas, dan Semprotkan secara menyapu.",
        "Apa kau lihat ada helm??",
        "Ini helm pengaman K3, digunakan untuk melindungi kepala dari benda jatuh atau benturan.",
        "Ada satu lagi, kamu melihat sesuatu yang berbentuk seperti topeng??",
        "Saat ada asap tebal atau udara tercemar, gunakan masker pernapasan ini untuk melindungi saluran pernapasanmu. " +
        "Pastikan masker terpasang erat dan bernapas melalui filter yang tersedia.",
    };

    private int step = 0;

    void Start()
    {
        // Nonaktifkan canvas di awal
        if (tutorialCanvas != null)
        {
            tutorialCanvas.gameObject.SetActive(false);
        }

        // Tambahkan listener untuk tombol
        nextButton.onClick.AddListener(NextStep);
    }

    // Fungsi ini bisa dipanggil dari GameManager atau trigger lain
    public void ActivateCanvas()
    {
        if (tutorialCanvas != null)
        {
            tutorialCanvas.gameObject.SetActive(true);
        }

        step = 0;
        tutorialText.text = tutorialSteps[step];
        nextButton.interactable = true;
        characterAnimator.SetTrigger("Talk"); // Animasi pertama dijalankan langsung
    }

    void NextStep()
    {
        if (step < tutorialSteps.Length - 1)
        {
            step++;
            tutorialText.text = tutorialSteps[step];

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
            tutorialCanvas.gameObject.SetActive(false);
        }
    }
}
