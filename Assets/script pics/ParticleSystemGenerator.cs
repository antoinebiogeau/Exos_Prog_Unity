using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Crée une classe publique qui hérite de MonoBehaviour pour être attachée à un GameObject dans Unity.
public class ParticleSystemGenerator : MonoBehaviour
{
    // Déclarations de variables et réglages visibles dans l'éditeur Unity.
    [Header("Références")]
    public GameObject launcherPrefab; // Préfabriqué pour le lanceur de particules.

    [Header("Paramètres")]
    [SerializeField, Range(1, 50)] private int numberOfLauncher; // Nombre de lanceurs à générer.
    [SerializeField] private float DelayToActivate; // Délai pour activer chaque lanceur.
    [SerializeField, Range(1, 10)] private float Interval; // Interval non utilisé dans ce script.
    [SerializeField, Range(1, 100)] private float radius; // Rayon pour positionner les lanceurs autour de l'objet.
    public List<GameObject> lespics; // Liste pour stocker les lanceurs générés.
    [SerializeField] private float posy; // Position Y pour les lanceurs.

    // Méthode Start appelée au premier frame lorsque le script est activé.
    void Start()
    {
        // Commence une coroutine pour générer et activer les lanceurs.
        StartCoroutine(generateAndActivateLauncher());
    }

    // Coroutine pour générer et activer les lanceurs.
    IEnumerator generateAndActivateLauncher()
    {
        // Calcul de l'angle de séparation entre chaque lanceur.
        float angleStep = 360.0f / numberOfLauncher;

        // Boucle pour créer chaque lanceur.
        for (int i = 0; i < numberOfLauncher; i++)
        {
            // Calcul de la position du lanceur basé sur un cercle.
            float angle = i * angleStep;
            float radian = angle * Mathf.Deg2Rad;
            Vector3 pos = new Vector3(radius * Mathf.Cos(radian), posy, radius * Mathf.Sin(radian)) + transform.position;

            // Création d'une instance du lanceur et ajout à la liste.
            GameObject newLauncher = Instantiate(launcherPrefab, pos, Quaternion.Euler(0, -angle, 0));
            lespics.Add(newLauncher);

            // Attente optionnelle entre la création de chaque lanceur.
            yield return new WaitForSeconds(0);
        }

        // Commence une autre coroutine pour activer les lanceurs avec un délai.
        StartCoroutine(Chute(lespics, DelayToActivate));
        // Ligne commentée pour une méthode alternative d'activation.
        //StartCoroutine(ActivateLaucher(lespics, DelayToActivate));
    }

    // Coroutine pour activer les lanceurs avec un délai.
    IEnumerator Chute(List<GameObject> lespics, float Delay)
    {
        // Parcourt la liste des lanceurs pour les activer.
        for(int i = 0; i< lespics.Count; i++)
        {
            // Active la méthode 'Fall' sur le composant 'chute' de chaque lanceur.
            StartCoroutine(lespics[i].GetComponent<chute>().Fall());
            // Attente avant d'activer le lanceur suivant.
            yield return new WaitForSeconds(Delay);
        }   
    }

    // Coroutine commentée pour une méthode alternative d'activation.
    //IEnumerator ActivateLaucher(List<GameObject> lespics, float Delay)
    //{
    //    for (int i = 0; i < lespics.Count; i++)
    //    {
    //        lespics[i].GetComponent<LauncherScript>().Activate();
    //        yield return new WaitForSeconds(Delay);
    //    }
    //}
}
