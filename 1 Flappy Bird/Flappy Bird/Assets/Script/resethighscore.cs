using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resethighscore : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            PlayerPrefs.DeleteAll();
        };
    }
}
