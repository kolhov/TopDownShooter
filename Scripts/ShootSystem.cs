using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;

    
    public void ShootProj()
    {
        GameObject laser = Instantiate(projectilePrefab,
            transform.position,
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
    }

    public void ShootProjInCircle(int numberOfProj = 1)
    {
        float rotateAngle = 360 / numberOfProj;
        
        for (int i = 1; i <= numberOfProj; i++)
        {
            float angleInRadians = rotateAngle * Mathf.Deg2Rad * i;
            Vector2 direction = new Vector2(Mathf.Cos(angleInRadians), Mathf.Sin(angleInRadians));

            GameObject laser = Instantiate(projectilePrefab,
                transform.position,
                Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = direction * projectileSpeed;
            laser.transform.Rotate(0,0,rotateAngle * i);
            
        }
    }
    
    
}
