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
        while (currentBars < musicClass.bars)
        {
            int ran = Random.Range(0, 3);
            if (ran < 1)
            {
                StartCoroutine(TTTT(BPM));
            }
            else if (ran < 2)
            {
                StartCoroutine(TTFT(BPM));
            }
            else if (ran < 3)
            {
                StartCoroutine(TTTF(BPM));
            }
            yield return new WaitForSeconds(60 / BPM * musicClass.beat);
        }

        yield return new WaitForSeconds(musicClass.bars * musicClass.beat * musicClass.BPM / 60.0f@+1.0f);

        SceneManager.LoadScene("GameOver");
    }  

    public IEnumerator TTTT(float BPM)
    {
        for (int i = 0; i < 4; i++)
        {
            currentBars += 0.25f;
            randomPos = new Vector3(Random.Range(-boundary, boundary), Random.Range(low, high), 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
        }      
    }
    public IEnumerator TTTF(float BPM)
    {
            currentBars += 0.25f;
            randomPos = new Vector3(Random.Range(-boundary, boundary), Random.Range(low, high), 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
            index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
            index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
            yield return new WaitForSeconds(60 / BPM);

    }
    public IEnumerator TTFT(float BPM)
    {
            currentBars += 0.25f;
            randomPos = new Vector3(Random.Range(-boundary, boundary), Random.Range(low, high), 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
            index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
            yield return new WaitForSeconds(60 / BPM);
            index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(60 / BPM);
    }
}
