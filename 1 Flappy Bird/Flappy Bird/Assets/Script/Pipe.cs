using UnityEngine;
using UnityEngine.Events;

public class Pipe : MonoBehaviour
{
    //Global variable
    [SerializeField] private Bird bird;
    [SerializeField] private float speed = 1;
    //make bool pipe shooted
    [SerializeField] private bool Shooted;
    [SerializeField] private Bullet bullet;

    //Dipanggil setiap frame
    private void Update()
    {
        //Melakukan pengecekan jika burung belum mati
        if (!bird.IsDead())
        {
            //Membuat pipa bergerak kesebelah kiri dengan kecepatan tertentu
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
        }
    }

    //Membuat Bird mati ketika bersentuhan dan menjatuhkannya ke ground jika mengenai di atas collider
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bird bird = collision.gameObject.GetComponent<Bird>();
        Bullet bullet = collision.gameObject.GetComponent<Bullet>();

        //Pengecekan Null value
        if (bird)
        {
            //Mendapatkan komponent Collider pada game object
            Collider2D collider = GetComponent<Collider2D>();

            //Melakukan pengecekan Null varibale atau tidak
            if (collider)
            {
                //Menonaktifkan collider
                collider.enabled = false;
            }

            //Burung Mati
            bird.Dead();
        }
    }
    public bool IsShooted()
    {
        return Shooted;
    }
    public void Shoot()
    {
        if (!Shooted)
        {
            Debug.Log("Pipe shooted");
            //disable sprite renderer
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //make box collider is trigger
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
            Shooted = true;
            bullet.Hit();
        }

    }
    //just make it add point
    void OnTriggerExit2D(Collider2D collision)
    {
        //Mendapatkan komponen Bird
        Bird bird = collision.gameObject.GetComponent<Bird>();
        //Menambahkan score jika burung tidak null dan burung belum mati;
        if (bird && !bird.IsDead())
        {
            bird.AddScore(1);
        }
    }
}