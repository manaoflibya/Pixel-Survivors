using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : ObjectFactory
{
    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE,int,GameObject> monsterAction , float health, float speed, Vector3 size)
    {
        Monster go = ObjectPool.Instance.Get<Monster>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.target = target;
        go.monsterAction = monsterAction;
        go.health = health;
        go.speed = speed;
        go.size = size;
        go.myType = myType;
        go.spawnPos = spawnPos;
        
        return go.gameObject;
    }

    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<Monster>(myType, go);
    }
}
