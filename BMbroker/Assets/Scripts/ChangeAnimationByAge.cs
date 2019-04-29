using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimationByAge : MonoBehaviour
{
    public ObservableFloat age;

    private Animator _animator;
    
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        age.OnChanged += forwardAgeToAnimator;
    }

    private void OnDisable()
    {
        age.OnChanged -= forwardAgeToAnimator;
    }

    private void forwardAgeToAnimator(float newAge)
    {
        _animator.SetFloat("age", newAge);
    }
}