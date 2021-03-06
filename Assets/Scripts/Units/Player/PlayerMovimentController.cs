﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovimentController : PhysicsObject {



    public PlayerConfig playerConfig;

    public int crystals = 0;
    private bool cantMove = false;

    [SerializeField]
    private bool facingRight;

    public Text crystalText;

    public int DirectionPlayer()
    {
        int direction = (facingRight) ? 1 : -1;
        return direction;
    }


    protected override void ComputerVelocity()
    {
        crystalText.text = "Crystals: " + crystals;
        Vector2 move = Vector2.zero;
        if (!cantMove)
        {
            move.x = Input.GetAxis("Horizontal");

            if (Input.GetButtonDown("Jump") && grounded)
            {

                velocity.y = playerConfig.jumpForce;

            }
            else if (Input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * .5f;
                }
            }

            if (move.x > 0 && !facingRight) Flip();
            if (move.x < 0 && facingRight) Flip();

            targetVelocity = move * playerConfig.maxSpeed;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        this.gameObject.transform.localScale = new Vector3(-this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Crystal")){
            Crystal crystal = collision.GetComponent<Crystal>();
            if(Input.GetKeyDown(KeyCode.Z)){
                Debug.Log("Puxando");
                crystal.Extract(this);
            }
        }
    }

    public void AddCrystals()
    {
        crystals++;
        GameManager.Instance.CheckVitory(crystals);
    }

    public void CantMove(float time){
        cantMove = true;
        Invoke("CanMove", time);
    }

    private void CanMove()
    {
        cantMove = false;
    }

}
