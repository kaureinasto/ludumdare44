using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscendAnimation : MonoBehaviour
{
    public SimpleEvent startAscendEvent;

    private void OnEnable()
    {
        startAscendEvent.action += forwardAscendToAnimator;
    }

    private void OnDisable()
    {
        startAscendEvent.action -= forwardAscendToAnimator;
    }

    private void forwardAscendToAnimator()
    {
        GetComponent<Animator>().SetBool("ascend", true);
    }
}