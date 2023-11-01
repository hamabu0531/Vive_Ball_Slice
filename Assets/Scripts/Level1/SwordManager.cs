using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    UIController uIController;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        uIController = UI.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            uIController.score++;
        }
    }
    //åïÇ∆ìGÇÃè’ìÀ
}
