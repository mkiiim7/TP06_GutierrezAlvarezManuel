using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "PlayerData", menuName = "Player/Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Movement/Jump")]
    public float speed = 1f;
    public float speedSalto = 1f;
    public bool grounded = false;
    public int maxJumps = 2;
    public int jumpsRemaining = 2;

    [Header("Atack")]
    public float attackCooldown = 1f;
    public float speedFireBall = 6f;

    [Header("Health")]
    public int startingHealth = 1;
    public int maxHealth = 3;
    public int currentHealth;


    [Header("Enemy")]
    public float chaseSpeed = 2f;
    public float jumpForce = 2f;
    


}

