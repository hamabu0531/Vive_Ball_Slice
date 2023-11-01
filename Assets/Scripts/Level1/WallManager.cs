using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallManager : MonoBehaviour
{
    public GameObject uiManager;
    UIController uiController;
    // Start is called before the first frame update
    void Start()
    {
        uiController = uiManager.GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
