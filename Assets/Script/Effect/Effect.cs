using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public OBJECT_TYPE myType;
    public Vector3 spawnPos = new Vector3();
    public Vector3 dir;
    public GameObject target;
    public Action<OBJECT_TYPE,int, GameObject> action;
    public float damage;
    public float speed;
    public float duration;
    public float angle;
    public Vector3 size;
    public Vector3 axis;
    public Transform parent;
    public int hitCount;

    public virtual void OnReset()
    {
        this.transform.localScale = size;   
    }
}
