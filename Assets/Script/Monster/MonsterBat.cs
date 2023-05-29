using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBat : Monster
{

    private void FixedUpdate()
    {
        if (isDead.Equals(false))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position ,target.transform.position , speed * Time.deltaTime);  
        }
    }


    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        health -= damage;

        if (health <= 0)
        {
            Death();
        }
    }

    /// <summary>
    /// Anim Callback으로 사용
    /// </summary>
    private void FinishDaedAnim()
    {
        monsterAction?.Invoke(myType, monsterUID,this.gameObject);
        monsterDeadAction?.Invoke(this.transform.position, expPoint);
    }
}
