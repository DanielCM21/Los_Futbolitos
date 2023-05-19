using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timer = 0f;
    public Text textoTimer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        textoTimer.text = ""+timer.ToString("f0");

        if (timer == 0){
            SceneManager.LoadScene("Game");
        }
    }


}
