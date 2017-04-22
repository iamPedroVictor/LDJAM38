using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour {

    public Weapon myWeapon;
    public PlayerMovimentController myPlayer;


    private void OnEnable()
    {
        myPlayer = GetComponent<PlayerMovimentController>();
    }

    // Update is called once per frame

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            myWeapon.Shoot(myPlayer.DirectionPlayer());
        }
    }
}
