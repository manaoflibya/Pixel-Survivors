using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBoomb : Monster
{
    private bool isExplosion;
    private bool isOneHit;


    public override void OnReset()
    {
        base.OnReset();
        isExplosion = false;
        isOneHit = false;
    }

    private void FixedUpdate()
    {
        if(isDead.Equals(false))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position , target.transform.position, Time.deltaTime * speed); 
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);

        health -= damage;

        if(health <= 0)
        {
            isExplosion = true;
            Death();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(isExplosion.Equals(true) && isOneHit.Equals(false) && collision.tag == PlayerController.Instance.playerData.playerTagName)
        {
            isOneHit = true;
            PlayerController.Instance.TakeDamage(damage);
        }
    }

    private void FinishDeadAnim()
    {
        monsterAction?.Invoke(myType, monsterUID, this.gameObject);
        monsterDeadAction?.Invoke(this.transform.position, expPoint);

    }
}
