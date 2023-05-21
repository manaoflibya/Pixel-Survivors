using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEXP : Item
{
    public int expUID;

    public GameObject redEXP;
    public GameObject greenEXP;
    public GameObject blueEXP;
        

    private float distance = 0.9f;
    private float closerDistance = 0.2f;
    private float waitTime = 0.05f;
    private float redPoint = 35f;
    private float bluePoint = 20f;
    private float greenPoint = 1f;

    private bool isFollowing = false;


    public override void OnReset()
    {
        base.OnReset();
        isFollowing = false;

        ChangeExpColor();
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && isFollowing.Equals(false)) 
        {
            Debug.Log("ONTrigger");
            isFollowing = true;
            coroutine = StartCoroutine(FollowTarget(distance, closerDistance, waitTime, FinishEXP));
        }
    }

    private void FinishEXP()
    {
        PlayerController.Instance.TakeEXP(point);
        StopCoroutine(coroutine);
        action?.Invoke(myType, expUID, this.gameObject);
    }

    private void ChangeExpColor()
    {
        if (point > redPoint)
        {
            redEXP.SetActive(true);
            blueEXP.SetActive(false);
            greenEXP.SetActive(false);
        }
        else if (point > bluePoint)
        {
            redEXP.SetActive(false);
            blueEXP.SetActive(true);
            greenEXP.SetActive(false);
        }
        else if(point > greenPoint)
        {
            redEXP.SetActive(false);
            blueEXP.SetActive(false);
            greenEXP.SetActive(true);
        }
    }
}
