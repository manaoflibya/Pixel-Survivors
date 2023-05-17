using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class EffectPoison : Effect
{
    public GameObject poisonBall;
    public GameObject poisonBubble;
    public CapsuleCollider2D capsuleCollider;
    public int posionUID;

    private Vector3 rangeVec = new Vector3(0f, 0.1f, 0f);

    private string finishMoveMethodName = "FinishMoveTime";
    private float finishMoveTime = 1f;
    private bool finishMove = false;

    private string finishBubbleMethodName = "FinishBubbleTime";
    private float bubbleTickTime = 0.5f;

    public override void OnReset()
    {
        base.OnReset();

        poisonBall.SetActive(true);
        poisonBubble.SetActive(false);
        capsuleCollider.enabled = false;
        finishMove = false;

        Invoke(finishMoveMethodName, finishMoveTime);

        this.transform.position = spawnPos + rangeVec;

        this.transform.RotateAround(spawnPos, axis, angle);

        dir = this.transform.position - spawnPos;
        dir.Normalize();
    }

    private void FixedUpdate()
    {
        if (finishMove.Equals(false))
        {
            this.transform.position += dir * Time.deltaTime * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeTickDamageStart(damage,bubbleTickTime);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == PixelGameManager.Instance.monsterController.constant.monsterTagName)
        {
            collision.GetComponent<Monster>().TakeTickDamageFinish();
        }
    }

    private void FinishMoveTime()
    {
        poisonBall.SetActive(false);
        poisonBubble.SetActive(true);
        capsuleCollider.enabled = true;
        finishMove = true;
        Invoke(finishBubbleMethodName,duration);
    }
    
    private void FinishBubbleTime()
    {
        action?.Invoke(myType,posionUID,this.gameObject);
    }
}
