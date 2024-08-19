using UnityEngine;

public class KillEnemy : MonoBehaviour
{
    public int damage = 100; // Amount of damage to inflict on enemies
    public string zombieTag = "Zombie"; // Tag for enemy objects

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(zombieTag)) // Check if the object colliding is tagged as Zombie
        {
            // Find the Zombie script on the collided object
            Zombie zombie = other.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.TakeDamage(damage); // Apply damage to the zombie
            }
            else
            {
                Debug.LogWarning("Zombie script not found on the zombie object.");
            }

            // Optionally destroy or deactivate the pickup object
            Destroy(gameObject); // Destroy this pickup!
        }
    }

    private void Update()
    {
        // Rotate the pickup item
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
