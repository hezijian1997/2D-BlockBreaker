using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointPerBlock = 5;
    
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int currentScore = 0;
    [SerializeField] bool isAutoPlayEnabled;

    // Give gameobject numbers to count
    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        if (gameStatusCount > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // set build of Score Text
    private void Start()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Time.timeScale = gameSpeed;

	}

    // Add score when the block is destroyed
    public void AddToScore()
    {
        currentScore += pointPerBlock;
        scoreText.text = "Score: " + currentScore.ToString();
    }

    
    public void destroyItself()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
