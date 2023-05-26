using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ID : MonoBehaviour
{
    [SerializeField] int ItemID;
    [SerializeField] Sprite icon;

    public int GetItemID()
    {
        return ItemID;
    }
    public Sprite GetIcon()
    {
        return icon;
    }

    private void Start()
    {
       icon = GetComponent<SpriteRenderer>().sprite;
    }
}
