using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect : MonoBehaviour
{
    public OBJECT_TYPE myType;
    public Vector3 spawnPos = new Vector3();
    public Vector3 dir;
    public GameObject target;

    public float damage;
    public float speed;

    protected void Show()
    {

    }

    protected void Hide()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("<color=green>collision.collider.tag</color>" + collision.tag);

    }
}
