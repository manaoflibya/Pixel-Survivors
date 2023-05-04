using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public GameObject player;

    private bool allowMove;
    public bool AllowMove
    {
        get { return allowMove; } 
        set
        {
            allowMove = value;
        }
    }

}
