using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    private GameObject _player;
    void Start(){
        _player = GameObject.FindGameObjectWithTag("player");
    }

    void Update(){
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            _player.GetComponent<PlayerController>().canShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            _player.GetComponent<PlayerController>().canShoot = false;
        }
    }
}
