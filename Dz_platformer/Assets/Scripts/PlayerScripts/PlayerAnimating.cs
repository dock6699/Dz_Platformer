using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimating : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
            _animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
