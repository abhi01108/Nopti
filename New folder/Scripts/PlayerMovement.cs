using UnityEngine;
public class PlayerMovement : MonoBehaviour
{   
    public CharacterController controller;
    public float speed = 12f;
    public Vector3 velocity;
    public float gravity = - 19.6f;
    public Transform groundCheck; 
    public float groundDistance = 0.4f;
    public LayerMask groundmask;
    public LayerMask bumpmask;
    bool isGrounded;
    bool isBumped;
    public float jumpHeight = 12f;
    public float bumpHeight = 30f;

    public void Update()
    {
        //bool active = false;
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundmask);
        isBumped = Physics.CheckSphere(groundCheck.position, groundDistance, bumpmask);
        if ((isGrounded) && velocity.y < 0)
        {
            velocity.y = -2;
        }
        if ((isBumped) && velocity.y < 0)
        {
            velocity.y = -2;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        if (Input.GetButtonDown("Jump") && isBumped)
        {
            velocity.y = Mathf.Sqrt(bumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
}
}