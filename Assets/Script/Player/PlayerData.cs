using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject player;

    public bool allowMove
    {
        get { return allowMove; } 
        set
        {
            allowMove = value;
        }
    }

}
