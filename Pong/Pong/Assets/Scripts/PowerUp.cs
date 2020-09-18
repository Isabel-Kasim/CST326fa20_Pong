using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public GameObject powerUp;

    void Start()
    {
        gameObject.GetComponent<GameObject>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            Time.timeScale = 5f;
            Destroy(this.gameObject);
        }
    }
}
