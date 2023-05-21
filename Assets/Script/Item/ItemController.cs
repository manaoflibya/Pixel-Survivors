using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public ItemConstant itemConstant;
    private ItemFactory itemFactory;
    private ItemDataManager itemDataManager;

    private void Awake()
    {
        itemConstant = new ItemConstant();
        itemFactory = new ItemFactory();
        itemDataManager = new ItemDataManager();
    }

    public void OnItemEXP()
    {

    }

    public void OnItemEXP(Vector3 spawnPos, float expPoint)
    {
        ItemEXP item = null;
        GameObject go = null;

        go = itemFactory.AddObject(
            OBJECT_TYPE.ITEMEXPTYPE, 
            spawnPos, 
            PlayerController.Instance.GetPlayerObject(), 
            DeleteItemData, 
            itemConstant.moveAwaySpeed, 
            itemConstant.followSpeed, 
            expPoint);

        go.TryGetComponent<ItemEXP>(out item);

        item.OnReset();

        itemDataManager.AddExp(ref item);
    }

    public void OnItemEXP(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, float moveAwaySpeed, float followSpeed, float expPoint)
    {
        ItemEXP item = null;
        GameObject go = null;

        go = itemFactory.AddObject(myType, spawnPos, target, DeleteItemData, moveAwaySpeed, followSpeed, expPoint);

        go.TryGetComponent<ItemEXP>(out item);

        item.OnReset();

        itemDataManager.AddExp(ref item);
    }

    public void OnItemGravity(Vector3 spawnPos)
    {
        ItemGravity item = null;
        GameObject go = null;

        go = itemFactory.AddObject(
            OBJECT_TYPE.ITEMGRAVITYTYPE,
            spawnPos,
            PlayerController.Instance.GetPlayerObject(),
            DeleteItemData,
            itemConstant.moveAwaySpeed,
            itemConstant.followSpeed,
            UseGravityItem);

        go.TryGetComponent<ItemGravity>(out item);

        item.OnReset();

        itemDataManager.AddGravity(ref item);
    }

    private void UseGravityItem()
    {
        List<ItemEXP> exps = new List<ItemEXP>();

        itemDataManager.FindAllActiveEXP(ref exps);

        foreach(var exp in exps)
        {
            exp.AllExpFollowTarget();
        }
    }
    

    private void DeleteItemData(OBJECT_TYPE myType, int uid, GameObject go)
    {
        switch(myType)
        {
            case OBJECT_TYPE.ITEMEXPTYPE:
                {
                    itemDataManager.DelExp(uid);
                }
                break;
            case OBJECT_TYPE.ITEMBOXTYPE:
                {
                    itemDataManager.DelGravity(uid);
                }
                break;
            case OBJECT_TYPE.ITEMGRAVITYTYPE:
                {

                }
                break;
            case OBJECT_TYPE.ITEMHPTYPE:
                {

                }
                break;

        }

        itemFactory.RecycleObject(myType, go);
    }
}
