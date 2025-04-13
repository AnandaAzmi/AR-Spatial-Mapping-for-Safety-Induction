using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameManager gameManager;
    public GameObject simulasiGempa;
    public GameObject blezzy;
    public GameObject persistanceUI;
    public GameObject menuUI;
    // Start is called before the first frame update
    private void Start()
    {
        simulasiGempa?.SetActive(false);
        blezzy?.SetActive(false);
        persistanceUI?.SetActive(false);
        menuUI?.SetActive(false);
    }
    public void PlayButton()
    {
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(false);
        }
        persistanceUI.SetActive(true);
        simulasiGempa.SetActive(true);
        menuUI.SetActive(true);
        gameManager.OnSimGemButtonClicked();
    }
    public void ExitButton()
    {
        if (mainMenuCanvas != null)
        {
            Application.Quit();
        }
    }
}
