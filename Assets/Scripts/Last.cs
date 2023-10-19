
using UnityEngine;
using System.Collections;

public class Last : MonoBehaviour
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
    private bool debug;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Press Shift+0 to enable debug mode");
        if (debug) Debug.Log("<color=cyan>Press G to spam cubes.</color>");
        StartSpawning();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for a key press to restart spawning
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartSpawning();
        }
    }

    // spawn a cube with a random color and physics
    GameObject SpawnCube()
    {
        if (debug) Debug.Log("Starting Spawncube() function");

        if (debug) Debug.Log("creating cube from prefab 'prefabCube'");
        GameObject cube = Instantiate(prefabCube);

        if (debug) Debug.Log("setting random location");

        // Set a random color for the cube
        Material randomMaterial = cubeMaterials[Random.Range(0, cubeMaterials.Length)];
        cube.GetComponent<Renderer>().material = randomMaterial;

        // Add a Rigidbody component for physics simulation
        Rigidbody cubeRigidbody = cube.AddComponent<Rigidbody>();
        cubeRigidbody.mass = 1.0f; // Adjust mass as needed

        // Move the cube to a random position
        cube.transform.position = new Vector3(Random.Range(-40, 40), 2, Random.Range(-40, 40));

        return cube;
    }

    // the spawning loop function
    IEnumerator SpawnLoop()
    {
        int counter = 0;
        while (counter < numberOfCubesToSpawn && isSpawning)
        {
            counter += 1;
            SpawnCube();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // Start spawning cubes
    public void StartSpawning()
    {
        isSpawning = true;
        StartCoroutine(SpawnLoop());
    }

    // Restart spawning cubes
    public void RestartSpawning()
    {
        // Stop the existing spawning loop if it's running
        StopSpawning();

        // Start a new spawning loop
        StartSpawning();
    }

    // Stop spawning cubes
    public void StopSpawning()
    {
        isSpawning = false;
        StopCoroutine(SpawnLoop());
    }
}