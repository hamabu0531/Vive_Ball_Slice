using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    private Text scoreText, songText;
    public int score;
    public TextAsset songJson;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = transform.parent.GetChild(0).GetComponent<Text>();
        songText = transform.parent.GetChild(2).GetComponent<Text>();

        StartCoroutine(FadeOut());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    IEnumerator FadeOut()
    {
        songText.text = "ÅÙ " + JsonUtility.FromJson<MusicClass>(songJson.text).songName;
        while (true)
        {
            for (int i = 0; i < 255; i++)
            {
                songText.color -= new Color32(0, 0, 0, 1);
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}
