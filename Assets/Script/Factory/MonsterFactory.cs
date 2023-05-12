using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : ObjectFactory
{
    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos,System.Action<OBJECT_TYPE,int> monsterAction , float health, float speed, float size = 1f)
    {
        Monster go = ObjectPool.Instance.Get<Monster>(myType);

        go.myType = myType;
        go.spawnPos = spawnPos;
        go.monsterAction = monsterAction;
        go.health = health;
        go.speed = speed;
        go.size = size;
        go.myType = myType;
        go.spawnPos = spawnPos;
        
        return go.gameObject;
    }
}
