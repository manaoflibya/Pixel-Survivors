using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBat : Monster
{
    public int batUID;


    

    public void Start()
    {
        this.transform.position = spawnPos;
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, PlayerController.Instance.GetPlayerVec(), speed * Time.deltaTime);  
    }


    public override void TakeDamage(float damage)
    {
        Debug.Log("Child TakeDamage");
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
        monsterAction?.Invoke(myType, batUID);
    }
}
