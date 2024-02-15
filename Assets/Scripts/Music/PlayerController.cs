using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed, rotationSpeed, xBound, zBound, coolTime;
    public GameObject enemySpn;
    public int score;
    EnemySpawner enemySpawner;
    public Sprite bulletImage, reloadingImage;
    private GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        enemySpawner = enemySpn.GetComponent<EnemySpawner>();
        camera = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        else if(transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
        else if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        //�ǂɍs�����Ƃ��ɂ���ȏ�O�ɍs���Ȃ����E

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
        //Player�̉�]

        if (Input.GetKey(KeyCode.DownArrow))
        {
            camera.transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            camera.transform.Rotate(Vector3.left * Time.deltaTime * rotationSpeed);
        }
        //�J�����݂̂̉�]

        //���ۂ̈ړ���HMD�̈ʒu�֌W�ōs�����ߏ�̃R�[�h�͉�

    }
}
