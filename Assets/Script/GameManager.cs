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
    public GameObject fireEffect;
    public GameObject characterNPC;

    public PengenalanK3 pengenalanK3Script;
    public SimulasiGempa simulasiGempaScript;

    private void Start()
    {
        gempaVFX.Stop();
        fireEffect.SetActive(false);

        k3.SetActive(false);
        k3Canvas?.SetActive(false);

        simKeb.SetActive(false);
        simKebCanvas?.SetActive(false);
        characterNPC?.SetActive(false);
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
        characterNPC?.SetActive(true);
        simulasiGempa?.SetActive(true);

        if (simulasiGempaScript != null)
        {
            simulasiGempaScript.ActivateCanvas();
        }

        simKeb?.SetActive(false);
        simKebCanvas?.SetActive(false);
        fireEffect?.SetActive(false);

        k3?.SetActive(false);
        k3Canvas?.SetActive(false);
    }
    public void OnSimKebButtonClicked()
    {

        characterNPC?.SetActive(false);
        simKeb?.SetActive(true);
        simKebCanvas?.SetActive(true);
        fireEffect?.SetActive(true);
        simulasiGempa?.SetActive(false);

        gempaVFX.Stop();

        k3?.SetActive(false);
        k3Canvas?.SetActive(false);
    }
    public void OnK3ButtonClicked()
    {
        simulasiGempa?.SetActive(false);
        gempaVFX.Stop();
        simKeb?.SetActive(false);
        simKebCanvas?.SetActive(false);
        fireEffect?.SetActive(false);
        characterNPC?.SetActive(true);
        k3?.SetActive(true);
        k3Canvas?.SetActive(true);

        if (pengenalanK3Script != null)
        {
            pengenalanK3Script.ActivateCanvas();
        }
        
    }
}
