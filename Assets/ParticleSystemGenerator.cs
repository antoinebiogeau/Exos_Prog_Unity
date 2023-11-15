using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemGenerator : MonoBehaviour
{
    [Header("references")]
    public GameObject launcherPrefab;
    [Header("parametre")]
    [SerializeField, Range(1, 10)] private int numberOfLauncher;
    [SerializeField, Range(1, 10)] private float DelayToActivate;
    [SerializeField, Range(1, 10)] private float Interval;
    [SerializeField, Range(1, 10)] private float xSpacing;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(generateAndActivateLauncher());
    }
    void Update()
    {
        
    }
    IEnumerator generateAndActivateLauncher()
    {
        for(int i = 0; i<= numberOfLauncher; i++)
        {
            Vector3 pos = new Vector3(transform.position.x + i * xSpacing, transform.position.y + transform.position.z);
            GameObject newLauncher = Instantiate(launcherPrefab, pos, Quaternion.identity);
            StartCoroutine(ActivateLaucher(newLauncher,Random.Range(1,10)+DelayToActivate));
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
