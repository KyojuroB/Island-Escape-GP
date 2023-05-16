using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Movement
    [SerializeField] float moveSpeed;
    [SerializeField] int movementMultiply;
    [SerializeField] bool isMoving = false;
    AudioSource audioSource;
    bool ifSprint = false;
    [SerializeField] int stamina = 100;
    // Start is called before the first frame update
    private void Awake()
    {
      audioSource = GetComponent<AudioSource>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sprint();
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
            StartCoroutine(ReplinishStam());
        }
        if (stamina <= 0)
        {
            movementMultiply = 35;
        }
    }
    private void move()
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

    IEnumerator WaitForStam()
    {


        while (ifSprint == true && stamina > 0)
        {
            yield return new WaitForSeconds(0.05f);
            stamina--;
        }


    }
    IEnumerator ReplinishStam()
    {
        while (stamina < 100 && ifSprint == false)
        {
            yield return new WaitForSeconds(0.5f);
            stamina = stamina + 2;

        }


    }










}
