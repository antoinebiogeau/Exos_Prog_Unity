using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EhJeSuisLesParticules : MonoBehaviour
{
    public ParticleSystem LespifpafpoufparticuletropbienGjur�;
    public float delay;
    public GameObject proj;
    private bool played = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(particuleEffect), delay);
    }
    private void Update()
    {
        if (LespifpafpoufparticuletropbienGjur�.isStopped && played == true)
        {
            OnDestroy();
        }
    }

    // Update is called once per frame
    public void particuleEffect()
    {
        LespifpafpoufparticuletropbienGjur�.Play();
        played = true;
        
    }
    public void OnDestroy()
    {
        Destroy(proj);   
    }
}
