using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Assertions.Must;

public class Temple : MonoBehaviour
{
    bool hasPlayer;
    [SerializeField] int woodLeft = 15;
    [SerializeField] int stoneLeft = 15;
    [SerializeField] TextMeshProUGUI woodText;
    [SerializeField] TextMeshProUGUI stoneText;
    [SerializeField] GameObject motor;

    // Start is called before the first frame update
    void Start()
    {
        woodText.GetComponent<TextMeshProUGUI>().text = woodLeft.ToString();
        stoneText.GetComponent<TextMeshProUGUI>().text = stoneLeft.ToString();
        motor.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().CheckForItem(10) == true && hasPlayer && woodLeft > 0)
        {
            Debug.Log("Ready");
            if(Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().RemoveitemFromSlot(GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().currentSlot - 1);
                woodLeft--;
                woodText.GetComponent<TextMeshProUGUI>().text = woodLeft.ToString();
            }
        }
        if (GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().CheckForItem(11) == true && hasPlayer && stoneLeft > 0)
        {
            Debug.Log("Ready"); 
            if (Input.GetKeyDown(KeyCode.E))
            {
                GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().RemoveitemFromSlot(GameObject.FindGameObjectWithTag("HotBar").GetComponent<Hotbar>().currentSlot -1);
                stoneLeft--;
                stoneText.GetComponent<TextMeshProUGUI>().text = stoneLeft.ToString();
            }
        }
        if (woodLeft == 0 && stoneLeft == 0 && motor != null)
        {
            motor.SetActive(true);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        { 
            hasPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            hasPlayer = false;
        }
    }
}
