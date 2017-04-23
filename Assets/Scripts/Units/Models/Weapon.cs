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
            ShootPrefab(direction);
            //ShootRaycast(direction);
        }
        
    }

    private void ShootRaycast(int direction){
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(transform.position, Vector2.right * direction, 5);
        
        if (hit2D.collider != null){
            Debug.Log("Acerteu algo >>> " + hit2D.collider.name);
            Debug.DrawRay(transform.position, new Vector2(5, 0) * direction, Color.green, 1f);
        }else{
            Debug.DrawRay(transform.position, new Vector2(5, 0) * direction, Color.red, 1f);
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
