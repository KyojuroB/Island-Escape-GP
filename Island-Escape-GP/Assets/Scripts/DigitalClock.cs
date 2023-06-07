using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class DigitalClock : MonoBehaviour
{
    bool isFirstZero = true;
    string time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

      int hours =  GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetHours();
      int minutes = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().GetMinutes();
      string apm;
        if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isAmPm == true)
        {
            apm = "Am";
        }
        else
        {
            apm = "Pm";
        }
        
        if (minutes - 10 >= 0)
        {
            time = hours.ToString() + ":" + minutes.ToString() + "   " + apm;
           
            isFirstZero = true;
        }
        else
        {
            time = hours.ToString() + ":" + 0 + minutes.ToString() + "   " + apm;
            isFirstZero = false;
        }



        gameObject.GetComponent<TextMeshProUGUI>().text = (time);
    }
}
