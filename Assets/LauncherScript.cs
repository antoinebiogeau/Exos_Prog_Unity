using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherScript : MonoBehaviour
{
    public GameObject ObjectToLaunch;
    public Vector3 velocity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Activate()
    {
        GameObject LunchObject = Instantiate(ObjectToLaunch, transform.position, Quaternion.identity);

        LunchObject.GetComponent<Rigidbody>().velocity = velocity;


    }
}
