using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBat : Monster
{
    public int batUID;

    private void FixedUpdate()
    {
        if (isDead.Equals(false))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.Instance.GetPlayerVec(), speed * Time.deltaTime);  
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
    private void FinishDeath()
    {
        //recycle필요
        monsterAction?.Invoke(myType, batUID,this.gameObject);
    }
}
