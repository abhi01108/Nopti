using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    [SerializeField]float SwayMultiplier;
    [SerializeField]float smooth;
    private void Update()
    {
        float MouseX = Input.GetAxisRaw("Mouse X") * SwayMultiplier;
        float MouseY = Input.GetAxisRaw("Mouse Y") * SwayMultiplier;

        Quaternion rotateX = Quaternion.AngleAxis(-MouseY, Vector3.right);
        Quaternion rotateY = Quaternion.AngleAxis(MouseX, Vector3.up);

        Quaternion targetRotation = rotateX * rotateY;

        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, smooth * Time.deltaTime);

    }





}
