using UnityEngine;
using System.Collections;

public class Revised : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCube;

    // List of possible colors for the cubes
    public Material[] cubeMaterials;

    // Adjustable parameters in the Inspector
    public int numberOfCubesToSpawn = 25; // Change this to the desired number of cubes
    public float spawnInterval = 1f; // Change this to the desired spawn interval in seconds

    // Flag to control spawning
    private bool isSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    // spawn a cube with a random color
    GameObject SpawnCube()
    {
        GameObject cube = Instantiate(prefabCube);

        // Set a random color for the cube
        Material randomMaterial = cubeMaterials[Random.Range(0, cubeMaterials.Length)];
        cube.GetComponent<Renderer>().material = randomMaterial;

        // Add a Rigisbody component for physics simulation
        Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>();
        cubeRigidbody.mass = 1.0f; // Adjust mass as needed

        // Move the cube to a random position
        cube.transform.position = new Vector3(Random.Range(-40, 40), 2, Random.Range(-40, 40));

        return cube;
    }

    // the loop function
    IEnumerator SpawnLoop()
    {
        int counter = 0;
        while (counter < numberOfCubesToSpawn) // Use the numberOfCubesToSpawn variable
        {
            counter += 1;
            SpawnCube();
            yield return new WaitForSeconds(spawnInterval); // Use the spawnInterval variable
        }
    }

    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnLoop());
    }

    public void RestartSpawning ()
    {
        // Stop the existing spawning loop if it's running
        object StopSpawning;

        // Start a new spawning loop
        object StartSpawning;
    }

    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(SpawnLoop());
    }

    private void Update()
    {
        // Check for a key press to restart spawning
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartSpawning();
        }
    }
}