using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    private Text scoreText;
    private int score;

    public GameObject scorepanel;
    public Text endscore;
    public Animator endpannelanim;

    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        StartCoroutine(CountScore());
    }



    void Awake()
    {
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance==null)
        {
            instance = this;
        }
    }
    // Update is called once per frame
  

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.1f);
        score++;
        scoreText.text = score.ToString();

        StartCoroutine(CountScore());
    }

    public void GameOver()
    {
        scorepanel.SetActive(false);
        endscore.text = "Score" + score;
        endpannelanim.Play("End");
    }


    public void Again()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

}//class
