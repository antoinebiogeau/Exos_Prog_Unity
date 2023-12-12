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
        //on initialise les positions de fin pour la chute 
        endPosition.x = transform.position.x;
        endPosition.z = transform.position.z;
    }
    public void Update()
    {
        //on check si la chute est fini avec la variable r j'ai mit r jsp pourquoi mais en gros ca fait r si c'est pas fini
        if (r)
        {
            this.GetComponent<LauncherScript>().Activate();
            r = false;
        }
    }

    public IEnumerator Fall()
    {
        //ici c'est la chute donc on a un timer avec un vecteur start position ou on donne la position de debut et avec le lerp ligne 38 on le fait aller a la fin 
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
