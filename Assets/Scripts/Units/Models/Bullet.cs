using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float speed;
    [SerializeField]
    private float timeToDestroy;



    private void OnDisable()
    {
        CancelInvoke("Destroy");
    }

    public void BulletAction(int direction) { 


        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce((Vector2.right * direction) * speed);
        Invoke("Destroy", timeToDestroy);
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }

}
