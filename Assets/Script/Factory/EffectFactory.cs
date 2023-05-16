
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EffectFactory : ObjectFactory
{

    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, float speed, float damage)
    {
        Effect go = ObjectPool.Instance.Get<Effect>(myType);
        go.myType = myType;
        go.spawnPos = spawnPos;
        go.dir = dir;
        go.speed = speed;
        go.damage = damage;

        return go.gameObject;
    }

    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, float size = 1)
    {
        Effect go = ObjectPool.Instance.Get<Effect>(myType);
        go.myType = myType; 
        go.spawnPos = spawnPos; 
        go.target = target;
        go.action = action;
        go.speed = speed;
        go.damage = damage;
            
        return go.gameObject;
    }
    public override void RecycleObject(OBJECT_TYPE myType, GameObject go)
    {
        ObjectPool.Instance.Recycle<Monster>(myType,go);
    }
}
