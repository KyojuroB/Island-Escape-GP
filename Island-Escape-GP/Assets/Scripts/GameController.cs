using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    [SerializeField] Image vignetteElement;
    [SerializeField] int hourswhendark =9;
    [SerializeField] float alphavig = 0;
    [SerializeField] int hours = 12;
    [SerializeField] int minutes = 0;
    [SerializeField] public bool isAmPm = true;
    //Am = true, Pm = false
    [SerializeField] float secondsPerMinute = 1f;

    bool clocking = false;
    
    public int GetMinutes()
    { 
        return minutes;
    }
    public int GetHours()
    {
        return hours;
    }

    private void GoDark()
    {
       var vingette = vignetteElement.GetComponent<Image>();
       vingette.color = new Color(vingette.color.r, vingette.color.g, vingette.color.b, alphavig);
        



        



    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!clocking)
        { 
          StartCoroutine(ClockIncrease());
        }

        `   A
        if(minutes >= 60)
        {
            hours++;
            minutes = 0;
        }

        if (hours >= 12)
        {

            hours = 1;
            if (isAmPm)
            {
                isAmPm = false;
            }
            else
            { 
                isAmPm = true;
            }
        }

    }
    IEnumerator ClockIncrease()
    {
        clocking = true;
        minutes++;
        yield return new WaitForSeconds(secondsPerMinute);
        clocking = false;
    }
}
