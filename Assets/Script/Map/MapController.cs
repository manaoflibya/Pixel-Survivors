 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoSingleton<MapController>
{
    public MapData mapData;

    public void Start()
    {
        mapData.initLeftPos = mapData.maps[0].GetMapPos();
        mapData.initCenterPos = mapData.maps[1].GetMapPos();
        mapData.initRightPos = mapData.maps[2].GetMapPos();
        InitTriggerActives();
    }

    public void InitMapController()
    {
        InitMapPos();
        InitTriggerActives();
    }

    private void InitTriggerActives()
    {
        mapData.maps[0].ActiveCenterTrigger(true);
        mapData.maps[1].ActiveCenterTrigger(false);
        mapData.maps[2].ActiveCenterTrigger(true);

    }

    private void InitMapPos()
    {
        mapData.maps[0].ChangePos(mapData.initLeftPos);
        mapData.maps[1].ChangePos(mapData.initCenterPos);
        mapData.maps[2].ChangePos(mapData.initRightPos);
    }

    public Transform[] GetcurrentSpawnPoints()
    {
        return mapData.maps[1].GetSpawnPointTransforms();
    }

    /// <summary>
    ///  0 : Left, 1 : Center, 2 : Right
    /// </summary>
    /// <param name="map"></param>
    public void CheckTrigger(Map map)
    {
        string mapName = map.name;

        //map.ActiveCenterTrigger(false);

        var data0 = mapData.maps[0];
        var data1 = mapData.maps[1];
        var data2 = mapData.maps[2];

        mapData.maps[0].ActiveCenterTrigger(false);
        mapData.maps[1].ActiveCenterTrigger(false);
        mapData.maps[2].ActiveCenterTrigger(false);

        if (mapName == mapData.left)
        {
            mapData.maps[0] = data2;
            mapData.maps[1] = data0;
            mapData.maps[2] = data1;

            mapData.maps[0].ChangePos(mapData.maps[1].GetMapPos());
            mapData.maps[0].MoveTransform(new Vector3(-mapData.maps[1].myRect.sizeDelta.x * 0.5f, 0, 0));

            StartCoroutine(ChangeTime());
        }
        else if(mapName == mapData.right)
        {
            mapData.maps[0] = data1;
            mapData.maps[1] = data2;
            mapData.maps[2] = data0;

            mapData.maps[2].ChangePos(mapData.maps[1].GetMapPos());
            mapData.maps[2].MoveTransform(new Vector3(mapData.maps[1].myRect.sizeDelta.x * 0.5f, 0, 0));

            StartCoroutine(ChangeTime());
        }
    }

    IEnumerator ChangeTime()
    {
        yield return new WaitForSeconds(1f);


        mapData.maps[0].ActiveCenterTrigger(true);
        mapData.maps[1].ActiveCenterTrigger(false);
        mapData.maps[2].ActiveCenterTrigger(true);


        mapData.maps[0].name = mapData.left;
        mapData.maps[1].name = mapData.center;
        mapData.maps[2].name = mapData.right;

    }
}
