using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //gameObject.GetComponent<MeshRenderer>().material.color = newColor();
        GetComponent<MeshRenderer>().material.color = newColor();
        //collision.gameObject.GetComponent<MeshRenderer>().material.color = newColor();
    }

    void OnCollisionExit(Collision collision)
    {
        collision.gameObject.GetComponent<MeshRenderer>().material.color = newColor();
    }

    private Color newColor()
    {
        Color color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        return color;
    }
}
