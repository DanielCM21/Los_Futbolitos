using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canJump;
    public bool canShoot;
    public float Strong = 200f;
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
        moveH = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(moveH* velocity, rigid.velocity.y );
        if (moveH != 0) animator.SetBool("moving", true);
        else animator.SetBool("moving", false);
        if (!facingRight && moveH > 0) flip();
        if(facingRight && moveH < 0) flip(); 
        if (Input.GetKey("up") && canJump || Input.GetKey("w") && canJump){
            canJump = false;
            rigid.AddForce(new Vector2(0, 150f));
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.transform.tag == "ground"){
            canJump = true;
        }
    }

    public void Shoot(){
        if (Input.GetKeyDown(KeyCode.Space) && canShoot == true){
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2());
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);

    }
}
