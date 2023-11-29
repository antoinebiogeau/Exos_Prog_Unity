using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemGenerator : MonoBehaviour
{
    [Header("Références")]
    public GameObject launcherPrefab;
    [Header("Paramètres")]
    [SerializeField, Range(1, 50)] private int numberOfLauncher;
    [SerializeField] private float DelayToActivate;
    [SerializeField, Range(1, 10)] private float Interval;
    [SerializeField, Range(1, 100)] private float radius;
    public List<GameObject> lespics;
    [SerializeField] private float posy;

    void Start()
    {
        StartCoroutine(generateAndActivateLauncher());

    }

    IEnumerator generateAndActivateLauncher()
    {
        float angleStep = 360.0f / numberOfLauncher;

        for (int i = 0; i < numberOfLauncher; i++)
        {
            float angle = i * angleStep;
            float radian = angle * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(radius * Mathf.Cos(radian), posy, radius * Mathf.Sin(radian)) + transform.position;
            GameObject newLauncher = Instantiate(launcherPrefab, pos, Quaternion.Euler(0, -angle, 0));
            lespics.Add(newLauncher);
            yield return new WaitForSeconds(0);

        }

        StartCoroutine(Chute(lespics, DelayToActivate));
        //StartCoroutine(ActivateLaucher(lespics, DelayToActivate));
    }
    IEnumerator Chute(List<GameObject> lespics, float Delay)
    {
        for(int i = 0; i< lespics.Count; i++)
        {
            StartCoroutine(lespics[i].GetComponent<chute>().Fall());
            yield return new WaitForSeconds(Delay);
        }   
    }

    //IEnumerator ActivateLaucher(List<GameObject> lespics, float Delay)
    //{
    //    for (int i = 0; i < lespics.Count; i++)
    //    {
    //        lespics[i].GetComponent<LauncherScript>().Activate();
    //        yield return new WaitForSeconds(Delay);
    //    }
}