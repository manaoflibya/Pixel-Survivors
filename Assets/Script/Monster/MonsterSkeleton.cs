using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSkeleton : Monster
{
    private void FixedUpdate()
    {
        if (isDead.Equals(false))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position, Time.deltaTime * speed);
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        health -= damage;
        
        if(health <= 0)
        {
            Death();
        }
    }

    private void FinishDaedAnim()
    {
        monsterAction?.Invoke(myType, monsterUID, this.gameObject);
    }
}
