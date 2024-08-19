using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float rotateSpeed = 5f; // Rotation speed of this pickup
    public string zombieTag = "Zombie"; // Tag for zombie objects
    public int damage = 100; // Amount of damage to inflict on zombies

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // If the collider this pickup hit is tagged as Player...
        {
            // Find all zombies in the scene
            GameObject[] zombies = GameObject.FindGameObjectsWithTag(zombieTag);
            foreach (GameObject zombie in zombies)
            {
                // Find the Zombie script and apply damage
                Zombie zombieScript = zombie.GetComponent<Zombie>();
                if (zombieScript != null)
                {
                    zombieScript.TakeDamage(damage); // Apply damage to the zombie
                }
                else
                {
                    Debug.LogWarning("Zombie script not found on zombie object.");
                }
            }

            // Optionally destroy or deactivate the pickup object
            Destroy(gameObject); // Destroy this pickup!
        }
    }

    private void Update()
    {
        // Every frame, make this pickup rotate
        transform.Rotate(new Vector3(15, 30, 45) * rotateSpeed * Time.deltaTime);
    }
}
