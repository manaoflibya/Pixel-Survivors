using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBounceBall : Effect
{
    public int bounceBallUID;


    private string stopBounceMothodName = "StopBounceBall";

    public override void OnReset()
    {
        base.OnReset();

        Invoke(stopBounceMothodName, duration);

        this.transform.position = spawnPos;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);
    }

    private void FixedUpdate()
    {
        this.transform.position += dir * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == PixelGameManager.Instance.monsterController.GetMonsterConstant().monsterTagName)
        {
            Vector3 incomingVector = dir;
            incomingVector.Normalize();

            Vector3 normalVector = collision.contacts[0].normal;
            Vector3 reflectVector = Vector3.Reflect(incomingVector, normalVector);

            dir = reflectVector.normalized;

            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);

            collision.gameObject.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void StopBounceBall()
    {
        action?.Invoke(myType, bounceBallUID, this.gameObject);
    }
}

