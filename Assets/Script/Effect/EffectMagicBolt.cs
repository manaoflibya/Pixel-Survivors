using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectMagicBolt : Effect
{
    public int magicBoltUID;

    private float stopMethodTime = 2f;
    private string stopMethodName = "StopMagicBolt";

    private void Start()
    {
    }

    public override void OnReset()
    {
        base.OnReset();

        this.transform.position = spawnPos;
        this.transform.localScale = size;

        Invoke(stopMethodName, stopMethodTime);
    }

    private void FixedUpdate()
    {
        this.transform.Translate(dir * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void StopMagicBolt()
    {
        action?.Invoke(myType, magicBoltUID, this.gameObject);
    }
}
