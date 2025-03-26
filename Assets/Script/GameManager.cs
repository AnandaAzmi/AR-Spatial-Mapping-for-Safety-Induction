using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GameManager : MonoBehaviour
{
    public VisualEffect gempaVFX;

    private void Start()
    {
        gempaVFX.Stop();
    }
    public void PlayEndVFX()
    {
        if (gempaVFX != null)
        {
            gempaVFX.Play();
        }
    }
}
