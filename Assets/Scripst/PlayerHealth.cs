using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] GameController gameController;
    [SerializeField] private HealthUI healthUI;
    void Start()
    {
        playerData.currentHealth = playerData.maxHealth;
        healthUI.SetMaxHearts(playerData.maxHealth);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy ) 
        {
            TakeDamage(enemy.damage);
        }
    }
    private void TakeDamage(int damage)
    {
        playerData.currentHealth -= damage;
        healthUI.UpdateHearts(playerData.currentHealth);

        if (playerData.currentHealth <= 0 ) 
        {
            gameController.Loose();
        }
    }

}
