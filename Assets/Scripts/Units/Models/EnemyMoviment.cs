using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : PhysicsObject {

    public Enemy myEnemie;
    public Transform target;

    public float speed;
    public float jumpForce;

    private void OnEnable()
    {
        speed = myEnemie.velocity;
        jumpForce = myEnemie.jumpForce;
    }

    protected override void ComputerVelocity()
    {
        Vector2 move = Vector2.zero;

        if(transform.position.x < target.position.x){
            move.x = speed;
        }else{
            move.x = -speed;
        }
        

        targetVelocity = move * speed;

    }

}
