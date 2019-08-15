using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    bool isFacingRight;
    float move;
    float jump;
    public float jumpStrength = 10f;
    public float speed = 2f;
    Animator anim;
    Rigidbody2D rb;
    RaycastHit2D groundRay;
    public LayerMask groundMask;
    public float rayLength = 1f;
    BoxCollider2D weapon;
    public float attackValue = 10;
    HealthScript hlth;
    AttackScript attack;
    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
        //groundMask = 18;
        weapon = gameObject.GetComponentInChildren<BoxCollider2D>();
        if (weapon)
        {
            Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), weapon);
        }
        hlth = gameObject.GetComponent<HealthScript>();
        attack = gameObject.GetComponent<AttackScript>();
	}
	
	// Update is called once per frame
	void Update () {

        move = Input.GetAxis("Horizontal");
        jump = Input.GetAxis("Vertical");

        //        Vector2 mov = new Vector2(move * speed , rb.velocity.y);
        if (move > 0 && isFacingRight) {
            
            Flip();
        }else if (move<0 && !isFacingRight){
            Flip();
        }
        anim.SetFloat("move", Mathf.Abs(move));
        rb.velocity = new Vector2(move * speed, rb.velocity.y);
        anim.SetFloat("jump", rb.velocity.y);


        if (Input.GetKeyDown(KeyCode.J)) {
            //anim.SetTrigger("attack");
            attack.AttackExecute();
            //Attack();
        }


        if (isGrounded())
        {
            anim.SetBool("isGrounded", true);
            if (jump > 0.1)
            {
               
                rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            }
        }
        else {
            anim.SetBool("isGrounded", false);
        }
        


       // rb.AddForce(new Vector2(0,jump*jumpStrength));



	}

   public void Attack(GameObject targ) {
        targ.GetComponent<HealthScript>().GetDamage(attackValue);
    }

    void Flip() {
        isFacingRight = !isFacingRight;
        gameObject.transform.localScale = new Vector3(-this.transform.localScale.x , transform.localScale.y, transform.localScale.z);
    
    }
   
    bool  isGrounded() {
        groundRay = Physics2D.Raycast(transform.position,-Vector2.up, rayLength, groundMask);
        if (groundRay) {
            return true;
        }
        
        return false;
    }

}
