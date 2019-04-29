using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ExitDisplayer : MonoBehaviour
{
    public GameObject exitDialogue;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                exitDialogue.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                exitDialogue.SetActive(false);
            }
        } else if (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Y))
        {
                Time.timeScale = 1f;
                exitDialogue.SetActive(false);
        }
    }
}