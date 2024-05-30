using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ForArrows : MonoBehaviour
{
    public Sprite[] sprites;

    void OnEnable()
    {
        System.Random random = new System.Random();

        // 0부터 3까지의 숫자를 랜덤하게 생성
        int randomNumber = random.Next(0, 4);
    
        SpriteRenderer spriterenderer = gameObject.GetComponent<SpriteRenderer>();

        spriterenderer.sprite = sprites[randomNumber];
    }

    void Update()
    {
        
    }
}
