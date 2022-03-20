using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform player;
    public Vector3 offset; public float mouseSensX = 2f;
    public float mouseSensY = 2f;
    float rotY;
    float rotX;
    float speed;
    void Update()
    {
        transform.position = player.position+offset;
        if (Input.GetMouseButton(1))
        {
            rotX = transform.localEulerAngles.y + (Input.GetAxis("Mouse X") * mouseSensX);
            rotY += Input.GetAxis("Mouse Y") * mouseSensY;
            rotY = Mathf.Clamp(rotY, -80f, 80f);
            transform.localEulerAngles = new Vector3(-rotY, rotX, 0f);
            //Cursor.visible = false; 
        }
       
    }
}