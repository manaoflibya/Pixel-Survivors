using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGravity : Item
{
    public int gravityUID;


    public override void OnReset()
    {
        base.OnReset();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && isFollowing.Equals(false))
        {
            isFollowing = true;
            coroutine = StartCoroutine(FollowTarget(FinishGravity));
        }
    }
   
    private void FinishGravity()
    {
        StopCoroutine(coroutine);
        finishAction?.Invoke();
        action?.Invoke(myType,gravityUID,this.gameObject);
    }

    public void ClearAllGravity()
    {
        finishAction?.Invoke();
        action?.Invoke(myType, gravityUID, this.gameObject);
    }
}
