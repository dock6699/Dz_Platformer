using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoinsCollect : MonoBehaviour
{
    private int _coinsCount;

    private void Start()
    {
        _coinsCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Coin>())
        {
            _coinsCount ++;
            Debug.Log(_coinsCount);
        }
    }
}
