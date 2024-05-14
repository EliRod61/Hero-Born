using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    private int _itemsCollected = 0;
    private int _playerHP = 10;

    //public variables with get and set properties 
    public int Items
    {
        get { return _itemsCollected; }
        
        set {
            _itemsCollected = value;
            Debug.LogFormat("Items: {0}", _itemsCollected);
        }
    }
    public int HP
    {
        get { return _playerHP; }
        set {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);
        }
    }
}
