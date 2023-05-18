using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    float health = 1;

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            int getHealthFromPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetHealth();
            health = getHealthFromPlayer / 100f;
            SetHealthBar();
        }
    }
    private void SetHealthBar()
    {
        GetComponent<Image>().fillAmount = health;

    }
}
