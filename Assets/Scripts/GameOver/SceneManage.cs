using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class SceneManage : MonoBehaviour
{
    private SteamVR_Action_Boolean Iui = SteamVR_Actions.default_InteractUI;
    private Boolean interacrtui;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Iui.GetState(SteamVR_Input_Sources.LeftHand) || Iui.GetState(SteamVR_Input_Sources.RightHand))
        {
            SceneManager.LoadScene("Music1");
        }
    }
}
