
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ChatTutorial : MonoBehaviour
{
    public TextMeshProUGUI tutorialText;
    public Button nextButton;

    private string[] tutorialSteps = new string[]
    {
        "Halo! Nama saya Blazey, pemandu keselamatanmu hari ini. Kita akan belajar bagaimana melakukan evakuasi dengan aman dan cepat! Siap memulai?",

        "Di depanmu sudah ada peralatan keselamatan yang harus kamu ketahui! Ikuti baik baik ya.. ",

        "Lihatlah benda yang warna merah itu !! ",
        "Ini adalah APAR (Alat Pemadam Api Ringan). " +
        "Jika terjadi kebakaran kecil, gunakan APAR dengan teknik T.A.T.S.: " +
        "Tarik pin, Arahkan ke api, Tekan tuas, dan Semprotkan secara menyapu.",

        "Apa kau lihat ada helm??",
        "Ini helm pengaman K3, digunakan untuk melindungi kepala dari benda jatuh atau benturan. " +
        "Pastikan helm selalu terpasang dengan benar sebelum memasuki area berisiko.",

        "Ada satu lagi, kamu melihat sesuatu yang berbentuk seperti topeng??",
        "Saat ada asap tebal atau udara tercemar, gunakan masker pernapasan ini untuk melindungi saluran pernapasanmu. " +
        "Pastikan masker terpasang erat dan bernapas melalui filter yang tersedia.",

        "Bagus! Sekarang kita lanjut ke langkah berikutnya, Kali ini akan berbahaya lho..",
        "Ada beberapa hal yang harus kamu lakukan",
        "Jangan Panik, Selalu cari jalur evakuasi terdekat!" +
        "Jangan gunakan lift, selalu gunakan tangga darurat! ",
        "Untuk menemukan jalan keluar dengan cepat, kamu bisa memilih navigasi target yang tepat!",
        "Ayo, seberapa cepat kamu bisa keluar? Waktu mulai dari sekarang"
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
            Destroy(gameObject);
        }
    }
}
