using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemy;
    public TextAsset sampleJson;
    public float offset, boundary, high, low, currentBars;
    private Vector3 randomPos;
    MusicClass musicClass;
    // Start is called before the first frame update

    void Start()
    {
        musicClass = JsonUtility.FromJson<MusicClass>(sampleJson.text);
        currentBars = 0;

        StartCoroutine(IntervalStart(offset));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator IntervalStart(float offset)
    {
        yield return new WaitForSeconds(offset);
        StartCoroutine(EnemyGenerate(musicClass.BPM));
    }
    private IEnumerator EnemyGenerate(float BPM)
    {
        StartCoroutine(TTTT(BPM));

        yield return new WaitForSeconds(musicClass.length);

        SceneManager.LoadScene("GameOver");
    }  

    public IEnumerator TTTT(float BPM)
    {
        while (currentBars < musicClass.bars)
        {
            currentBars += 0.25f;
            randomPos = new Vector3(Random.Range(-boundary, boundary), Random.Range(low, high), 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60/BPM);
        }  
    }
}
