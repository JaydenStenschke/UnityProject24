using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pickup : MonoBehaviour
{
    public float rotateSpeed = 5f; // Rotation speed of this pickup
    public GameObject zombieObject;
    public int damage = 100; // Amount of damage to inflict on zombies

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // If the collider this pickup hit is tagged as Player...
        {
            if(gameObject.CompareTag("KillZombie")){
                if (zombieObject != null)
                {
                    Destroy(zombieObject); // Destroy this pickup!
            
                    Debug.Log("KABOOM!!!!");
                }
            }

        if (gameObject.CompareTag("GameOver")){
                    SceneManager.LoadScene("MainMenu");
                }

            }
    }
            // Optionally destroy or deactivate the pickup object
            
}
