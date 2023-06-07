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
    [SerializeField] int hours = 1;
    [SerializeField] int minutes = 1;
    [SerializeField] public bool isAmPm = false;
    [SerializeField] float britSec = 1f;
    //Am = true, Pm = false
    [SerializeField] float secondsPerMinute = 1f;
    [SerializeField] bool isNight;
    bool clocking = false;
    bool timechange = false;
    
    public int GetMinutes()
    { 
        return minutes;
    }
    public int GetHours()
    {
        return hours;
    }

    public void GoDark()
    {
       var vingette = vignetteElement.GetComponent<Image>();
        while (alphavig < 1 && !timechange)
        { 
          vingette.color = new Color(vingette.color.r, vingette.color.g, vingette.color.b, alphavig);
          if (!timechange)
          {
             StartCoroutine(GetDarker());
          }
        }

        
    }
    IEnumerator GetDarker()
    {
        timechange = true;
        alphavig = alphavig + 0.025f;
        yield return new WaitForSeconds(britSec);
        timechange = false;
    }

    public void GoBright()
    {
        var vingette = vignetteElement.GetComponent<Image>();
        while (alphavig > 0 && !timechange)
        {
            vingette.color = new Color(vingette.color.r, vingette.color.g, vingette.color.b, alphavig);
            if (!timechange)
            {
                StartCoroutine(GetBrighty());
            }
        }


    }
    IEnumerator GetBrighty()
    {
        timechange = true;
        alphavig = alphavig - 0.025f;
        yield return new WaitForSeconds(britSec);
        timechange = false;
    }






    private void FixedUpdate()
    {
        if(hours == 8 && isAmPm == false)
        { 
          isNight = true;
            GoDark();
        }
        if (hours == 8 && isAmPm == true)
        {
            isNight = false;
            GoBright();
        }
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
