using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovimentController : PhysicsObject {



    public PlayerConfig playerConfig;

    public float crystals = 0;

	// Use this for initialization
	void Start () {
		
	}

    protected override void ComputerVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        if(Input.GetButtonDown("Jump") && grounded){

            velocity.y = playerConfig.jumpForce;

        }else if(Input.GetButtonUp("Jump")){
            if(velocity.y > 0)
            {
                velocity.y = velocity.y * .5f;
            }
        }

        targetVelocity = move * playerConfig.maxSpeed;

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal")){
            Crystal crystal = collision.GetComponent<Crystal>();
            if(Input.GetKey(KeyCode.F)){
                Debug.Log("Puxando");
                crystals += crystal.Extract();
            }
        }
    }

    public void Die(){
        GameManager.Instance.GameOver();
    }

    private void CheckDie()
    {
        if(playerConfig.health <= 0)
        {
            Die();
        }
    }

}
