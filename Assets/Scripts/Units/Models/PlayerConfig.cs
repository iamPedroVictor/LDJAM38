using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Melee,
    Shoot
}

[CreateAssetMenu(menuName = "ScriptableObjects/PlayerConfig")]
public class PlayerConfig : ScriptableObject {

    public float maxSpeed;
    public float jumpForce;

    public int level;

    public float damage;
    public float health;

    public AttackType attackType;

}
