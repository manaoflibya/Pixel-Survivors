using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChecker : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == MapController.Instance.mapData.playerTagName)
        {
            MapController.Instance.CheckTrigger(this.name);
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == MapController.Instance.mapData.playerTagName && this.name == MapController.Instance.mapData.trigger_Out)
        {
            MapController.Instance.MapOut();
        }

    }
}
