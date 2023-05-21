using System.Collections;
using System.Collections.Generic;
using TMPro;
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
            PlayerController.Instance.playerData.playerGo, 
            DeleteItemData, 
            itemConstant.moveAwaySpeed, 
            itemConstant.followSpeed, 
            expPoint);

        go.TryGetComponent<ItemEXP>(out item);

        item.OnReset();

        itemDataManager.AddExp(ref item);
    }

    public void OnItemEXP(OBJECT_TYPE myType, Vector3 spawnPos, GameObject target, float farwaySpeed, float followSpeed, float expPoint)
    {
        ItemEXP item = null;
        GameObject go = null;

        go = itemFactory.AddObject(myType, spawnPos, target, DeleteItemData, farwaySpeed, followSpeed, expPoint);

        go.TryGetComponent<ItemEXP>(out item);

        item.OnReset();

        itemDataManager.AddExp(ref item);
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
