using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // Reference used: https://www.youtube.com/watch?v=YHSanceczXY


    private Rigidbody rb;
    public float speed = 10.0f;
    private Vector3 direction;

    public float Lscore;
    public float Rscore;
    private bool win;
    private Vector3 v = new Vector3(10.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Startoff();
    }


    void Startoff()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector3(speed * x, 0, speed * y);
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LPaddle" || collision.gameObject.tag == "RPaddle")
        {
            v.x = -v.x;
            v.z = -v.z;
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
            Lscore++;
            win = false;
            //score.AddScore(Lscore, Rscore);
            Debug.Log("Left Paddle Scored! " + "[" + Lscore + "-" + Rscore + "]");
            rb.transform.position = new Vector3(0, 1, 0);
            Startoff();
            if (Lscore >= 11 || Rscore >= 11)
            {
                Debug.Log("Winner! Right Paddle");
                Destroy(this.gameObject);
                Debug.Log("Press F to return to main menu!");
                SceneManager.LoadScene("Main Menu");
                //SceneManager.LoadScene("Main Menu");
            }
        }
        if (other.gameObject.tag == "Right Goal")
        {
            Rscore++;
            win = true;
            //wscore.AddScore(Lscore, Rscore);
            Debug.Log("Right Paddle Scored! " + "[" + Lscore + "-" + Rscore + "]");
            rb.transform.position = new Vector3(0, 1, 0);
            Startoff();
            if (Lscore >= 11 || Rscore >= 11)
            {
                Debug.Log("Winner! Left Paddle");
                Destroy(this.gameObject);
                Debug.Log("Press F to return to main menu!");
                SceneManager.LoadScene("Main Menu");
                
            }
        }
    }

}
