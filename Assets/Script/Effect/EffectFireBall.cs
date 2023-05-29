using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFireBall : Effect
{
    public int fireBallUID;

    public GameObject exposionEffect;
    public GameObject trailEffect;

    private float stopExplosionTime = 0.3f;
    private float floorExplosionTime = 0.8f;

    private string playAnimMethodName = "StartExplosion";
    private string stopAnimMethodName = "StopExplosion";

    public override void OnReset()
    {
        base.OnReset();

        this.transform.position = spawnPos;

        trailEffect.SetActive(true);
        exposionEffect.SetActive(false);

        Invoke(playAnimMethodName, floorExplosionTime);
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position , Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterTagName)
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
            StartExplosion();
        }
    }

    private void StartExplosion()
    {
        exposionEffect.SetActive(true);
        trailEffect.SetActive(false);
        Invoke(stopAnimMethodName, stopExplosionTime);
    }

    private void StopExplosion()
    {
        trailEffect.SetActive(true);
        exposionEffect.SetActive(false);
        action?.Invoke(myType, fireBallUID, this.gameObject);
    }
}

