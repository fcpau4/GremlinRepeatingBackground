using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayDamage : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if(coll.gameObject.tag=="Droplet")
        {
            Physics2D.IgnoreCollision(coll.gameObject.GetComponent<PolygonCollider2D>(), this.GetComponent<BoxCollider2D>());
        }

    }
}
