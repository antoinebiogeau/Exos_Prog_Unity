using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemGenerator : MonoBehaviour
{
    [Header("Références")]
    public GameObject launcherPrefab;
    [Header("Paramètres")]
    [SerializeField, Range(1, 50)] private int numberOfLauncher;
    [SerializeField, Range(1, 10)] private float DelayToActivate;
    [SerializeField, Range(1, 10)] private float Interval;
    [SerializeField, Range(1, 100)] private float radius;

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
            Vector3 pos = new Vector3(radius * Mathf.Cos(radian), 0, radius * Mathf.Sin(radian)) + transform.position;
            GameObject newLauncher = Instantiate(launcherPrefab, pos, Quaternion.Euler(0, -angle, 0));
            StartCoroutine(ActivateLaucher(newLauncher, Random.Range(1, 10) + DelayToActivate));
            yield return new WaitForSeconds(0);
        }
        generateAndActivateLauncher();
    }

    IEnumerator ActivateLaucher(GameObject launcher, float Delay)
    {
        yield return new WaitForSeconds(Delay);
        launcher.GetComponent<LauncherScript>().Activate();
    }
}