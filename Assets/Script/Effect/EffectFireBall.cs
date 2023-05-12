using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.U2D;
using UnityEngine;

public class EffectFireBall : Effect
{
    public int fireBallUID;

    private void Start()
    {
        this.transform.position = spawnPos;
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position , Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }
}

