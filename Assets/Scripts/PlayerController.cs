using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0f;
    public float jumpForce = 5f;
    public float groundDistance = 0.5f;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    
    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // score
        count = 0;
        SetCountText();

        winTextObject.SetActive(false);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count : " + count.ToString();
        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    private void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movementVector * speed);

    }

    private void OnTriggerEnter(Collider other)
    { // gestion des collisions, la boule ne peut plus rien faire disparaitre
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;

            SetCountText();
        }
    }

    private bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void OnJump()
    {
        // Debug.Log("JUUUUMMMMMMMPPPPPPP");
        if (isGrounded())
            rb.velocity = Vector3.up * jumpForce;
    }
}
