using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changesprite : MonoBehaviour
{
    public Transform BackgroundD;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public GameObject NightPrefab;

    void Start()
    {
        float randomize = Random.Range(1f, 2f);
        Debug.Log(randomize.ToString());
        if (randomize < 1.5f)
        {
            ChangeSprite();
        }
    }
    void ChangeSprite()
    {
        Instantiate(NightPrefab, BackgroundD.position, BackgroundD.rotation);
    }
}
