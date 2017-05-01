using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

    public static GameControl instance;
    public static float intervalIncDiff = 5f;
    public static float timeIncDiff;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;


    private int score = 0;

	// Use this before initialization
	void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            //Don't want multiple GameControl instances working.
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (gameOver && Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            HealthManager.IsDead = false;
        }

        timeIncDiff += Time.deltaTime;
        
	}


    public void GremlinScored()
    {
        if (gameOver)
        {
            return;
        }

        score++;
        scoreText.text = "Score: " + score.ToString();
    }


    public void GremlinDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }
}
