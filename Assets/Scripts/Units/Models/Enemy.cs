using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemyConfig")]
public class Enemy : ScriptableObject {

    [Header("Atributes")]
    public float velocity;
    public float health;
    public float jumpForce;

    [Header("Abilitys")]
    public bool canJump;

}
