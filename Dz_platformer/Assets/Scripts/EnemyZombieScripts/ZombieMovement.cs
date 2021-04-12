using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Vector3[] _zoneBorders;

    private bool _isInPatrolZOne;
    private int _currentPoint;


    private void Start()
    {
        _zoneBorders = new Vector3[2];
        _currentPoint = 0;
        _zoneBorders[0] = new Vector3(0,0,0);
        _zoneBorders[1] = new Vector3(0, 0, 0);
        _isInPatrolZOne = false;

}
    private void Update()
    {      
        PatrolingZone();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.GetComponent<Block>())
        {
            _zoneBorders[0] = collision.bounds.min;
            _zoneBorders[1] = collision.bounds.max;

            _isInPatrolZOne = true;
        }
    }

    private void PatrolingZone()
    {
        if (_isInPatrolZOne)
        {

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(_zoneBorders[_currentPoint].x,transform.position.y,transform.position.z), _speed * Time.deltaTime);
            
            if (transform.position.x == _zoneBorders[_currentPoint].x)
            {
                Mirroring();
                _currentPoint++;
                if (_currentPoint >= _zoneBorders.Length)
                {
                    _currentPoint = 0;
                }
            }
        }
        else
        {
            transform.position = transform.position;
        }

    }

    private void Mirroring()
    {
  
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
    
    }
}
