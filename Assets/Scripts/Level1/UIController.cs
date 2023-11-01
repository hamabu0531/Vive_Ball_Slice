using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private Text scoreText;
    public int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.parent.GetChild(0).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
