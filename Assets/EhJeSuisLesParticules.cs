using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class EhJeSuisLesParticules : MonoBehaviour
{
    public ParticleSystem LespifpafpoufparticuletropbienGjuré;
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
        if (LespifpafpoufparticuletropbienGjuré.isStopped && played == true)
        {
            OnDestroy();
        }
    }

    // Update is called once per frame
    public void particuleEffect()
    {
        LespifpafpoufparticuletropbienGjuré.Play();
        played = true;
        
    }
    public void OnDestroy()
    {
        Destroy(proj);   
    }
}
