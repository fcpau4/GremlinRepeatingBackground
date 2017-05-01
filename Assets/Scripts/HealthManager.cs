using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {

    public GameObject[] hearts;
    private int health;
    public static bool IsDead = false;


    // Use this for initialization
    void Start () {
       health = hearts.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Light")
        {
            health--;
            hearts[health].SetActive(false);

            if (health == 0)
            {

                IsDead = true;
                GameControl.instance.GremlinDied();
            }
        }
    }


}
