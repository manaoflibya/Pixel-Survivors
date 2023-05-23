using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemFactory : ObjectFactory
{
    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float moveAwaySpeed, float followSpeed, float value)
    {
        Item go = ObjectPool.Instance.Get<Item>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.target = target;
        go.action = action;
        go.moveAwaySpeed =  moveAwaySpeed;
        go.followSpeed = followSpeed;
        go.point = value;

        return go.gameObject;
    }

    public GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float moveAwaySpeed, float followSpeed, Action finishAction)
    {
        Item go = ObjectPool.Instance.Get<Item>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.target = target;
        go.action = action;
        go.moveAwaySpeed = moveAwaySpeed;
        go.followSpeed = followSpeed;
        go.finishAction = finishAction;

        return go.gameObject;
    }

    public GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, System.Action<OBJECT_TYPE, int, GameObject> action)
    {
        Item go = ObjectPool.Instance.Get<Item>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.action = action;

        return go.gameObject;
    }

    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<Item>(myType, go);
    }
}
