using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
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

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, System.Action<OBJECT_TYPE,int,GameObject> action, float health, float speed, float size = 1f)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, float speed, float damage)
    {
        return null;
    }

    //Effect FireBall 사용
    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, float size = 1)
    {
        return null;
    }

    public virtual void RecycleObject(OBJECT_TYPE myType, GameObject go)  // 작업 더 해야함.
    {
    }

    public virtual void RecycleObject(OBJECT_TYPE myType, GameObject go, Action action)
    {
    }
}
