using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10.0f;
    private Vector3 direction;
    //private Vector2 screenBounds;
    public float Lscore;
    public float Rscore;
    private bool win;
    private ScoreManager score;
    private Vector3 v = new Vector3(10.0f, 0.0f, 0.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        score = this.GetComponent<ScoreManager>();
        direction = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        rb.AddForce(direction);
        //rb.velocity = new Vector3 (speed, 0, speed);
        //screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    /*
    // Update is called once per frame
    void Update()
    {
        //rb.AddForce(direction);
        //direction = new Vector3(Random.Range(-5, 5), 0, Random.Range(-1, 1));
        rb.velocity = new Vector3(speed, 0, speed);
    }
    */

    void FixedUpdate()
    {
        rb.velocity = new Vector3(speed, 0, speed);
    }

    /*
    void BallMovement(Vector3 movement)
    {
        rb.velocity = movement;
    }
    */
    

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LPaddle" || collision.gameObject.tag == "RPaddle")
        {
            direction.x = -direction.x;
        }
        else if (collision.gameObject.tag == "UpperWall" || collision.gameObject.tag == "LowerWall")
        {
            direction.z = -direction.z;
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
            direction = new Vector3(Random.Range(-10, 0), 0, Random.Range(-10, 10));
            if (Lscore >= 11 || Rscore >= 11)
            {
                Destroy(this.gameObject);
            }
        }
        if (other.gameObject.tag == "Right Goal")
        {
            Rscore++;
            win = true;
            //wscore.AddScore(Lscore, Rscore);
            Debug.Log("Right Paddle Scored! " + "[" + Lscore + "-" + Rscore + "]");
            rb.transform.position = new Vector3(0, 1, 0);
            direction = new Vector3(Random.Range(0, 10), 0, Random.Range(-10, 10));
            if (Lscore >= 11 || Rscore >= 11)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
