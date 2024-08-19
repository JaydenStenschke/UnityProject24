using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int health = 100; // Example health value

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy killed: " + gameObject.name);
        // Add additional logic for what happens when the enemy dies
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}