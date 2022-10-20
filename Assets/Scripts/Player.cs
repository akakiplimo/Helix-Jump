using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;

    private void OnCollisionEnter(Collision collision)
    {
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
        } else if (materialName == "LastRing (Instance)")
        {
            // The ball hits the last ring
            GameManager.levelCompleted = true;
        }
    }
}
