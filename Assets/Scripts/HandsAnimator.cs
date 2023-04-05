using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandsAnimator : MonoBehaviour
{
    [SerializeField] ActionBasedController _controller;
    [SerializeField] Animator _animator;
    



    private void Update()
    {
        float value = _controller.selectActionValue.action.ReadValue<float>();
        
        var currentState = _animator.GetCurrentAnimatorStateInfo(0);
        var stateName = currentState.fullPathHash;
        _animator.Play(stateName, 0, value * currentState.length);
        
        
    }
}
