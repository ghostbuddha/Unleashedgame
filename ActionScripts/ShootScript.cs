using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour {

    public float velX;
    public float velY;
    public bool friendly;
    public float damage;
    private Rigidbody2D rb2d;
    private Animator anim;
    

	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
	}
	

	void Update () {
        rb2d.velocity = new Vector2(velX, velY);
        Invoke("Pop2", 0.7f);
        Invoke("Pop", 0.9f);
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (friendly)
        {
            if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Enemy"))
            {
                anim.SetTrigger("Hit");
                Invoke("Pop", 0.3f);
            }
        } else
        {
            if (other.gameObject.CompareTag("ground") || other.gameObject.CompareTag("Player"))
            {
                anim.SetTrigger("Hit");
                Invoke("Pop", 0.3f);
            }
        }
     }
    void Pop()
    {
        Destroy(gameObject);
    }
    void Pop2()
    {
        //anim.SetTrigger("Hit");
    }
}
