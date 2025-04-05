using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHitDestroy : MonoBehaviour
{
    void OnParticleCollision(GameObject other)
    {
        // Hanya lanjut jika objek yang terkena bertag "Fire"
        if (other.CompareTag("Fire"))
        {
            StartCoroutine(DestroyAfterDelay(other, 3f));
        }
    }

    IEnumerator DestroyAfterDelay(GameObject target, float delay)
    {
        Debug.Log("Objek 'Fire' terkena partikel. Akan dihancurkan dalam 3 detik: " + target.name);
        yield return new WaitForSeconds(delay);

        if (target != null)
        {
            target.SetActive(false);
        }
    }
}
