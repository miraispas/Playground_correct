using UnityEngine;
using UnityEngine.InputSystem;

namespace ThePlayground.Main.Player
{
    public class Player : MonoBehaviour
    {
        Rigidbody rb;
        bool isGrounded;
        float groundDistance = 0.4f;

        [SerializeField]
        float jumpForce;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {
            print(Physics.CheckSphere(gameObject.transform.position, groundDistance));

            if (Keyboard.current.wKey.isPressed && isGrounded)
            {
                print("move");
                rb.AddForce(0, 0, 10);
            }
            isGrounded = Physics.CheckSphere(gameObject.transform.position, groundDistance, groundMask);

            if (keyboard.current.wKey.isPressed && isGrounded)
            {
                print("move");
                rb.AddForce(0, 10);
            }

            if (keyboard.current.sKey.isPressed && isGrounded)
            {
                print("move");
                rb.AddForce(0, -10);
            }

            if (keyboard.current.spaceKey.isPressed && isGrounded)
            {
                print("jump");
                rb.AddForce(0, jumpForce, 0);
            }
        }

        private void OnCollisionStay(Collision collision)
        {
            print("colliding");
        }

        private void OnCollisionExit(Collision collision)
        {
            print("Not colliding");
        }
    }
}

    /*
    public float mouseSensitivity = 2f;
    private float verticalRotation = 0f;
    private Transform cameraTransform;

    private Rigidbody rb;
    public float MoveSpeed = 5f;
    private float moveHorizontal;
    private float moveForward;

    public float jumpForce = 10f;
    public float fallMultiplier = 2.5f;
    public float ascendMultiplier = 2f;
    private bool isGrounded = true;
    public LayerMask groundLayer;
    private float groundCheckTimer = 0f;
    private float groundCheckDelay = 0.3f;
    private float playerHeight;
    private float raycastDistance;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        cameraTransform = gameObject.transform; 

        playerHeight = GetComponent<CapsuleCollider>().height * transform.localScale.y;
        raycastDistance = (playerHeight / 2) + 0.2f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }


    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveForward = Input.GetAxis("Vertical");

        //RotateCamera();

        if (Input.GetKeyDown(KeyCode.Space)) //&& isGrounded)
        {
            Jump();
        }

        if (!isGrounded && groundCheckTimer <= 0f)
        {
            Vector3 rayOrigin = transform.position + Vector3.up * 0.1f;
            isGrounded = Physics.Raycast(rayOrigin, Vector3.down, raycastDistance, groundLayer);
        }
        else
        {
            groundCheckTimer -= Time.deltaTime;
        }
    }
    private void FixedUpdate()
    {
        //MovePlayer();
        //ApplyJumpPhysics();
    }

    private void MovePlayer()
    {
        Vector3 movement = (transform.right * moveHorizontal + transform.forward * moveForward).normalized;
        Vector3 targetVelocity = movement * MoveSpeed;

        Vector3 velocity = rb.angularVelocity;
        velocity.x = targetVelocity.x;
        velocity.z = targetVelocity.z;
        rb.angularVelocity = velocity;

        if (isGrounded && moveHorizontal == 0 && moveForward == 0)
        {
            rb.angularVelocity = new Vector3(0, rb.angularVelocity.y, 0);
        }
    }

    private void RotateCamera()
    {
        float horizontalRotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, horizontalRotation, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);
    }

     private void Jump()
     {
        print("JUMP");
        isGrounded = false;
        groundCheckTimer = groundCheckDelay;
        rb.angularVelocity = new Vector3(rb.angularVelocity.x, jumpForce, rb.angularVelocity.z);
     }

      private void ApplyJumpPhysics()
      {
        if (rb.angularVelocity.y < 0)
        {
            rb.angularVelocity += Vector3.up * Physics.gravity.y * fallMultiplier * Time.fixedDeltaTime;
        }
        else if (rb.angularVelocity.y > 0 && !Input.GetButton("Jump"))
        {
                    rb.angularVelocity += Vector3.up * Physics.gravity.y * ascendMultiplier * Time.fixedDeltaTime;
        }
      }*/
