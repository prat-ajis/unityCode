using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    public float jumpForce;
    public GameObject LoseScreenUI, confirmScreenUI;
    public int score, hiScore;
    string HISCORE = "HISCORE";
    public TMP_Text scoreUI, hiScoreUI;
    public AudioClip jumpSound, deathSound, scoreSound;

     private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hiScore = PlayerPrefs.GetInt(HISCORE);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        hiScoreUI.text = "Poin Dhuwur : " + hiScore.ToString();
        scoreUI.text = "Poin : " + score.ToString();
    }
    void PlayerJump()
    {
        if (Input.GetMouseButtonDown(0) && Time.timeScale != 0)
        {
            audioManager.instance.PlaySound(jumpSound);
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    void PlayerLose()
    {
        if (score > hiScore)
        {
            hiScore = score;
            PlayerPrefs.SetInt(HISCORE, hiScore);
        }
        hiScoreUI.text = "Highscore : " + hiScore.ToString();
        scoreUI.text = "score : " + score.ToString();
        LoseScreenUI.SetActive(true);
        audioManager.instance.PlaySound(deathSound);
        Time.timeScale = 0;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("obstacle"))
        {
            PlayerLose();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("score"))
        {
            Addscore();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void closeGame()
    {
        Application.Quit();
    }

    void Addscore()
    {
        score++;
        audioManager.instance.PlaySound(scoreSound);
    }

    public void confirmScreen()
    {
        confirmScreenUI.SetActive(true);
    }
    public void closeConfirmScreen()
    {
        confirmScreenUI.SetActive(false);
    }

}
