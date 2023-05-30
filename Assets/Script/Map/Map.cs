using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject myMap;

    public RectTransform myRect;

    public GameObject leftTrigger;
    public GameObject rightTrigger;
    public GameObject centerTriger;

    public Transform[] mySpawnPoints;


    public void ActiveCenterTrigger(bool isActive)
    {
        centerTriger.SetActive(isActive);
    }

    public void MoveTransform(Vector3 movePos)
    {
        myRect.transform.position += movePos;
    }

    public void ChangePos(Vector3 pos)
    {
        myMap.transform.position = pos;
    }

    public Transform[] GetSpawnPointTransforms()
    {
        return mySpawnPoints;
    }

    public Vector3 GetMapPos()
    {
        return myMap.transform.position;
    }
}
