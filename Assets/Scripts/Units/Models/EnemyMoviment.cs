using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoviment : PhysicsObject {

    public Enemy myEnemie;
    public Transform target;

    public float speed;
    public float jumpForce;

    public Transform refWeapon;
    public float damage;

    private bool facingRight = true;

    private void OnEnable()
    {
        speed = myEnemie.velocity;
        jumpForce = myEnemie.jumpForce;
    }

    private bool CheckHeight()
    {
        bool sameLevel;

        Vector2 difference = transform.position - target.position;
        var distanceInY = Mathf.Abs(difference.y);
        if(distanceInY > 5)
        {
            sameLevel = false;
        }else{
            sameLevel = true;
        }
        return sameLevel;
    }

    protected override void ComputerVelocity()
    {
        Vector2 move = Vector2.zero;
        if (!CheckHeight())
            return;
        if(transform.position.x < target.position.x){
            move.x = speed;
        }else{
            move.x = -speed;
        }

        targetVelocity = move * speed;
        if(move.x > 0){
            ShootRaycast(1);
        }else
        {
            ShootRaycast(-1);
        }
        if (move.x > 0 && !facingRight) Flip();
        if (move.x < 0 && facingRight) Flip();

    }


    private void ShootRaycast(int direction)
    {
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(refWeapon.position, Vector2.right * direction, 1f);

        if (hit2D.collider != null)
        {
            Debug.Log("Acerteu algo >>> " + hit2D.collider.name);
            Debug.DrawRay(transform.position, new Vector2(5, 0) * direction, Color.green, 1f);
            if (hit2D.collider.CompareTag("Player")){
                Health player = hit2D.collider.GetComponent<Health>();
                player.ApplyDamage(damage);
            }
        }
        else
        {
            Debug.DrawRay(transform.position, new Vector2(5, 0) * direction, Color.red, 1f);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        this.gameObject.transform.localScale = new Vector3(-this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }


}
