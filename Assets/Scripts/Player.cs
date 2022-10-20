using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("bounce");

        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if (materialName == "Safe (Instance)")
        {
            // The ball hits the safe area
            Debug.Log("Ok");

        } else if (materialName == "Unsafe (Instance)")
        {
            // The ball hits the unsafe area
            GameManager.gameOver = true;
            audioManager.Play("game over");
        } else if (materialName == "LastRing (Instance)" && !GameManager.levelCompleted)
        {
            // The ball hits the last ring
            GameManager.levelCompleted = true;
            audioManager.Play("win level");
        }
    }
}
