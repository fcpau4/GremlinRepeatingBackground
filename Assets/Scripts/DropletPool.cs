using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletPool : MonoBehaviour {

    public int dropletPoolSize;
    public GameObject dropletPrefab;
    public float spawnRate =3f;

    public float dropletMinY = -1f;
    public float dropletMaxY = 3.5f;

    public float dropletMinX = 5f;
    public float dropletMaxX = 10f;

    private GameObject[] droplets; 
    private Vector2 objectPoolPosition = new Vector2(-15f, -25f);
    private float timeSinceLastSpawned;
    private int currentDroplet = 0;

	// Use this for initialization
	void Start () {
        droplets = new GameObject[dropletPoolSize];

        for (int i = 0; i < dropletPoolSize; i++)
        {
            droplets[i] = (GameObject)Instantiate(dropletPrefab, objectPoolPosition, Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastSpawned += Time.deltaTime;

        if(GameControl.instance.gameOver==false && timeSinceLastSpawned >= spawnRate)
        {

            if (IsDestroyed(droplets[currentDroplet]))
            {
                droplets[currentDroplet] = (GameObject)Instantiate(dropletPrefab, objectPoolPosition, Quaternion.identity);
            }

            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range(dropletMinY, dropletMaxY);
            float spawnXPosition = Random.Range(dropletMinX, dropletMaxX);

            droplets[currentDroplet].transform.position = new Vector2(spawnXPosition, spawnYPosition);
            currentDroplet++;

            if (currentDroplet >= dropletPoolSize)
            {
                currentDroplet = 0;
            }
        }

        
	}

    bool IsDestroyed(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return true;
        }
        else
        {
            return false;
        }
       
    }



  


}
