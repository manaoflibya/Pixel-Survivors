
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EffectFactory : ObjectFactory
{

    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, Vector3 size)
    {
        Effect go = ObjectPool.Instance.Get<Effect>(myType);
        go.myType = myType;
        go.spawnPos = spawnPos;
        go.dir = dir;
        go.action = action;
        go.speed = speed;
        go.damage = damage;
        go.size = size;

        return go.gameObject;
    }

    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, Vector3 size)
    {
        Effect go = ObjectPool.Instance.Get<Effect>(myType);
        go.myType = myType; 
        go.spawnPos = spawnPos; 
        go.target = target;
        go.action = action;
        go.speed = speed;
        go.damage = damage;
        go.size = size;
            
        return go.gameObject;
    }
    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<Monster>(myType,go);
    }
}
