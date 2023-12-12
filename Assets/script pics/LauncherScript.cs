using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

// Crée une classe publique qui hérite de MonoBehaviour pour être attachée à un GameObject dans Unity.
public class LauncherScript : MonoBehaviour
{
    // Déclaration des variables publiques.
    public GameObject ObjectToLaunch; // L'objet à lancer.
    public Vector3 velocity; // Vitesse de lancement (non utilisée dans ce script).
    public Vector3 init; // Position initiale de l'objet à lancer.
    public Vector3 max; // Position maximale atteinte par l'objet lancé.

    // Méthode Start appelée au premier frame lorsque le script est activé.
    void Start()
    {
        // Initialisation de la position initiale avec la position actuelle de l'objet à lancer.
        init = ObjectToLaunch.transform.position;
    }

    // Méthode Update appelée une fois par frame.
    void Update()
    {
        // Actuellement vide, pourrait être utilisée pour des mises à jour continues.
    }

    // Coroutine pour gérer le déplacement de l'objet.
    public IEnumerator Depl(float duration, Vector3 init, Vector3 max)
    {
        // Crée une instance de l'objet à lancer à la position du lanceur.
        GameObject LunchObject = Instantiate(ObjectToLaunch, transform.position, Quaternion.identity);
        LunchObject.transform.Rotate(90,0,0); // Rotation de l'objet.

        float timer = 0;
        // Boucle pour interpoler la position de l'objet à lancer.
        while(timer < duration)
        {
            timer += Time.deltaTime;
            // Interpolation linéaire de la position de l'objet entre init et max.
            ObjectToLaunch.transform.position = math.lerp(init, max, timer / duration);
            yield return new WaitForEndOfFrame(); // Attend la fin de la frame.
        }
    }

    // Méthode pour activer le lancement.
    public void Activate()
    {
        // Réinitialisation de la position initiale.
        init = ObjectToLaunch.transform.position;

        // Démarre la coroutine pour le déplacement avec une durée fixée.
        StartCoroutine(Depl(3f, init, max));

        // Code commenté qui pourrait être utilisé pour appliquer une vélocité à un Rigidbody.
        //LunchObject.GetComponent<Rigidbody>().velocity = velocity;
    }
}
