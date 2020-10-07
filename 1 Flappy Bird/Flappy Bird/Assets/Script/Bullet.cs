using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed = 10f;
    public Rigidbody2D rb;

    private void Start()
    {
        rb.velocity = transform.right * Speed;
    }
    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Pipe pipe = hitInfo.GetComponent<Pipe> ();
        Ground ground = hitInfo.GetComponent<Ground>();

        if (pipe != null)
        {
            pipe.Shoot();
        }
        else if (ground != null)
        {
            Destroy(gameObject);
        };
    }
    public void Hit()
    {
        //i dont know why its not working :(
        DestroyImmediate(this.gameObject, true);
        Debug.Log("hit");
    }
}
