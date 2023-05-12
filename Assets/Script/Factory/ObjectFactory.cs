using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFactory
{
    public ObjectFactory()
    {
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, System.Action<OBJECT_TYPE,int> monsterAction, float health, float speed, float size = 1f)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, float speed, float damage)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, float speed, float damage)
    {
        return null;
    }

    public virtual GameObject RecycleObject(OBJECT_TYPE myType)  // 작업 더 해야함.
    {
        return null;
    }
}
