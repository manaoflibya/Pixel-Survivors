using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.UIElements;

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

    protected bool startTickDamage = false;
    protected float tickDamageTime = 0f;
    protected float tickDamage = 0f;

    public void Start()
    {
        monsterAnimator = GetComponent<Animator>();
        this.transform.position = spawnPos;
        this.transform.localScale = size;

    }

    protected void OnEnable()
    {
        isDead = false;
        startTickDamage = false;
        tickDamageTime = 0f;
        tickDamage = 0f;
    }

    public virtual void TakeDamage(float damage)
    {

    }


    public virtual void TakeTickDamageStart(float damage,float tickTime)
    {
        startTickDamage = true;
        tickDamage = damage;
        tickDamageTime = tickTime;

        StartCoroutine(TickDamageStart());
    }    

    public virtual void TakeTickDamageFinish()
    {
        startTickDamage = false;
        StopCoroutine(TickDamageStart());

    }

    protected void Death()
    {
        monsterAnimator.SetTrigger(animDeathTriggerName);
        isDead = true;
        StopCoroutine(TickDamageStart());
    }

    protected bool GetActive()
    {
        return this.gameObject.activeSelf;
    }

    IEnumerator TickDamageStart()
    {
        while(startTickDamage)
        {
            TakeDamage(tickDamage);
            yield return new WaitForSeconds(tickDamageTime);
        }
    }
}
