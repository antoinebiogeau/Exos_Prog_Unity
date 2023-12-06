using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class souffle : MonoBehaviour
{
    [SerializeField] private Image BarreUI;
    [SerializeField] private float max = 100;
    [SerializeField] private float cuurent = 100;

    [SerializeField] private GameObject sphere;
    [SerializeField] private float inflate;
    [SerializeField] private float deflate;
    [SerializeField] private float MinSize;
    [SerializeField] private float MaxSize;
    [SerializeField] private float CurrentSize;

    [SerializeField] private TextMeshProUGUI TimerUi;
    [SerializeField] private TextMeshProUGUI GameOver;
    [SerializeField] private float TimerReaming = 30f;
    [SerializeField] private ParticleSystem Blow;
    public bool activeR = true;
    



    // Start is called before the first frame update
    void Start()
    {
        GameOver.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (activeR == true)
        {
            if (TimerReaming > 0)
            {
                TimerReaming -= Time.deltaTime;

            }
            TimerUpdate();
            if (Input.GetKey(KeyCode.Space))
            {
                breath(0.1f);
                CurrentSize += inflate * Time.deltaTime;
            }
            if (CurrentSize >= MaxSize)
            {
                activeR = false;
                BlowEffect();
            }
            if (cuurent < max)
            {
                Breathup(0.05f);
            }
            CurrentSize -= deflate * Time.deltaTime;
            CurrentSize = Mathf.Clamp(CurrentSize, MinSize, MaxSize);
            sphere.transform.localScale = new Vector3(CurrentSize, CurrentSize, CurrentSize);
            updateBar();
        }
        else
        {
            GameOver.text = "Game Over";
        } 
    }
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
    private void TimerUpdate()
    {
        int secondes = Mathf.FloorToInt(TimerReaming % 60);
        int ms = Mathf.FloorToInt((TimerReaming - secondes) * 1000);
        TimerUi.text = string.Format("{0:00} : {1:00}", secondes, ms);

    }
    private void BlowEffect()
    {
        
        Debug.Log("pouf particule");
        ParticleSystem instanceParticule = Instantiate(Blow, sphere.transform.position, Quaternion.identity);
        instanceParticule.Play();
        sphere.SetActive(false);
        
    }
    private void WinCondition()
    {

    }
}
