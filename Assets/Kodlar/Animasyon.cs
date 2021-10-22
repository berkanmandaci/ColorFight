using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animasyon : MonoBehaviour
{
    public Sprite[] bekleme;
    private SpriteRenderer spriteRenderer;
    float animbeklemezaman=0;
    int animbeklemesayac = 0;

    // Start is called before the first frame update
     void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void FixedUpdate()
    {
        
        BeklemeAnimasyon();
    }
    void BeklemeAnimasyon()
    {

        animbeklemezaman += Time.deltaTime;
        if (animbeklemezaman>0.05f)
        {
            
                spriteRenderer.sprite = bekleme[animbeklemesayac++];
            animbeklemezaman = 0;
        }
        
        if (animbeklemesayac==11)
        {
            animbeklemesayac = 0;
        }
    }
  
}
