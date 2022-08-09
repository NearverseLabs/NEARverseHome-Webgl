using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    [SerializeField]
    TakeScreenshot screenshot;

    [SerializeField]
    GameObject panel;

    [SerializeField]
    AudioSource music;
    bool mute;
    bool panelActive;

    [SerializeField]
    GameObject buttons;

    bool cursorVisible;
    
    Material material;

    private void Start() 
    {
        material=RenderSettings.skybox;
        UIPanelSetter();    
    }
    void Update()
    {
        material.SetFloat("_Rotation",197+Time.time);
        if(Input.GetKeyDown(KeyCode.P))
        {
            screenshot.Screenshot();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            UIPanelSetter(); 
        }

        if(Input.GetKeyDown(KeyCode.M))
        {
            mute=!mute;
            music.mute = mute;
        }
		if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow)|| Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyDown(KeyCode.DownArrow))
		{
			panel.SetActive(false);
		}

    }

    public void UIPanelSetter()
    {
        panelActive=!panelActive;
        panel.SetActive(panelActive);
    }

}
