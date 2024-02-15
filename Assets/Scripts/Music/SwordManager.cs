using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    UIController uIController;
    public GameObject UI;
    private AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        uIController = UI.GetComponent<UIController>();
        source = GetComponent<AudioSource>();
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
            uIController.score += 2;
            source.PlayOneShot(clip);
        }
    }
    //åïÇ∆ìGÇÃè’ìÀ
}
