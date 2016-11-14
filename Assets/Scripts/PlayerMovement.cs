using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary2
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 6f;
    //public Boundary boundary;
    public float JumpHeight = 8.0f;
    private bool isGrounded = false;
    //public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private string MovementAxisName;
    private Rigidbody playerRigidbody;
    private float MovementInputValue;

    [SerializeField]
    KeyCode[] Keycodes;


    //private void Start()
    //{
    //    MovementAxisName = "Horizontal";
    //}


    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Debug.Log(isGrounded);
        if (Input.GetKey(Keycodes[0]))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(Keycodes[1]))
        {
            transform.position += Vector3.right * JumpHeight * Time.deltaTime;
        }
        if (Input.GetKey(Keycodes[2]) && isGrounded == true)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(Keycodes[3]))
        {
            transform.position += Vector3.down * moveSpeed * Time.deltaTime;
        }
    }


    private void Move ()
    {
        Vector3 movement = transform.forward * MovementInputValue * moveSpeed * Time.deltaTime;

        playerRigidbody.MovePosition(playerRigidbody.position = movement);
    }

    //Detector for being in the air.
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
