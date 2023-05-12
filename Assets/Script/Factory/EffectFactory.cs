
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public override GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, float speed, float damage)
    {
        Effect go = ObjectPool.Instance.Get<Effect>(myType);
        go.myType = myType; 
        go.spawnPos = spawnPos; 
        go.target = target;
        go.speed = speed;
        go.damage = damage;
            
        return go.gameObject;
    }
}
