using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject uIcontrol, clearUI;
    public GameObject[] enemy;
    private Vector3 randomPos;
    public bool isGameClear;
    UIController uIController;
    public float interval, boundary, offset, high, low;
    private float currentTime, beginTime;
    // Start is called before the first frame update

    private void Awake()
    {
        isGameClear = false;
        clearUI.SetActive(false);
        beginTime = Time.realtimeSinceStartup;
        uIController = uIcontrol.GetComponent<UIController>();
        StartCoroutine(Wait(offset));
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        currentTime = Time.realtimeSinceStartup - beginTime;
    }

    private IEnumerator EnemyGenerate(float n)
    {
        while (currentTime < 16.5f)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(2*n);
        }
        while (currentTime < 32.5f && currentTime > 16.5f)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary-1), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(n);
        }
        while (currentTime > 32.5f && currentTime < 47.3f)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary-1), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(n/2);
        }
        while (currentTime > 47.3f && currentTime < 61.5f)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary-1), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            Instantiate(enemy[index], randomPos + Vector3.left*2, enemy[index].transform.rotation);
            yield return new WaitForSeconds(n/2);
        }

        while (currentTime > 61.5f && currentTime < 75.5f)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary-1), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            Instantiate(enemy[index], randomPos + Vector3.left + Vector3.down * 2, enemy[index].transform.rotation);
            Instantiate(enemy[index], randomPos + Vector3.right + Vector3.down * 2, enemy[index].transform.rotation);
            yield return new WaitForSeconds(n);
        }
        while (currentTime > 75.5f && currentTime < 90f)
        {
            int exists = Random.Range(0, 2);
            randomPos = new Vector3(Random.Range(-boundary, boundary-1), Random.Range(low, high), 20);
            //randomPos = new Vector3(0, high, 20);
            int index = Random.Range(0, 3);
            if (exists == 0)
            {
                Instantiate(enemy[index], randomPos + Vector3.up, enemy[index].transform.rotation);
                Instantiate(enemy[index], randomPos + Vector3.down, enemy[index].transform.rotation);
            }
            else
            {
                Instantiate(enemy[index], randomPos + Vector3.right, enemy[index].transform.rotation);
                Instantiate(enemy[index], randomPos + Vector3.left, enemy[index].transform.rotation);
            }
            yield return new WaitForSeconds(n/2);
        }

        yield return new WaitForSeconds(4);

        SceneManager.LoadScene("GameOver");
    }


    private IEnumerator Wait(float n)
    {
        yield return new WaitForSeconds(n);
        StartCoroutine(EnemyGenerate(interval));
    }

    public void Gameclear()
    {
        isGameClear = true;
        clearUI.SetActive(true);
    }
}
