using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Ball : MonoBehaviour
{
    // Reference used: https://www.youtube.com/watch?v=YHSanceczXY

    public TextMeshProUGUI lscoreText;
    public TextMeshProUGUI rscoreText;
    private Rigidbody rb;
    public float speed = 10.0f;
    private Vector3 direction;
    public ScoreManager score;
    public int Lscore = 0;
    public int Rscore = 0;
    private bool win;
    private Vector3 v = new Vector3(10.0f, 0.0f, 0.0f);
    public GameObject LloseScreenUI;
    public GameObject RloseScreenUI;
    public GameObject powerup;
    private float randTime;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        //lscoreText = lscoreText.GetComponent<TextMeshProUGUI>();
        //rscoreText = rscoreText.GetComponent<TextMeshProUGUI>();
        randTime = UnityEngine.Random.value * Time.deltaTime;
        Startoff();
    }


    void Startoff()
    {
        speed = 10.0f;
        Time.timeScale = 1f;
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, 0, speed * y);
        Invoke("PowerUp", randTime);
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LPaddle" || collision.gameObject.tag == "RPaddle")
        {
            v.x = -v.x;
            v.z = -v.z;
            FindObjectOfType<AudioManager>().Play("Hit");
        }
        else if (collision.gameObject.tag == "UpperWall" || collision.gameObject.tag == "LowerWall")
        {
            v.z = -v.z;
        }
        
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Left Goal")
        {
            Rscore++;
            //lscoreText.text = Lscore.ToString();
            //rscoreText.text = Rscore.ToString();
            win = false;
            score.AddScore(Lscore, Rscore);
            Debug.Log("Left Paddle Scored! " + "[" + Lscore + "-" + Rscore + "]");
            rb.transform.position = new Vector3(0, 1, 0);
            Startoff();
            if (Lscore >= 11 || Rscore >= 11)
            {
                //FindObjectOfType<AudioSource>().Stop();
                FindObjectOfType<AudioManager>().Play("Lose");
                Debug.Log("Winner! Right Paddle");
                Debug.Log("Press F to return to main menu!");
                score.winner();
                RloseScreenUI.SetActive(true);
                //Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "Right Goal")
        {
            Lscore++;
            //lscoreText.text = Lscore.ToString();
            //rscoreText.text = Rscore.ToString();
            score.AddScore(Lscore, Rscore);
            win = true;
            //wscore.AddScore(Lscore, Rscore);
            Debug.Log("Right Paddle Scored! " + "[" + Lscore + "-" + Rscore + "]");
            rb.transform.position = new Vector3(0, 1, 0);
            Startoff();
            if (Lscore >= 11 || Rscore >= 11)
            {
                //FindObjectOfType<AudioSource>().Stop();
                FindObjectOfType<AudioManager>().Play("Lose");
                Debug.Log("Winner! Left Paddle");
                Debug.Log("Press F to return to main menu!");
                //SceneManager.LoadScene("Main Menu");
                score.winner();
                LloseScreenUI.SetActive(true);
                //Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "PowerUp")
        {
            Debug.Log("Hit");
            speed = 60.0f;
            Time.timeScale = 3f;
            //Destroy(other.gameObject);
            powerup.SetActive(false);
        }
    }


    public void returnButton()
    {
        RloseScreenUI.SetActive(false);
        LloseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void newGame()
    {
        RloseScreenUI.SetActive(false);
        LloseScreenUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("PongStart");
    }

    public void PowerUp ()
    {
        powerup.SetActive(true);
    }
}
