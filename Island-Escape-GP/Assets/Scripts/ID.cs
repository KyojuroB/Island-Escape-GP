using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ID : MonoBehaviour
{
    [SerializeField] int ItemID;
    [SerializeField] Sprite icon;
    [SerializeField] bool hold;

    public int GetItemID()
    {
        return ItemID;
    }
    public Sprite GetIcon()
    {
        return icon;
    }
    public bool Holdable()
    { 
        return hold;
    }

    private void Start()
    {
       icon = GetComponent<SpriteRenderer>().sprite;
    }
}
