using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Sockets;
using UnityEditor.U2D;
using UnityEngine;

public class EffectFireBall : Effect
{
    public int fireBallUID;

    public GameObject exposionEffect;
    public GameObject trailEffect;

    private float stopExplisionTime = 0.3f;
    private float floorExplosionTime = 0.8f;

    private string playAnimMethodName = "StartExplosion";
    private string stopAnimMethodName = "StopExplision";

    private void Start()
    {
    }

    private void OnEnable()
    {
        this.transform.localScale = size;
        this.transform.position = spawnPos;

        Invoke(playAnimMethodName, floorExplosionTime);
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position , Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
            StartExplosion();
        }
    }

    private void StartExplosion()
    {
        exposionEffect.SetActive(true);
        trailEffect.SetActive(false);
        Invoke(stopAnimMethodName, stopExplisionTime);
    }

    private void StopExplision()
    {
        action?.Invoke(myType, fireBallUID, this.gameObject);
        exposionEffect.SetActive(false);
        trailEffect.SetActive(true);
    }
}

