using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceScoreScript : MonoBehaviour
{
    public GameObject startPos;
    public TextMeshProUGUI scoreText;
    public GameObject scoreTextObj;

    private float distance;

    void Start()
    {
        scoreText = scoreTextObj.GetComponent<TextMeshProUGUI>();
        
    }
    private void Update()
    {
        distance = -(startPos.transform.position.x + this.transform.position.x);
        scoreText.text = distance.ToString("F1") + "M";
        
    }
}
