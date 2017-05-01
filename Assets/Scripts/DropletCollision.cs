using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropletCollision : MonoBehaviour {

   

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameControl.instance.GremlinScored();
        }
    }
}
