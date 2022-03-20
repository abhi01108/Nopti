using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float speed;
    void Update()
    {
        look();
    }
    void look()
    {
        Plane playerplane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;
        if(playerplane.Raycast(ray,out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targetrotation = Quaternion.LookRotation(targetpoint - transform.position);
            Quaternion.Slerp(transform.rotation, targetrotation, speed * Time.deltaTime);
        }
    }
}
