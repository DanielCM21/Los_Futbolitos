using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerController : NetworkBehaviour 
{
    // Start is called before the first frame update
    public bool canJump;
    public bool canShoot;
    public float Strong = 0.4f;
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer sprite;
    [SerializeField] float velocity;
    float moveH;
    bool facingRight = true;
    private GameObject _ball;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        _ball = GameObject.FindGameObjectWithTag("ball");
    }

    // Update is called once per frame
    void Update(){

        //if (!IsOwner) return;

        moveH = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveH * velocity, rigid.velocity.y );
        if (moveH != 0) animator.SetBool("moving", true);
        else animator.SetBool("moving", false);
        if (!facingRight && moveH > 0) flip();
        if(facingRight && moveH < 0) flip(); 
        if (Input.GetKey("up") && canJump || Input.GetKey("w") && canJump){
            canJump = false;
            rigid.AddForce(new Vector2(0, 150f));
        }
        if (Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.X)) {
            animator.SetBool("kick", true);
            } else animator.SetBool("kick", false);

        if (Input.GetKeyDown(KeyCode.C)){
        ShootA();
        }
        if (Input.GetKeyDown(KeyCode.X)){
        ShootB();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "ground"){
            canJump = true;
        }
    }

    public void ShootA(){
        if (canShoot == true && transform.position.x<_ball.transform.position.x){
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Strong/2, Strong), ForceMode2D.Impulse);
        }else if (canShoot == true && transform.position.x>_ball.transform.position.x){
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Strong/2, Strong), ForceMode2D.Impulse);
        }
    }

    public void ShootB(){
        if (canShoot == true && transform.position.x<_ball.transform.position.x){
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(Strong/2, 0), ForceMode2D.Impulse);
        }else if (canShoot == true && transform.position.x>_ball.transform.position.x){
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Strong/2, 0), ForceMode2D.Impulse);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }
}
