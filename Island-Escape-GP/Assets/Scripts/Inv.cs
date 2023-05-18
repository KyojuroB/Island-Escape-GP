using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invintory : MonoBehaviour
{
    public GameObject inventoryPanel;
    
    Player player;
    public List<UIslots> slots = new List<UIslots> ();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void setup()
    {
       // if(slots.Count == player.inv.UIslots.Count)
       // {
            //for (int i = 0; i < UIslots.Count; i++)
           // {
               // if (player.inventory.slots[i].type != CollectableType.NONE)
           // }
      //  }
    }


}
