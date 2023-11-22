using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EhJeSuisLesParticules : MonoBehaviour
{
    public List<ParticleSystem> lesEffetsDeParticules;
    public float delay;
    public GameObject proj; 

    void Start()
    {
        StartCoroutine(ParticuleEffect(delay));
    }
    public IEnumerator ParticuleEffect(float delay)
    {
        yield return new WaitForSeconds(delay);
        int index = Random.Range(0, lesEffetsDeParticules.Count);
        Debug.Log(index);
        ParticleSystem effetParticule = lesEffetsDeParticules[index];
        ParticleSystem instanceParticule = Instantiate(effetParticule, proj.transform.position, Quaternion.identity);
        PlayAnim(instanceParticule);
    }
    public void PlayAnim(ParticleSystem instanceParticule)
    {
        instanceParticule.Play();
        Destroy(proj);
    }

    //public void particuleEffect()
    //{
    //    if (lesEffetsDeParticules.Count > 0)
    //    {
    //        int index = Random.Range(0, lesEffetsDeParticules.Count);
    //        Debug.Log(index);
    //        ParticleSystem effetParticule = lesEffetsDeParticules[index];
    //        ParticleSystem instanceParticule = Instantiate(effetParticule, proj.transform.position, Quaternion.identity);
    //        instanceParticule.Play();
    //        Destroy(proj);
    //    }
    //}
}