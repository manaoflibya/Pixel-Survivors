using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoSingleton<MapController>
{
    public MapData mapData;


    public void InitMapController()
    {
        mapData.isFirstLeft = true;
        mapData.currentCenterTrigger.SetActive(false);
        TriggersActive(mapData.spareTriggers, false);
    }

    public void CheckTrigger(string name)
    {   
        if (name == mapData.trigger_Left)
        {
            MoveMap_Left();
        }
        else if(name == mapData.trigger_Right)
        {
            MoveMap_Right();
        }
        else if(name == mapData.trigger_Center)
        {
            ChangeCurrentMap();
        }
    }

    private void MoveMap_Right()
    {
        RectTransform currentRectTransform = mapData.currentMap.GetComponent<RectTransform>();
        RectTransform spareRectTransform = mapData.spareMap.GetComponent<RectTransform>();

        spareRectTransform.transform.position += new Vector3(currentRectTransform.sizeDelta.x, 0, 0);
    }

    private void MoveMap_Left()
    {
        if(mapData.isFirstLeft)
        {
            mapData.isFirstLeft = false;
            return;
        }
        

        RectTransform currentRectTransform = mapData.currentMap.GetComponent<RectTransform>();
        RectTransform spareRectTransform = mapData.spareMap.GetComponent<RectTransform>();

        spareRectTransform.transform.position += new Vector3(-currentRectTransform.sizeDelta.x, 0, 0);
    }

    private void ChangeCurrentMap()
    {
        // 현재 맵의 Trigger들은 끄고 현재 맵이 되는 Trigger들을 킨다.
        TriggersActive(mapData.currentTriggers, false);
        TriggersActive(mapData.spareTriggers, true);

        var changeGo = mapData.currentMap;
        mapData.currentMap = mapData.spareMap;
        mapData.spareMap = changeGo;

        var changeTriggers = mapData.currentTriggers;
        mapData.currentTriggers = mapData.spareTriggers;
        mapData.spareTriggers = changeTriggers;

        var changeTransforms = mapData.currentSpawnPoints;
        mapData.currentSpawnPoints = mapData.spareSpawnPoints;
        mapData.spareSpawnPoints = changeTransforms;

        var centerTrigger = mapData.currentCenterTrigger;
        mapData.currentCenterTrigger = mapData.spareCenterTrigger;
        mapData.spareCenterTrigger = centerTrigger;

        mapData.spareCenterTrigger.SetActive(true);
        mapData.currentCenterTrigger.SetActive(false);

    }

    public void MapOut()
    {
       // mapData.isMapOut = true;
    }

    public void TriggersActive(GameObject[] objects, bool isActive)
    {
        foreach (var data in objects)
        {
            data.SetActive(isActive);
        }

    }
}
