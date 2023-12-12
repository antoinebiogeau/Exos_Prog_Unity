using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class souffle : MonoBehaviour
{
    // Déclaration de variables pour l'interface utilisateur et la logique de jeu.
    [SerializeField] private Image BarreUI; // Barre de progression ou de santé.
    [SerializeField] private float max = 100; // Valeur maximale pour la barre.
    [SerializeField] private float cuurent = 100; // Valeur courante de la barre.

    [SerializeField] private GameObject sphere; // La sphère à manipuler.
    [SerializeField] private float inflate; // Quantité d'augmentation de la taille de la sphère.
    [SerializeField] private float deflate; // Quantité de diminution de la taille de la sphère.
    [SerializeField] private float MinSize; // Taille minimale de la sphère.
    [SerializeField] private float MaxSize; // Taille maximale de la sphère.
    [SerializeField] private float CurrentSize; // Taille courante de la sphère.

    [SerializeField] private TextMeshProUGUI TimerUi; // Affichage du timer.
    [SerializeField] private TextMeshProUGUI GameOver; // Texte de fin de jeu.
    [SerializeField] private float TimerReaming = 30f; // Temps restant pour le jeu.
    [SerializeField] private ParticleSystem Blow; // Système de particules pour l'effet de souffle.
    public bool activeR = true; // Indicateur d'activité du jeu.
    
    // Méthode Start appelée au premier frame lorsque le script est activé.
    void Start()
    {
        // Initialisation du texte de fin de jeu à vide.
        GameOver.text = "";
    }

    // Méthode Update appelée une fois par frame.
    void Update()
    {
        // Vérifie si le jeu est actif.
        if (activeR == true)
        {
            // Décompte du temps restant.
            if (TimerReaming > 0)
            {
                TimerReaming -= Time.deltaTime;
            }

            // Mise à jour de l'affichage du temps restant.
            TimerUpdate();

            // Gonflage de la sphère en maintenant la touche Espace.
            if (Input.GetKey(KeyCode.Space))
            {
                breath(0.1f); // Réduit la valeur de la barre.
                CurrentSize += inflate * Time.deltaTime; // Augmente la taille de la sphère.
            }

            // Vérifie si la taille maximale est atteinte pour terminer le jeu.
            if (CurrentSize >= MaxSize)
            {
                activeR = false;
                BlowEffect(); // Active l'effet de particules.
            }

            // Augmente la valeur de la barre si elle est inférieure au maximum.
            if (cuurent < max)
            {
                Breathup(0.05f);
            }

            // Réduction continue de la taille de la sphère.
            CurrentSize -= deflate * Time.deltaTime;
            CurrentSize = Mathf.Clamp(CurrentSize, MinSize, MaxSize); // Garde la taille dans les limites.
            sphere.transform.localScale = new Vector3(CurrentSize, CurrentSize, CurrentSize); // Applique la taille à la sphère.
            updateBar(); // Mise à jour de la barre UI.
        }
        else
        {
            // Affichage du message de fin de jeu.
            GameOver.text = "Game Over";
        } 
    }

    // Méthodes pour gérer la barre de progression.
    private void Breathup(float plus)
    {
        cuurent += plus;
    }
    private void breath(float minus)
    {
        cuurent -= minus;
    }
    private void updateBar()
    {
        BarreUI.fillAmount = cuurent / max;
    }

    // Mise à jour de l'affichage du temps restant.
    private void TimerUpdate()
    {
        int secondes = Mathf.FloorToInt(TimerReaming % 60);
        int ms = Mathf.FloorToInt((TimerReaming - secondes) * 1000);
        TimerUi.text = string.Format("{0:00} : {1:00}", secondes, ms);
    }

    // Méthode pour déclencher l'effet de souffle et finir le jeu.
    private void BlowEffect()
    {
        Debug.Log("pouf particule");
        ParticleSystem instanceParticule = Instantiate(Blow, sphere.transform.position, Quaternion.identity);
        instanceParticule.Play();
        sphere.SetActive(false); // Désactive la sphère.
    }

    // Méthode vide pour une éventuelle condition de victoire.
    private void WinCondition()
    {
    }
}
