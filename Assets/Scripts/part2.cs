using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part2 : MonoBehaviour
{
    public List<ParticleSystem> lesEffetsDeParticules;
    public float delay;
    public GameObject proj;
    private ParticleSystem effetDeParticuleChoisi;
    private bool played = false;

    void Start()
    {
        Invoke(nameof(particuleEffect), Random.Range(delay-1, delay+2));
    }

    private void Update()
    {
        if (effetDeParticuleChoisi != null && effetDeParticuleChoisi.isStopped && played)
        {
            OnDestroy();
        }
    }

    public void particuleEffect()
    {
        if (lesEffetsDeParticules.Count > 0)
        {
            int index = Random.Range(0, lesEffetsDeParticules.Count);
            effetDeParticuleChoisi = lesEffetsDeParticules[index];
            effetDeParticuleChoisi.Play();
            played = true;
        }
    }

    public void OnDestroy()
    {
        Destroy(proj);
    }
}
