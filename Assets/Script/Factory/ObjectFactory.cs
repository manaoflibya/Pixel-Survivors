using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.EditorTools;
using UnityEditor.Tilemaps;
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

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, System.Action<OBJECT_TYPE, int, GameObject> action, float health, float damage, float speed, Vector3 size)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, Vector3 size)
    {
        return null;
    }

    //Effect FireBall 사용
    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, Vector3 size)
    {
        return null;
    }

    // EffectKunai 사용
    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Transform parent, Vector3 axis, float angle, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, float duration, Vector3 size)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 axis, float angle, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, float duration, Vector3 size)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, float duration, Vector3 size)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, Vector3 dir, int hitCount, System.Action<OBJECT_TYPE, int, GameObject> action, float speed, float damage, Vector3 size)
    {
        return null;
    }

    public virtual GameObject AddObject(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, System.Action<OBJECT_TYPE, int, GameObject> monsterAction, float health, float damage, float speed, Vector3 size)
    {
        return null;
    }

    public virtual void RecycleObject(OBJECT_TYPE myType, GameObject go) 
    {
    }

    public virtual void RecycleObject(OBJECT_TYPE myType, GameObject go, Action action)
    {
    }
}
