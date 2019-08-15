using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {

    public GameObject target;
    public float move;
    bool isFacingRight;
    Rigidbody2D rb;
    Animator anim;
    public float meleeRadius = 0.5f;
    float rangeAttackRadius;
    public float rangeToTarget;
    public float speed = 2;
    public float attackDelay;
    float attackTime;
	// Use this for initialization
	void Start () {

        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {



        if (target) {
            Move(target);
        }

        if (target && Mathf.Abs(rangeToTarget) <= meleeRadius && Time.time >= attackTime)
        {

           
                AttackMelee();
                attackTime = Time.time + attackDelay;
           
        }
        else if (rangeToTarget <= rangeAttackRadius) { }

	}


    void Move(GameObject target) {

        rangeToTarget = target.transform.position.x - transform.position.x;
        if (Mathf.Abs(rangeToTarget) > meleeRadius)
        {
            if (rangeToTarget > 0)
            {
                move = 1;
            }
            else if (rangeToTarget < 0)
            {
                move = -1;
            }
        } else {
            move = 0;
        }
       
        rb.velocity = new Vector2(speed * move, rb.velocity.y);
        if (move > 0 && isFacingRight)
        {
            Flip();
        }
        else if (move < 0 && !isFacingRight)
        {
            Flip();
        }

        anim.SetFloat("move", Mathf.Abs(move));
    }
    void Flip()
    {
        Debug.Log("hello from  flip");
        isFacingRight = !isFacingRight;
        gameObject.transform.localScale = new Vector3(-this.transform.localScale.x, transform.localScale.y, transform.localScale.z);

    }
    void AttackMelee()
    {
        
        anim.SetTrigger("attack");

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform.tag == "Player")
        {
            target = collision.gameObject;
        }
    }
}
