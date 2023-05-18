using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectBatMan : Effect
{
    public int batManUID;

    private Vector3 rangeVec = new Vector3(0f, 0.2f, 0f);

    private int currentHitCount = 0;

    private float batManStoptime = 2f;
    private string stopMethodName = "StopBatMan";

    public override void OnReset()
    {
        base.OnReset();

        this.transform.position = spawnPos + rangeVec;
        this.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);

        currentHitCount = 0;

        Invoke(stopMethodName, batManStoptime);
    }

    private void FixedUpdate()
    {
        this.transform.Translate(dir * Time.deltaTime * speed);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == PixelGameManager.Instance.cameraController.cameraData.cameraTagName)
        {
            if(hitCount == currentHitCount)
            {
                StopBatMan();
                return;
            }

            Vector3 incomingVector = dir;
            incomingVector.Normalize();

            Vector3 normalVector = collision.ClosestPoint(transform.position);
            Vector3 reflectVector = Vector3.Reflect(-normalVector, incomingVector);

            dir = reflectVector.normalized;

            this.transform.rotation = Quaternion.LookRotation(Vector3.forward, dir.normalized);
        }

        if(collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.gameObject.GetComponent<Monster>().TakeDamage(damage);
        }
    }

    private void StopBatMan()
    {
        action?.Invoke(myType, batManUID,this.gameObject);
    }
}
