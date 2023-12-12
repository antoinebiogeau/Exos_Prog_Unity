using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Définition d'une classe publique qui hérite de MonoBehaviour, pour pouvoir l'attacher à un GameObject dans Unity.
public class EhJeSuisLesParticules : MonoBehaviour
{
    // Liste publique de ParticleSystem, permettant de définir différents systèmes de particules dans l'éditeur Unity.
    public List<ParticleSystem> lesEffetsDeParticules;

    // Variable publique pour définir un délai avant le lancement de l'effet de particules.
    public float delay;

    // Référence à un GameObject, probablement l'objet qui émettra les particules.
    public GameObject proj; 

    // Méthode Start appelée au premier frame lorsque le script est activé.
    void Start()
    {
        // Démarre une coroutine qui gère l'effet de particules.
        StartCoroutine(ParticuleEffect(delay));
    }

    // Définition d'une coroutine pour gérer l'effet de particules avec un délai.
    public IEnumerator ParticuleEffect(float delay)
    {
        // Attend le nombre de secondes défini par 'delay'.
        yield return new WaitForSeconds(delay);

        // Sélectionne un index aléatoire parmi les systèmes de particules disponibles.
        int index = Random.Range(0, lesEffetsDeParticules.Count);
        Debug.Log(index);

        // Récupère le système de particules à l'index sélectionné.
        ParticleSystem effetParticule = lesEffetsDeParticules[index];

        // Crée une instance du système de particules à la position de 'proj'.
        ParticleSystem instanceParticule = Instantiate(effetParticule, proj.transform.position, Quaternion.identity);

        // Oriente l'instance du système de particules.
        instanceParticule.transform.Rotate(90, 0, 0);

        // Joue l'animation du système de particules.
        PlayAnim(instanceParticule);
    }

    // Méthode pour jouer l'animation du système de particules et détruire le GameObject 'proj'.
    public void PlayAnim(ParticleSystem instanceParticule)
    {
        // Démarre le système de particules.
        instanceParticule.Play();

        // Détruit le GameObject 'proj'.
        Destroy(proj);
    }

    // Code commenté - une autre façon de gérer l'effet de particules sans coroutine ni délai.
    //public void particuleEffect()
    //{
    //    if (lesEffetsDeParticules.Count > 0)
    //    {
    //        int index = Random.Range(0, lesEffetsDeParticules.Count);
    //        Debug.Log(index);
    //        ParticleSystem effetParticule = lesEffetsDeParticules[index];
    //        ParticleSystem instanceParticule = Instantiate(effetParticule, proj.transform.position, Quaternion.identity);
    //        instanceParticule.Play();
    //        Destroy(proj);
    //    }
    //}
}
