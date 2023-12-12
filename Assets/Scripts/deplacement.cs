using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplacement : MonoBehaviour
{
    public Transform target; 
    private Vector3 startPosition;
    public float speed = 1.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(startPosition, target.position, (Mathf.Sin(Time.time * speed) + 1) / 2);
    }
}
