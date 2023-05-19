using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    [SerializeField] int min, seg;
    [SerializeField] Text tiempo;

    private float restante;
    private bool corriendo;

    private void Awake()
    {
        restante = (min * 60) + seg;
        corriendo = true;
    }



    // Update is called once per frame
    void Update()
    {
        if (corriendo)
        {
            restante -= Time.deltaTime;
            if (restante < 1)
            {
                corriendo = true;
                //reiniciar el juego
            }
            int tempMin = Mathf.FloorToInt(restante / 60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{0:00}:{1:00}", tempMin, tempSeg);
        }
    }
}