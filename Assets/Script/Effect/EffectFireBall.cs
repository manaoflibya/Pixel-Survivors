using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectFireBall : Effect
{
    public int fireBallUID;

    public GameObject exposionEffect;
    public GameObject fireBallImage;
    public GameObject trailEffect;

    private float stopExplosionTime = 0.3f;
    private float floorExplosionTime = 0.8f;

    private string playAnimMethodName = "StartExplosion";
    private string stopAnimMethodName = "StopExplosion";

    private bool isExplo = false;

    public override void OnReset()
    {
        base.OnReset();

        this.transform.position = spawnPos;

        fireBallImage.SetActive(true);
        exposionEffect.SetActive(false);

        isExplo = false;

        Invoke(playAnimMethodName, floorExplosionTime);
    }

    private void FixedUpdate()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, target.transform.position , Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterTagName && isExplo.Equals(false))
        {
            SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.fireBallSoundClip, this.transform.position, 0.5f);

            collision.GetComponent<Monster>().TakeDamage(damage);

            isExplo = true;
            StartExplosion();
        }
    }

    private void StartExplosion()
    {
        fireBallImage.SetActive(false);

        exposionEffect.SetActive(true);
        Invoke(stopAnimMethodName, stopExplosionTime);
    }

    private void StopExplosion()
    {
        fireBallImage.SetActive(false);
        exposionEffect.SetActive(false);
        action?.Invoke(myType, fireBallUID, this.gameObject);
    }
}

