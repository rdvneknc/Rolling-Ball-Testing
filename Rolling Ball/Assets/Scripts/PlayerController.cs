using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;
    private bool jump;

   

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        count = 0;

        SetCountText();
        winTextObject.SetActive(false);
    }

    private void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    jump = true;
        //}
    }

    

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;

    }

   void SetCountText() 
    {
        countText.text = "Score: " + count.ToString();
        if(count >= 130)
        {
            winTextObject.SetActive(true);
        }
    }
    
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        if (jump)
        {
            rb.AddForce(movement * speed);

            jump = false;
        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 10;

            SetCountText();
        }
        
    }
   
}
