using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectKunai : Effect
{
    public int kunaiUID;

    private Vector3 rangeVec = new Vector3(0f, 1.8f, 0f);

    private string stopMethod = "StopKunaiEffect";

    private void Start()
    {
    }

    public override void OnReset()
    {
        base.OnReset();
        this.transform.position = spawnPos + rangeVec;
        
        this.transform.SetParent(parent);

        Invoke(stopMethod, duration);
        this.transform.RotateAround(parent.position, axis, angle);
    }

    private void FixedUpdate()
    {
        this.transform.RotateAround(parent.position, axis,  Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void StopKunaiEffect()
    {
        action?.Invoke(myType,kunaiUID,this.gameObject);
    }
}
