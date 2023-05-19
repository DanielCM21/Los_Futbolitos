using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    private GameObject _player;
    private PlayerController playerController;
    Rigidbody2D rigid;
    [SerializeField] private GameObject Cordenadas_ball;
    [SerializeField] private GameObject Cordenadas_PJ1;
    void Start(){
        _player = GameObject.FindGameObjectWithTag("player");
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
            Debug.Log("GOOOL Derecha");
            transform.position = Cordenadas_ball.transform.position;
            playerController.transform.position = Cordenadas_PJ1.transform.position;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0;
        }

        if (collision.gameObject.tag == "Goal_left")
        {
            Debug.Log("GOOOL IZQUIERDA");
            transform.position = Cordenadas_ball.transform.position;
            playerController.transform.position = Cordenadas_PJ1.transform.position;
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "player"){
            playerController.canShoot = false;
        }
    }
}
