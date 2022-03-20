using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 900f;
    public Transform playerBody;
    float xRotation = 0f;
    public Camera playercamera;
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {

            playercamera.fieldOfView = 10;
            mouseSensitivity = mouseSensitivity / 3;
            
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
            {
                playercamera.fieldOfView = 60;
            mouseSensitivity = mouseSensitivity * 3;
        }
         
        


        xRotation -= mouseY;
        //Quaternions are used to represent rotation in unity. Euler angles are the angles
        //that returns a  rotation of x,y,z degrees around x,y,z axis respl..  
        xRotation = Mathf.Clamp(xRotation, -75f, 60f);
        //Clamp is used to give a range to the rotation 
        
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); 
    }
     

}
