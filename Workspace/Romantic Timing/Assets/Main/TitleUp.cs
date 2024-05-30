using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleUp : MonoBehaviour
{   
    public RectTransform TitleUP;
    public RectTransform Button1UP;
    public RectTransform Button2UP;
    public RectTransform Button3UP;
    public bool titleok;
    public float moveSpeed = 100f;
    public Vector2 targetPosition;
    public Vector2 finalPosition;
    public int finalY;

    void Start()
    {
        titleok = false;
        targetPosition = new Vector2(TitleUP.anchoredPosition.x, -Screen.height);
        finalPosition = new Vector2(TitleUP.anchoredPosition.x, finalY);
    }
    void Update()
    {
        TitleUP.anchoredPosition = Vector2.MoveTowards(TitleUP.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
        if (TitleUP.anchoredPosition.y >= targetPosition.y)
        {
            targetPosition = finalPosition;
            titleok = true;
        }
        if (titleok == true )
        {
            targetPosition = new Vector2(Button1UP.anchoredPosition.x, -Screen.height);
            finalPosition = new Vector2(Button1UP.anchoredPosition.x, finalY);
            Button1UP.anchoredPosition = Vector2.MoveTowards(Button1UP.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            if (Button1UP.anchoredPosition.y >= targetPosition.y)
            {
                targetPosition = finalPosition;
            }
            targetPosition = new Vector2(Button2UP.anchoredPosition.x, -Screen.height);
            finalPosition = new Vector2(Button2UP.anchoredPosition.x, finalY);
            Button2UP.anchoredPosition = Vector2.MoveTowards(Button2UP.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            if (Button1UP.anchoredPosition.y >= targetPosition.y)
            {
                targetPosition = finalPosition;
            }
            targetPosition = new Vector2(Button3UP.anchoredPosition.x, -Screen.height);
            finalPosition = new Vector2(Button3UP.anchoredPosition.x, finalY);
            Button3UP.anchoredPosition = Vector2.MoveTowards(Button3UP.anchoredPosition, targetPosition, moveSpeed * Time.deltaTime);
            if (Button3UP.anchoredPosition.y >= targetPosition.y)
            {
                targetPosition = finalPosition;
            }
        }
    }
}
