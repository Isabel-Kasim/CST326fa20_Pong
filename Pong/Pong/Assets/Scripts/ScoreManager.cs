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

    
    public void AddScore(float leftscore, float rightscore)
    {
        lscoreText.text = leftscore.ToString();
        rscoreText.text = rightscore.ToString();
    }
    

}
