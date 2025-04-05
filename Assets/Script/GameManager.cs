using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public VisualEffect gempaVFX;
    public GameObject simulasiGempa;
    public GameObject k3;
    public GameObject k3Canvas;
    public GameObject simKeb;
    public GameObject simKebCanvas;

    public PengenalanK3 pengenalanK3Script;
    public SimulasiGempa simulasiGempaScript;

    private void Start()
    {
        gempaVFX.Stop();

        k3.SetActive(false);
        k3Canvas?.SetActive(false);

        simKeb.SetActive(false);
        simKebCanvas?.SetActive(false);
    }
    public void PlayEndVFX()
    {
        if (gempaVFX != null)
        {
            gempaVFX.Play();
        }
        
    }
    public void OnSimGemButtonClicked()
    {
        simulasiGempa?.SetActive(true);

        if (simulasiGempaScript != null)
        {
            simulasiGempaScript.ActivateCanvas();
        }

        simKeb?.SetActive(false);
        simKebCanvas?.SetActive(false);

        k3?.SetActive(false);
        k3Canvas?.SetActive(false);
    }
    public void OnSimKebButtonClicked()
    {
        simKeb?.SetActive(true);
        simKebCanvas?.SetActive(true);

        simulasiGempa?.SetActive(false);
        
        k3?.SetActive(false);
        k3Canvas?.SetActive(false);
    }
    public void OnK3ButtonClicked()
    {
        k3?.SetActive(true);
        k3Canvas?.SetActive(true);

        if (pengenalanK3Script != null)
        {
            pengenalanK3Script.ActivateCanvas();
        }
        simulasiGempa?.SetActive(false);
        
        simKeb?.SetActive(false);
        simKebCanvas?.SetActive(false);
    }
}
