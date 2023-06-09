using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Netcode;

public class Ball : NetworkBehaviour
{   
    public GameObject _player;
    private PlayerController playerController;
    Rigidbody2D rigid;
    [SerializeField] private GameObject Cordenadas_ball;
    [SerializeField] private GameObject Cordenadas_PJ1;
    [SerializeField] private Marcadores Marcador_derecha;
    [SerializeField] private Marcadores Marcador_izquierda;
    void Start(){
        
        playerController = _player.GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();

    }

    void Update(){

    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            playerController.canShoot = true;
        }
        if (collision.gameObject.tag == "Goal_right"){
            transform.position = Cordenadas_ball.transform.position;
            playerController.transform.position = Cordenadas_PJ1.transform.position;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0;
            Marcador_derecha.SumarPuntaje();
        }

        if (collision.gameObject.tag == "Goal_left")
        {

            transform.position = Cordenadas_ball.transform.position;
            playerController.transform.position = Cordenadas_PJ1.transform.position;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0;
            Marcador_izquierda.SumarPuntaje();
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            playerController.canShoot = false;
        }
    }
}
