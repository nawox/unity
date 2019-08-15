using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
    public float health;
    Animator anim;
    BoxCollider2D weapon;
	// Use this for initialization
	void Start () {
        anim = gameObject.GetComponent<Animator>();

       // weapon = gameObject.GetComponentInChildren<BoxCollider2D>();
       // Physics2D.IgnoreCollision(gameObject.GetComponent<CapsuleCollider2D>(), weapon);
    }
	
	// Update is called once per frame
	void Update () {
	    	
	}
    

    public void GetDamage(float damage) {
        health -= damage;
        anim.SetTrigger("Hurt");

        if (health <= 0) {
            Die();
        }
    }
    void Die() {
        if (anim)
        {
            if (anim.HasState(0, 0)) { }
            anim.SetBool("death", true);
        }
        else
        {
            Destr(this.gameObject);
        }
        Destr(this.gameObject);
    }
    public void Destr(GameObject obj) {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("from health collider");
        Debug.Log(collision.transform.tag);
        
        if (collision.gameObject.transform.tag == "Weapon")
        {
            Debug.Log("from health collider whith tag");
            //GetDamage(collision.gameObject.transform.GetComponent<AttackScript>().AttackValue);
        }
    }

}
