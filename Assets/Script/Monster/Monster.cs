using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public Vector3 spawnPos = new Vector3();
    public OBJECT_TYPE myType;

    public float health;
    public float speed;
    public float size;

    public Action<OBJECT_TYPE,int> monsterAction;

    [SerializeField]
    protected Animator monsterAnimator;

    protected string animDeathTriggerName = "Death";

    public void Start()
    {
        monsterAnimator = GetComponent<Animator>(); 
    }

    public virtual void TakeDamage(float damage)
    {
        Debug.Log("Parent TakeDamage");

        health -= damage;

        if (health <= 0)
        {
            Death();
        }
    }

    protected void Death()
    {
        monsterAnimator.SetTrigger(animDeathTriggerName);
    }

    protected bool GetActive()
    {
        return this.gameObject.activeSelf;
    }
}
