using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Item : MonoBehaviour
{
    public OBJECT_TYPE myType;
    public Vector3 spawnPos;
    public GameObject target;
    public Action<OBJECT_TYPE, int, GameObject> action;
    public float moveAwaySpeed;
    public float followSpeed;
    public float point;

    protected Coroutine coroutine;

    public virtual void OnReset()
    {
        this.transform.position = spawnPos;
    }


    protected IEnumerator FollowTarget(float distance, float closerDistance, float waitTime, Action action = null)
    {
        Vector3 dir = this.transform.position - target.transform.position;

        dir.Normalize();

        while (Vector3.Distance(this.transform.position, target.transform.position) < distance)
        {
            this.transform.position += (dir * Time.deltaTime * moveAwaySpeed);

            yield return null;
        }

        yield return new WaitForSeconds(waitTime);

        while (Vector3.Distance(this.transform.position, target.transform.position) > closerDistance)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * followSpeed);
            
            yield return null;
        }

        action?.Invoke();
    }
}
