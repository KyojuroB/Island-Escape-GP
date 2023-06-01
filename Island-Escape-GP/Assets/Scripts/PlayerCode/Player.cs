using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Movement
    [SerializeField] float moveSpeed;
    [SerializeField] int movementMultiply;
    [SerializeField] bool isMoving = false;
    AudioSource audioSource;
    bool ifSprint = false;
    [SerializeField] int stamina = 100;
    [SerializeField] float dashCoolDown = 2.2f;
    [SerializeField] float dashSpeed = 70f;
    [SerializeField] float dashDuration = 0.2f;
    bool isDashing = false;
    bool isReplenishingStamina = false; 

    [SerializeField] int health = 100;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        sprint();
        Dash();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void sprint()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && stamina > 0 && isMoving == true)
        {
            ifSprint = true;
            movementMultiply = 85;
            StartCoroutine(WaitForStam());
            StopCoroutine(ReplinishStam());
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ifSprint = false;
            movementMultiply = 35;
            StopCoroutine(WaitForStam());
            if (!isReplenishingStamina) 
            {
                StartCoroutine(ReplinishStam());
            }
        }

        if (stamina <= 0)
        {
            movementMultiply = 35;
        }
    }
    private void meleAttack()
    {

 
    
    }





    private void move()
    {
        if (!isDashing)
        {
            float changeY = Input.GetAxis("Vertical") * moveSpeed * movementMultiply * Time.deltaTime;
            float changeX = Input.GetAxis("Horizontal") * moveSpeed * movementMultiply * Time.deltaTime;

            GetComponent<Rigidbody2D>().velocity = new Vector2(changeX, changeY);

            if (changeX != 0 || changeY != 0)
            {
                if (!audioSource.isPlaying)
                {
                    audioSource.Play();
                    isMoving = true;
                }
            }
            else
            {
                audioSource.Stop();
                isMoving = false;
            }
        }
    }

    private void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Q) && isMoving && !isDashing && stamina >= 20)
        {
            isDashing = true;
            Debug.Log("Dash");


            Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            dashDirection.Normalize();

            StartCoroutine(PerformDash(dashDirection));
            stamina -= 20;
            StopCoroutine(ReplinishStam());
            StartCoroutine(WaitForStam());
            StartCoroutine(WaitForDash());
        }
    }

    private IEnumerator PerformDash(Vector2 dashDirection)
    {
        float timer = 0f;
        Vector2 initialVelocity = GetComponent<Rigidbody2D>().velocity;

        while (timer < dashDuration)
        {
            GetComponent<Rigidbody2D>().velocity = dashDirection * dashSpeed * movementMultiply * Time.deltaTime;
            timer += Time.deltaTime;
            yield return null;
        }

        GetComponent<Rigidbody2D>().velocity = initialVelocity;
        isDashing = false;

        if (!isReplenishingStamina) 
        {
            StartCoroutine(ReplinishStam());
        }
    }

    private IEnumerator WaitForStam()
    {
        while (ifSprint == true && stamina > 0)
        {
            yield return new WaitForSeconds(0.05f);
            stamina--;
        }
    }

    private IEnumerator ReplinishStam()
    {
        isReplenishingStamina = true; 

        while (stamina < 100 && ifSprint == false)
        {
            yield return new WaitForSeconds(0.5f);
            stamina += 2;
        }

        isReplenishingStamina = false; 
    }

    private IEnumerator WaitForDash()
    {
        yield return new WaitForSeconds(dashCoolDown);
    }

    public int GetHealth()
    {
        return health;
    }

    public int GetStamina()
    {
        return stamina;
    }
}