using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CircleCollider2D _groundCheker;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private LayerMask _groundMask;

    private BoxCollider2D _playerCollider;
    private Rigidbody2D _playerRigidbody;

    private float _playerScale;
    void Start()
    {
        _playerScale = transform.localScale.x;
        _playerCollider = gameObject.GetComponent<BoxCollider2D>();
        _playerRigidbody = gameObject.GetComponent<Rigidbody2D>();
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
        if (Input.GetKey(KeyCode.Space)&&IsOnGround())
        {
            _playerRigidbody.AddForce(Vector2.up * _jumpForce);
        }
    }

    private bool IsOnGround()
    {
        bool grounded = Physics2D.OverlapCircle(_groundCheker.transform.position, _groundCheker.radius, _groundMask);

        return grounded;
    }
}
