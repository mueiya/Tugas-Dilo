using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour
{
    //save highscore on SceneLoad
    public int highscore;
    public int score;
    [SerializeField] private Text highscoreText;
    [SerializeField] private Text newhighscoreText;

    void Start()
    {
        //highscore
        highscore = PlayerPrefs.GetInt("highscore", highscore);
        highscoreText.text = highscore.ToString();
        score = PlayerPrefs.GetInt("score", 0);
        newhighscoreText.text = "Highscore";
    }

    // Update is called once per frame
    void Update()
    {
        score = PlayerPrefs.GetInt("score", 0);

        //set highscore int playerprefs
        if (score > highscore)
        {
            highscore = score;
            highscoreText.text = score.ToString();
            newhighscoreText.text = "New Highscore";
            PlayerPrefs.SetInt("highscore", score);

        };
        //delete playerprefs
        if (Input.GetMouseButtonDown(2))
        {
            PlayerPrefs.DeleteAll();
            highscore = PlayerPrefs.GetInt("highscore", 0);
            highscoreText.text = highscore.ToString();
            newhighscoreText.text = "Highscore";
        };
    }
 
}
