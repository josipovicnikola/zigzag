using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject panel;     
    public GameObject gameOverPanel;
    public GameObject tapText;
    public GameObject activeScore1;
    public GameObject activeScore2;
    public Text score;
    public Text activeScore;
    public Text highscore1;
    public Text highscore2;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore1.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    public void GameStart()
    {
        highscore1.text = PlayerPrefs.GetInt("highScore").ToString();
        //tapText.SetActive(false);
        activeScore1.SetActive(true);
        activeScore2.SetActive(true);
        tapText.GetComponent<Animator>().Play("textDown");
        panel.GetComponent<Animator>().Play("panelup");

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
    // Update is called once per frame
    void Update()
    {
        activeScore.text = ScoreManager.instance.score.ToString();
    }
}
