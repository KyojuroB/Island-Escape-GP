using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Hotbar : MonoBehaviour
{
    int currentSlot = 1;
    int totalSlots = 7;
    List<Image> slots;
    [SerializeField] List<bool> slotsOccupied;
    [SerializeField] List<int> slotID;
    GameObject Selecter;
    // Start is called before the first frame update
    void Start()
    {
        Selecter = GameObject.FindGameObjectWithTag("SlotSelecter");
       
        foreach (Transform child in transform)
        {
            slotsOccupied.Add(false);

        }
        foreach (Transform child in transform)
        {
           slotID.Add(0);
        }







    }

    // Update is called once per frame
    void Update()
    {
        SlotSelection();
    }


    public void AddItem(Sprite itemPic, int ID)
    {        int index = slotsOccupied.FindIndex(element => element == false);

        if (index != -1)
        {
            Debug.Log("NextSlotIs " + index);
        }
        else
        {
            Debug.Log("Inv is full");

          //  transform.GetChild(index).GetChild(0).gameObject.GetComponent<Image>().IsActive(false);
            transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = itemPic;



            if (slotID.Contains(ID))
            {
                {

                }
            }
        } 
    }




        public void SlotSelection()
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    currentSlot = 1;
                    Selecter.transform.position = transform.GetChild(0).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha2))
                {
                    currentSlot = 2;
                    Selecter.transform.position = transform.GetChild(1).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha3))
                {
                    currentSlot = 3;
                    Selecter.transform.position = transform.GetChild(2).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha4))
                {
                    currentSlot = 4;
                    Selecter.transform.position = transform.GetChild(3).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha5))
                {
                    currentSlot = 5;
                    Selecter.transform.position = transform.GetChild(4).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha6))
                {
                    currentSlot = 6;
                    Selecter.transform.position = transform.GetChild(5).transform.position;
                }
                if (Input.GetKeyDown(KeyCode.Alpha7))
                {
                    currentSlot = 7;
                    Selecter.transform.position = transform.GetChild(6).transform.position;
                }
            }
        }


    }
