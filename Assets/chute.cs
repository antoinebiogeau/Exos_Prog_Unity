using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class chute : MonoBehaviour
{
    public float delayBeforeStart = 1f; 
    public float intervalBetweenFalls = 1f; 
    public Vector3 endPosition; 
    public float fallDuration = 0.5f;
    private bool r = false;

    private void Start()
    {
        endPosition.x = transform.position.x;
        endPosition.z = transform.position.z;
    }
    public void Update()
    {
        if (r)
        {
            this.GetComponent<LauncherScript>().Activate();
            r = false;
        }
    }

    public IEnumerator Fall()
    {
        float timer = 0;

        Vector3 startPosition = transform.position;

        while (timer < fallDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, (timer / fallDuration));
            timer += Time.deltaTime;
            yield return null;
        }
        r = true;
        
    }
}
