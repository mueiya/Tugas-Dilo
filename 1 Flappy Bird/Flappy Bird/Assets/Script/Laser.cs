using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//awalnya mau pake sprite laser tapi mager nyarinya
public class Laser : MonoBehaviour
{
    public Transform FirePoint;
    [SerializeField] private Bird bird;
    public GameObject BulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            shoot();
        }
    }


    //shoot
    void shoot()
    {
        if (bird.IsDead())
        {
            notshoot();
        }
        else
        {
            Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation); 
        }
    }

    void notshoot()
    {
        Debug.Log("Bird is Dead");
    }
}
