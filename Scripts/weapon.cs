using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{

    public float offset;

    public GameObject projectile;
    public Transform shotpoint;

    private float timebtwshots;
    public float starttimebtwshots;

    
    private void Update()
    {
        //weapon rotation
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        
        
        
        
        if (timebtwshots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(projectile, shotpoint.position, transform.rotation);
                timebtwshots = starttimebtwshots;
            }
        }
        else
        {
            timebtwshots -= Time.deltaTime;
        }





    }







}
