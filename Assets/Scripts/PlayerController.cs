using System;
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

    private float movementX;
    private float movementY;

    private Vector3 movement = new Vector3(0, 0.5f, 0);

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        this.count = 0;
        SetCountText();
        
        winTextObject.SetActive(false);
    }

    public void OnMove(InputAction.CallbackContext movementValue)
    {
        Vector2 movementVector = movementValue.ReadValue<Vector2>();
        
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true); 
        }
    }
     void FixedUpdate()
    {
        movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed );
    }

     private void OnTriggerEnter(Collider other)
     {   
         if (other.gameObject.CompareTag("PickUp"))
         {
             other.gameObject.SetActive(false);
             count++;
             SetCountText();
         }
        
     }
}
