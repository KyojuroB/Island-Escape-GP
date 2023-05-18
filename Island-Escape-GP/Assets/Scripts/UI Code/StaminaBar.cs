using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    float stamina = 1;


    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            int getHealthFromPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetStamina();
            stamina = getHealthFromPlayer / 100f;
            SetHealthBar();
        }
    }
    private void SetHealthBar()
    {
        GetComponent<Image>().fillAmount =stamina;

    }
}
