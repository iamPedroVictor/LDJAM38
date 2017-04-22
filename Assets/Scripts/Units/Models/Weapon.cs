using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    //public WeaponBase weapon;

    public Bullet bulletRef;

    public float timeCooldown;
    private bool isCooldown = true;


    private void OnEnable()
    {

    }

    public void Shoot(int direction)
    {
        if (isCooldown)
        {
            //ShootPrefab(direction);
            ShootRaycast(direction);
        }
        
    }

    private void ShootRaycast(int direction){
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(transform.position, Vector2.right * direction, 15);
        Debug.DrawRay(transform.position, Vector2.right * direction, Color.red, 1f);
        if (hit2D.collider != null){
            Debug.Log("Acerteu algo >>> " + hit2D.collider.name);
        }
    }

    private void ShootPrefab(int direction)
    {
        Bullet bullet = Instantiate(bulletRef, transform.position, transform.rotation) as Bullet;
        bullet.BulletAction(direction);
        isCooldown = false;
        Invoke("ShootAgain", timeCooldown);
    }

    private void ShootAgain()
    {
        isCooldown = true;
    }

}
