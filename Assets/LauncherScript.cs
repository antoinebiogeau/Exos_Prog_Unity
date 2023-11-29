using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public GameObject ObjectToLaunch;
    public Vector3 velocity;
    public Vector3 init;
    public Vector3 max;
    // Start is called before the first frame update
    void Start()
    {

        init = ObjectToLaunch.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Depl(float duration, Vector3 init, Vector3 max)
    {
        GameObject LunchObject = Instantiate(ObjectToLaunch, transform.position, Quaternion.identity);
        LunchObject.transform.Rotate(90,0,0);
        float timer = 0;
        while(timer < duration)
        {
            timer += Time.deltaTime;
            ObjectToLaunch.transform.position = math.lerp(init, max, timer / duration);
            yield return new WaitForEndOfFrame();

        }
        
    }
    public void Activate()
    {
        init = ObjectToLaunch.transform.position;
        StartCoroutine(Depl(3f, init, max));
        
        //

        //LunchObject.GetComponent<Rigidbody>().velocity = velocity;


    }
}
