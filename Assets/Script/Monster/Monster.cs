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
    public Vector3 size;

    public Action<OBJECT_TYPE,int, GameObject> monsterAction;

    [SerializeField]
    protected Animator monsterAnimator;

    protected string animDeathTriggerName = "Death";

    protected bool isDead = false;

    public void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        this.transform.position = spawnPos;
        this.transform.localScale = size;

    }

    protected void OnEnable()
    {
        isDead = false;

    }

    public virtual void TakeDamage(float damage)
    {
        //Debug.Log("Parent TakeDamage");

        //health -= damage;

        //if (health <= 0)
        //{
        //    Death();
        //}
    }

    protected void Death()
    {
        monsterAnimator.SetTrigger(animDeathTriggerName);
        isDead = true;  
    }

    protected bool GetActive()
    {
        return this.gameObject.activeSelf;
    }
}
