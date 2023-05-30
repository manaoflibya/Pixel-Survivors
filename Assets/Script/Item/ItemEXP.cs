using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEXP : Item
{
    public int expUID;

    public GameObject redEXP;
    public GameObject greenEXP;
    public GameObject blueEXP;
        

    private float redPoint = 35f;
    private float bluePoint = 20f;
    private float greenPoint = 1f;



    public override void OnReset()
    {
        base.OnReset();

        ChangeExpColor();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == PlayerController.Instance.playerData.playerTagName && isFollowing.Equals(false)) 
        {
            isFollowing = true;

            if(this.gameObject.activeSelf.Equals(true))
            {
                coroutine = StartCoroutine(FollowTarget(FinishEXP));
            }
        }
    }

    public void AllExpFollowTarget()
    {
        isFollowing = true;
        coroutine = StartCoroutine(FollowTarget(FinishEXP));
    }

    private void FinishEXP()
    {
        SoundManager.Instance.EffectPlay(SoundManager.Instance.soundData.expSoundClip, this.transform.position);

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

    public void ClearAllEXP()
    {
        action?.Invoke(myType, expUID, this.gameObject);
    }
}
