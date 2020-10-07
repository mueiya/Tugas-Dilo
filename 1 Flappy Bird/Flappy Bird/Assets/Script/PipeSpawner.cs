using System;
using System.Collections;
using UnityEngine;
public class PipeSpawner : MonoBehaviour
{
    //global variables
    [SerializeField] private Bird bird;
    [SerializeField] private Pipe pipeUp, pipeDown;
    [SerializeField] private float spawnIntervalMin = 1;
    [SerializeField] private float spawnIntervalMax = 2;
    [SerializeField] public float holeSizeMax = 1.5f;
    [SerializeField] public float holeSizeMin = 0.5f;
    [SerializeField] private float maxMinOffset = 1;
    [SerializeField] private Point point;
    
    //coroutine variable
    private Coroutine CR_Spawn;
    private void Start()
    {
        StartSpawn();
    }
    void StartSpawn()
    {
        //Menjalankan Fungsi Coroutine IeSpawn()
        if (CR_Spawn == null)
        {
            CR_Spawn = StartCoroutine(IeSpawn());
        }
    }

    void StopSpawn()
    {
        //Menhentikan Coroutine IeSpawn jika sebeumnya sudah di jalankan
        if (CR_Spawn != null)
        {
            StopCoroutine(CR_Spawn);
        }
    }

    void SpawnPipe()
    {
        //menduplikasi game object pipeUp dan menempatkan posisinya sama dengan game object ini tetapi dirotasi 180 derajat
        Pipe newPipeUp = Instantiate(pipeUp, transform.position, Quaternion.Euler(0, 0, 180));

        //Mengaktifkan game object newPipeUp
        newPipeUp.gameObject.SetActive(true);

        //menduplikasi game object pipeDown dan menempatkan posisinya sama dengan game object
        Pipe newPipeDown = Instantiate(pipeDown, transform.position, Quaternion.identity);

        //Mengaktifkan game object newPipeUp
        newPipeDown.gameObject.SetActive(true);

        //random float number for random hole size
        float holeSize = UnityEngine.Random.Range(holeSizeMin, holeSizeMax);
        
        //menempatkan posisi dari pipa yang sudah terbentuk agar memiliki lubang di tengahnya
        newPipeUp.transform.position += Vector3.up * (holeSize / 2);
        newPipeDown.transform.position += Vector3.down * (holeSize / 2);

        //menempatkan posisi pipa yang telah dibentuk agar posisinya menyesuaikan dengan fungsi Sin
        float y = maxMinOffset * Mathf.Sin(Time.time);
        newPipeUp.transform.position += Vector3.up * y;
        newPipeDown.transform.position += Vector3.up * y;

        Point newPoint = Instantiate(point, transform.position, Quaternion.identity);
        newPoint.gameObject.SetActive(true);
        newPoint.SetSize(holeSize);
        newPoint.transform.position += Vector3.up * y;

    }

    IEnumerator IeSpawn()
    {
        while (true)
        {
            //Jika Burung mati maka menhentikan pembuatan Pipa Baru
            if (bird.IsDead())
            {
                StopSpawn();
            }

            //Membuat Pipa Baru
            SpawnPipe();

            //random float for spawn interval
            float spawnInterval = UnityEngine.Random.Range(spawnIntervalMin, spawnIntervalMax);

            //Menunggu beberapa detik sesuai dengan spawn interval
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}