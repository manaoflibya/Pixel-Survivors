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
    public Action finishAction;
    public float moveAwaySpeed;
    public float followSpeed;
    public float point;

    protected Coroutine coroutine;
    protected bool isFollowing = false;

    private float distance = 1f;
    private float closerDistance = 0.1f;
    private float waitTime = 0.05f;


    public virtual void OnReset()
    {
        this.transform.position = spawnPos;
        isFollowing = false;
    }


    protected IEnumerator FollowTarget(Action action = null)
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
