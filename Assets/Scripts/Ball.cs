using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    private GameObject _player;
    private PlayerController playerController;
    void Start(){
        _player = GameObject.FindGameObjectWithTag("player");
        playerController = _player.GetComponent<PlayerController>();
    }

    void Update(){

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            playerController.canShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            playerController.canShoot = false;
        }
    }
}
