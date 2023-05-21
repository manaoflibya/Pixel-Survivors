using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : Item
{
    public int itemBoxUID;

    public override void OnReset()
    {
        base.OnReset();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && isFollowing.Equals(false))
        {
            ///// UI 생성해야함.
            ///
            Debug.Log("<color=cyan> Getting Box (Please Create Box Item UI </color>");

            action?.Invoke(myType, itemBoxUID, this.gameObject);
        }
    }
}
