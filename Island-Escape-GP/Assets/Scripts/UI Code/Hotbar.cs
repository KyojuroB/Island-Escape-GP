using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection;

public class Hotbar : MonoBehaviour
{
    int currentSlot = 1;
    int totalSlots = 7;
    List<Image> slots;
    [SerializeField] Sprite defaultimg;
    [SerializeField] List<bool> slotsOccupied;
    [SerializeField] List<int> slotID;
    [SerializeField] List<int> amountInSlot;
    [SerializeField] List<bool> CanHoldThisSlot;
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
            CanHoldThisSlot.Add(false);

        }
        foreach (Transform child in transform)
        {
           slotID.Add(0);
        }
        foreach (Transform child in transform)
        {
            amountInSlot.Add(0);
        }
    }

    void Update()
    {
        SlotSelection();
        Eat();
    }

    private void FixedUpdate()
    {
             
    }

    public void AddItem(Sprite itemPic, int ID, bool holdable)
    {       
        int index = slotsOccupied.FindIndex(element => element == false);

        if (index != -1)
        {
            if (slotID.Contains(ID))
            {
                {
                    int changeMyCount = slotID.IndexOf(ID);
                    amountInSlot[changeMyCount]++;
                    transform.GetChild(changeMyCount).GetChild(1).GetComponent<TextMeshProUGUI>().text = amountInSlot[changeMyCount].ToString();
                    

                }
            }
            else
            {
                CanHoldThisSlot[index] = holdable;
                transform.GetChild(index).GetChild(0).GetComponent<Image>().enabled = true;
                amountInSlot[index] = 1;
                transform.GetChild(index).GetChild(0).GetComponent<Image>().sprite = itemPic;
                slotID[index] = ID;
                slotsOccupied[index] = true;
               transform.GetChild(index).GetChild(1).GetComponent<TextMeshProUGUI>().text = amountInSlot[index].ToString();
                Debug.Log("NextSlotIs " + index);
            }

        }
        else
        {
            Debug.Log("Inv is full");
        }


    }

        public void Eat()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("click");
                if (slotID[currentSlot - 1] < 10)
                {
                    
                    if(slotID[currentSlot - 1] == 1)
                    {
                     GameObject.FindGameObjectWithTag("HungyWungyBar").GetComponent<Hunger>().AddHunger(20);
                     RemoveitemFromSlot(currentSlot - 1);
                    }
                    else if(slotID[currentSlot - 1] == 2)
                    {
                        GameObject.FindGameObjectWithTag("HungyWungyBar").GetComponent<Hunger>().AddHunger(-10);
                        RemoveitemFromSlot(currentSlot - 1);
                    }
                    else if(slotID[currentSlot - 1] == 3)
                    {
                        GameObject.FindGameObjectWithTag("HungyWungyBar").GetComponent<Hunger>().AddHunger(12);
                        RemoveitemFromSlot(currentSlot - 1);
                    }
                }
            }
        }
    public void RemoveitemFromSlot(int slot)
    {
        if (amountInSlot[slot] >= 2)
        {
            amountInSlot[slot]--;
            transform.GetChild(slot).GetChild(1).GetComponent<TextMeshProUGUI>().text = amountInSlot[slot].ToString();
        }
        else
        {
            amountInSlot[slot] = 0;
            slotID[slot] = 0;
            slotsOccupied[slot] = false;    
            transform.GetChild(slot).GetChild(1).GetComponent<TextMeshProUGUI>().text = amountInSlot[slot].ToString();
            transform.GetChild(slot).GetChild(0).GetComponent<Image>().sprite = defaultimg;
            transform.GetChild(slot).GetChild(0).GetComponent<Image>().enabled = false;
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
