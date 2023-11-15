using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float enemySpeed, rotateSpeed; 
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.back * Time.deltaTime * enemySpeed;

        transform.Rotate(Vector3.forward * Time.deltaTime * rotateSpeed);
        transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);
    }
    //ZŽ²‚É‰ˆ‚Á‚½ˆÚ“®

}
