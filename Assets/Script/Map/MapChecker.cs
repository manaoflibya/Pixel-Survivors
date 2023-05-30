using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    public Map myParentMap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName)
        {
            MapController.Instance.CheckTrigger(myParentMap);
        }        
    }
}
