using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController2 : MonoBehaviour
{
    public int riseSpeed = 0;
    private int cubeSpeed = 0;

    private CubeAudio cubeAudio;    // a reference to the cubeAudio component script on this cube.

     void Start()
    {
        // Initialize riseSpeed with a random value between 1 and 10 (inclusive).
        cubeSpeed = Random.Range(1, 10);
        cubeAudio = this.GetComponent<CubeAudio>();
    }

    void Update()
    {
        // Move the cube upward based on riseSpeed.
        this.transform.Translate(0, riseSpeed * Time.deltaTime, 0);
    }

    public void GetCollected()
    {
        if (riseSpeed > 6)
        {
            // Turn the cube green.
            this.GetComponent<Renderer>().material.color = Color.green;

            // Move up by changing riseSpeed to 5.
            riseSpeed = 5;

            // Disable physics to prevent further movement.
            this.GetComponent<Rigidbody>().isKinematic = true;

            // Destroy the cube after 5 seconds.
            Destroy(this.gameObject, 5f);
            //playAudio
            cubeAudio.PlayCollectionAudio(true);
        }
        else
        {
            // Turn the cube red.
            this.GetComponent<Renderer>().material.color = Color.red;

            // Log that the cube is actually deleted
            Debug.Log("Cube is being destroyed.");

            // Destroy the cube after 1 second.
            Destroy(this.gameObject, 1f);
            //playAudio
            cubeAudio.PlayCollectionAudio(false);
        }
    }
}
