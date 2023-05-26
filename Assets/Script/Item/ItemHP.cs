using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHP : Item
{
    public int itemHPUID;

    public override void OnReset()
    {
        base.OnReset();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && isFollowing.Equals(false))
        {
            isFollowing = true;
            coroutine = StartCoroutine(FollowTarget(FinishItemHP));
        }
    }

    private void FinishItemHP()
    {
        StopCoroutine(coroutine);
        PlayerController.Instance.TakeHeal(point);
        action?.Invoke(myType, itemHPUID, this.gameObject);
    }

    public void ClearAllHP()
    {
        action?.Invoke(myType, itemHPUID, this.gameObject);
    }
}
