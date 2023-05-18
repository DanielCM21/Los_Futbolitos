using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{   
    Rigidbody2D rigid;
    public float Strong = 20f;
    bool kicked = false;
    void Start(){
        rigid = GetComponent<Rigidbody2D>();
    }
    void Update(){
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position, Vector2.right, 0.5f);
        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, Vector2.left, 0.5f);
        
        if(hitRight.collider != null) {
            rigid.AddForce(new Vector2(0, -Strong), ForceMode2D.Impulse);
        }
        
        //if(hitLeft.collider != null || hitRight.collider != null) Debug.Log("Entró");
        if(hitLeft.collider != null) {
            rigid.AddForce(new Vector2(0, Strong), ForceMode2D.Impulse);      
        }    
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("patada")){
            kicked = true;  
            Debug.Log("Entró X2") ; 
        }
    }
}
