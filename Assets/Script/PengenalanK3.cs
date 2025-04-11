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

    public AudioSource audioSource;
    public AudioClip[] dubbingClips;

    public GameObject aparObject;
    public GameObject helmObject;
    public GameObject maskerObject;


    private string[] tutorialSteps = new string[]
    {
        "Di depanmu sudah ada peralatan keselamatan yang harus kamu ketahui! Ikuti baik baik ya..",
        "Lihatlah benda yang warna merah itu !!",//di bagian ini hanya munculkan objek APAR
        "Ini adalah APAR (Alat Pemadam Api Ringan)." +
        "Jika terjadi kebakaran kecil, gunakan APAR dengan teknik T.A.T.S.",
        "Tarik pin, Arahkan ke api, Tekan tuas, dan Semprotkan secara menyapu.",
        "Apa kau lihat ada helm??",//disini munculkan objek helm, disable objek lain
        "Ini helm pengaman K3, digunakan untuk melindungi kepala dari benda jatuh atau benturan.",
        "Ada satu lagi, kamu melihat sesuatu yang berbentuk seperti topeng??",//disini munculkan masker, disable objek lainnya
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
        aparObject?.SetActive(false);
        helmObject?.SetActive(false);
        maskerObject?.SetActive(false);
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
        PlayDubbing(step);
        nextButton.interactable = true;
        characterAnimator.SetTrigger("PA1"); // Animasi pertama dijalankan langsung

        aparObject?.SetActive(true);
        helmObject?.SetActive(true);
        maskerObject?.SetActive(true);
    }

    void NextStep()
    {
        if (step < tutorialSteps.Length - 1)
        {
            step++;
            tutorialText.text = tutorialSteps[step];
            PlayDubbing(step);

            switch (step)
            {
                case 1:
                    Debug.Log("Trigger: PA4");
                    characterAnimator.SetTrigger("PA4");
                    break;
                case 2:
                    Debug.Log("Trigger: PA3");
                    characterAnimator.SetTrigger("PA3");
                    break;
                case 3:
                    Debug.Log("Trigger: PA4");
                    characterAnimator.SetTrigger("PA4");
                    break;
                case 4:
                    Debug.Log("Trigger: PA5");
                    characterAnimator.SetTrigger("PA5");
                    break;
                case 5:
                    characterAnimator.SetTrigger("PA6");
                    break;
                case 6:
                    characterAnimator.SetTrigger("PA7");
                    break;
                case 7:
                    characterAnimator.SetTrigger("PA8");
                    break;
            }

            switch (step)
            {
                case 1: // Munculkan APAR
                    aparObject?.SetActive(true);
                    helmObject?.SetActive(false);
                    maskerObject?.SetActive(false);
                    break;

                case 4: // Munculkan Helm
                    aparObject?.SetActive(false);
                    helmObject?.SetActive(true);
                    maskerObject?.SetActive(false);
                    break;

                case 6: // Munculkan Masker
                    aparObject?.SetActive(false);
                    helmObject?.SetActive(false);
                    maskerObject?.SetActive(true);
                    break;
            }
        }
        else
        {
            nextButton.interactable = false;
            tutorialCanvas.gameObject.SetActive(false);
            aparObject?.SetActive(false);
            helmObject?.SetActive(false);
            maskerObject?.SetActive(false);
        }
    }
    void PlayDubbing(int index)
    {
        Debug.Log("Play dubbing for step: " + index);

        if (dubbingClips != null && index < dubbingClips.Length && dubbingClips[index] != null)
        {
            audioSource.Stop();
            audioSource.clip = dubbingClips[index];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Dubbing clip missing at step: " + index);
        }
    }
}
