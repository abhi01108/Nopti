using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private float speed = 1500f;   
    public Rigidbody rb;
    private void FixedUpdate()
    {
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");

        rb.position=(transform.forward *x + transform.right *y )*speed*Time.deltaTime;
       
    }
    
}