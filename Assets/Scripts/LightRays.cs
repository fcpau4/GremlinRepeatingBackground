using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRays : MonoBehaviour {

    public float delay = 4f;
    public float modifier = 0.9f;
    public GameObject lightRay;

    private void Update()
    {
        if (GameControl.timeIncDiff > GameControl.intervalIncDiff)
        {
            GameControl.intervalIncDiff = 0;
            delay *= modifier;
        }

        if (GameControl.instance.gameOver)
        {
            CancelInvoke();
        }
    }

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", delay, delay);
    }
	// Update is called once per frame
	void Spawn () {
        Instantiate(lightRay, new Vector3(21, Random.Range(RepeatingBackground.groundCollider.bounds.max.y, 
            Gremlin.player.GetComponent<Collider2D>().bounds.max.y + 0.5f), 0), Quaternion.identity);
        
    }

    

}
