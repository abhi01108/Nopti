using UnityEngine;

public class Switching : MonoBehaviour
{
     
    // Start is called before the first frame update
    public int selectedItem = 0;
    void Start()
    {
        SelectItem();
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedItem;
        if (Input.GetAxis("Mouse ScrollWheel") > 0 )
        {
            if (selectedItem >= transform.childCount - 1)
                selectedItem = 0;
            else
                selectedItem++;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = 1;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 )
        {
            if (selectedItem <= 0)
                selectedItem = transform.childCount - 1;

            else
                selectedItem--;
        }
        if (previousSelectedWeapon != selectedItem)
        {
            SelectItem();
        }
    }
    void SelectItem()
    {
        int i = 0;
        foreach(Transform item in transform)
        {
            if (i == selectedItem)
            {
                item.gameObject.SetActive(true);

            }
            else
                item.gameObject.SetActive(false);
                i++;
        }
    }
}
