using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName)
        {
            MapController.Instance.CheckTrigger(this.name);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && this.name == MapController.Instance.mapData.trigger_Out)
        {
            MapController.Instance.MapOut();
        }
    }
}
