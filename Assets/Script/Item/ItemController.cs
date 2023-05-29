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

    public void OnItemBox(Vector3 spawnPos)
    {
        ItemBox item = null;
        GameObject go = null;

        go = itemFactory.AddObject(OBJECT_TYPE.ITEMBOXTYPE, spawnPos, DeleteItemData);

        go.TryGetComponent<ItemBox>(out item);

        item.OnReset();

        itemDataManager.AddItemBox(ref item);
    }

    public void OnItemHP(Vector3 spawnPos, float healPoint)
    {
        ItemHP item = null;
        GameObject go = null;

        go = itemFactory.AddObject(
            OBJECT_TYPE.ITEMHPTYPE,
            spawnPos,
            PlayerController.Instance.GetPlayerObject(),
            DeleteItemData,
            itemConstant.moveAwaySpeed,
            itemConstant.followSpeed,
            healPoint);

        go.TryGetComponent<ItemHP>(out item);

        item.OnReset();

        itemDataManager.AddItemHP(ref item);
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
    
    public void DeleteAllItems()
    {
        List<ItemEXP> itemExp = new List<ItemEXP>();
        List<ItemBox> itemBoxes = new List<ItemBox>();
        List<ItemHP> itemsHP = new List<ItemHP>();  
        List<ItemGravity> itemGravity = new List<ItemGravity>();

        itemDataManager.FindAllActiveEXP(ref itemExp);

        foreach(var exp in itemExp)
        {
            exp.ClearAllEXP();
        }

        itemDataManager.FindAllActiveBox(ref itemBoxes);

        foreach(var box in itemBoxes)
        {
            box.ClearAllBox();
        }

        itemDataManager.FindAllActiveHP(ref itemsHP);

        foreach( var hp in itemsHP)
        {
            hp.ClearAllHP(); 
        }

        itemDataManager.FindAllActiveGravity(ref itemGravity);

        foreach(var gravity in itemGravity)
        { 
            gravity.ClearAllGravity(); 
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
            case OBJECT_TYPE.ITEMGRAVITYTYPE:
                {
                    itemDataManager.DelGravity(uid);
                }
                break;
            case OBJECT_TYPE.ITEMBOXTYPE:
                {
                    itemDataManager.DelItemBox(uid);
                }
                break;
            case OBJECT_TYPE.ITEMHPTYPE:
                {
                    itemDataManager.DelItemHP(uid);
                }
                break;

        }

        itemFactory.RecycleObject(myType, go);
    }
}
