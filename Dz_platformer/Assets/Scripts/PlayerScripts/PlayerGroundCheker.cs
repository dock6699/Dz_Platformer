using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheker : MonoBehaviour
{
    [SerializeField] private CircleCollider2D _groundCheker;
    [SerializeField] private LayerMask _groundMask;

    public bool CheckGroundCollision()
    {
        bool grounded = Physics2D.OverlapCircle(_groundCheker.transform.position, _groundCheker.radius, _groundMask);
        return grounded;
    }
}
