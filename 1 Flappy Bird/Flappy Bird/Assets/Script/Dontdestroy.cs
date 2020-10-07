//Nih code gak jadi dipake
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dontdestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("highscore");
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
