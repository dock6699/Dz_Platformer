using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerGroundCheker))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private float _playerScale;
    private PlayerGroundCheker _groundCheker;

    private void Start()
    {
        _groundCheker = GetComponent<PlayerGroundCheker>();
        _playerScale = transform.localScale.x;
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        Jumping();
    }

    private void Mirroring(float axisDirection)
    {
        if (axisDirection > 0)
        {
            transform.localScale = new Vector3(_playerScale * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (axisDirection < 0)
        {
            transform.localScale = new Vector3(_playerScale, transform.localScale.y, transform.localScale.z);
        }
    }

    private void Movement()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0);
            Mirroring(Input.GetAxis("Horizontal"));
        }
    }

    private void Jumping()
    {
        if (Input.GetKey(KeyCode.Space)&&_groundCheker.CheckGroundCollision())
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

}
