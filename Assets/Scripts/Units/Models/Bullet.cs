using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed;
    [SerializeField]
    private float timeToDestroy;
    public Vector2 forceBullet;
    public float damage;
    public string targetTag;

    public void BulletAction(int direction) { 


        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce((Vector2.right * direction) * speed);
        Invoke("Destroy", timeToDestroy);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Tag colidida >>> " + collision.tag);
        if (collision.CompareTag("Ground"))
        {
            Destroy();
        }
        if (collision.CompareTag(targetTag))
        {
            Debug.Log("Colidir com o " + targetTag);
            Health health = collision.GetComponent<Health>();
            health.ApplyDamage(damage);
            Destroy();

        }

    }

    private void Destroy()
    {
        CancelInvoke("Destroy");
        Destroy(this.gameObject);
    }

}
