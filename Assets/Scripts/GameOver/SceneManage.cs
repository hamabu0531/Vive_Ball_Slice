using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneManage : MonoBehaviour
{
    private SteamVR_Action_Boolean haptic = SteamVR_Actions._default.Teleport;
    private Boolean interacrtui;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (haptic.GetState(SteamVR_Input_Sources.LeftHand) || haptic.GetState(SteamVR_Input_Sources.RightHand))
        {
            SceneManager.LoadScene("Title");
        }
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Music1");
    }
}
