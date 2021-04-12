using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimating : MonoBehaviour
{
    private Animator _playerAnimator;

    void Start()
    {
        _playerAnimator = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
            _playerAnimator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
