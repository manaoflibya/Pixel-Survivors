using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapData : MonoBehaviour
{
    public Transform[] currentSpawnPoints;
    public Transform[] spareSpawnPoints;

    public GameObject currentMap;
    public GameObject[] currentTriggers;
    public GameObject currentCenterTrigger;

    public GameObject spareMap;
    public GameObject[] spareTriggers;
    public GameObject spareCenterTrigger;

    [HideInInspector]
    public string map_1 = "Map_1";
    [HideInInspector]
    public string map_2 = "Map_2";

    [HideInInspector]
    public string playerTagName = "Player";
    [HideInInspector]
    public string trigger_Right = "Trigger_Right";
    [HideInInspector]
    public string trigger_Left = "Trigger_Left";
    [HideInInspector]
    public string trigger_Out = "Trigger_Out";

    [HideInInspector]
    public string trigger_Center = "Trigger_Center";

    [HideInInspector]
    public bool isFirstLeft = true;
}
