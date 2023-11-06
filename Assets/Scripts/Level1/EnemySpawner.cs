using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject uIcontrol, clearUI;
    public GameObject[] enemy;
    private Vector3 randomPos;
    public bool isGameClear;
    UIController uIController;
    public float interval, boundary, offset;
    // Start is called before the first frame update

    private void Awake()
    {
        isGameClear = false;
        clearUI.SetActive(false);
        uIController = uIcontrol.GetComponent<UIController>();
        StartCoroutine(Wait(offset));
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator EnemyGenerate(float n)
    {
        while(uIController.score < 30)
        {
            randomPos = new Vector3(Random.Range(-boundary, boundary), 3.0f, 20);
            int index = Random.Range(0, 3);
            Instantiate(enemy[index], randomPos, enemy[index].transform.rotation);
            yield return new WaitForSeconds(n);
        }
        Gameclear();
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
