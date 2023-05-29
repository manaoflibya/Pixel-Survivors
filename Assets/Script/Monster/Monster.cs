using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int monsterUID;
    public Vector3 spawnPos;
    public GameObject target;

    public OBJECT_TYPE myType;
    public float health;
    public float damage;
    public float speed;
    public Vector3 size;
    public Action<OBJECT_TYPE,int, GameObject> monsterAction;
    public Action<Vector3, float> monsterDeadAction;

    public float expPoint;

    [SerializeField]
    protected Animator monsterAnimator;

    protected string animDeathTriggerName = "Death";
    protected string animHitTriggerName = "Hit";

    protected bool isDead = false;

    protected bool startTickDamage = false;
    protected float tickDamage = 0f;

    protected WaitForSeconds takeDamageWaitSeconds;
    protected WaitForSeconds tickAttackWaitSeconds = new WaitForSeconds(0.5f);

    protected bool startTickAttack = false;

    private Coroutine takeTickDamageCoroutine;
    private Coroutine tickAttackCoroutine;

    public void Start()
    {
        monsterAnimator = GetComponent<Animator>();
    }

    public virtual void OnReset()
    {
        this.transform.position = spawnPos;
        this.transform.localScale = size;

        isDead = false;
        startTickDamage = false;
        startTickAttack = false;
        tickDamage = 0f;

    }

    public virtual void TakeDamage(float damage)
    {
        PixelGameManager.Instance.floatingUIController.OnFloatingDamageUI(this.gameObject.transform.position, (int)damage);
    }


    public virtual void TakeTickDamageStart(float damage,float tickTime)
    {
        startTickDamage = true;
        tickDamage = damage;
        takeDamageWaitSeconds = new WaitForSeconds(tickTime);
        takeTickDamageCoroutine = StartCoroutine(TickDamageStart());
    }    

    public virtual void TakeTickDamageFinish()
    {
        startTickDamage = false;
        StopCoroutine(takeTickDamageCoroutine);

    }

    protected void Death()
    {
        monsterAnimator.SetTrigger(animDeathTriggerName);
        isDead = true;

        if(takeTickDamageCoroutine != null)
        {
            StopCoroutine(takeTickDamageCoroutine);
        }

        if(tickAttackCoroutine != null)
        {
            StopCoroutine(tickAttackCoroutine);
        }
    }

    protected bool GetActive()
    {
        return this.gameObject.activeSelf;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PlayerController.Instance.playerData.playerTagName)
        {
            startTickAttack = true;
            tickAttackCoroutine = StartCoroutine(AttakTickDamage());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName)
        {
            startTickAttack = false;

            StopCoroutine(tickAttackCoroutine);
        }
    }

    IEnumerator TickDamageStart()
    {
        while(startTickDamage)
        {
            TakeDamage(tickDamage);

            yield return takeDamageWaitSeconds;
        }
    }

    IEnumerator AttakTickDamage()
    {
        while (startTickAttack)
        {
            PlayerController.Instance.TakeDamage(damage);

            yield return tickAttackWaitSeconds;
        }
    }

    public void AllDead()
    {
        monsterAction?.Invoke(myType,monsterUID,this.gameObject);
    }
}
