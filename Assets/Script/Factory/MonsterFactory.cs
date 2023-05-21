using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : ObjectFactory
{
    public GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE,int,GameObject> monsterAction , float health, float damage, float speed, Vector3 size, Action<Vector3, float> monsterDeadAction, float expPoint)
    {
        Monster go = ObjectPool.Instance.Get<Monster>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.target = target;
        go.monsterAction = monsterAction;
        go.damage = damage;
        go.health = health;
        go.speed = speed;
        go.size = size;
        go.myType = myType;
        go.spawnPos = spawnPos;
        go.monsterDeadAction = monsterDeadAction;
        go.expPoint = expPoint;

        return go.gameObject;
    }

    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<Monster>(myType, go);
    }
}
