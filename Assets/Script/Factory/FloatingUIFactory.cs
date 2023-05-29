using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingUIFactory : ObjectFactory
{
    public GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, System.Action<OBJECT_TYPE, int, GameObject> action, Color color, int value)
    {
        FloatingUI go = ObjectPool.Instance.Get<FloatingUI>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.action = action;
        go.myColor = color;
        go.myValue = value;

        return go.gameObject;
    }

    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<FloatingUI>(myType, go);   
    }
}
