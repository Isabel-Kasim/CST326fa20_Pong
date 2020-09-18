using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI lscoreText;
    public TextMeshProUGUI rscoreText;
    public Ball gameball;
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameball = this.GetComponent<Ball>();
        lscoreText = lscoreText.GetComponent<TextMeshProUGUI>();
        rscoreText = rscoreText.GetComponent<TextMeshProUGUI>();
    }

    
    public void AddScore(int leftscore, int rightscore)
    {
        lscoreText.color = newColor();
        rscoreText.color = newColor();
        lscoreText.text = leftscore.ToString();
        rscoreText.text = rightscore.ToString();
    }
    
    public void winner ()
    {
        Time.timeScale = 0;
    }

    Color newColor()
    {
        Color color = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value);
        return color;
    }
}
