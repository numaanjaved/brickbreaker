using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    [Range(0f, 10f)] [SerializeField] float SpeedOfGame = 1f;
    [SerializeField] int currentScore = 0;
    [SerializeField] int ScorePerBlock = 5;
    [SerializeField] TextMeshProUGUI scoreText;

    private void Awake()
    {
        int GameStatusCount = FindObjectsOfType<GameSession>().Length;
        if(GameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    // Start is called before the first frame update
    private void Start()
    {
       
        scoreText.text = currentScore.ToString();
    }
    public void AddToScore()
    {
        currentScore += ScorePerBlock;
        scoreText.text = currentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = SpeedOfGame;
    }

    public void Reset()
    {
        Destroy(gameObject);
    }
}
