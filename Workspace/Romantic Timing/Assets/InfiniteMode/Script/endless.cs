using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endless : MonoBehaviour
{
    public List<GameObject> Arrows;

    public Sprite[] sprites;

    public GameObject complete;

    public Image gauge;

    public int Index = 0; 

    public int play = 1;

    public int twinkleCount = 0;

    public GameObject GameOver;

    void Start()
    {
        complete.SetActive(false);
    }

    public bool compare(Sprite spr)
    {
        SpriteRenderer spriterenderer = Arrows[Index].GetComponent<SpriteRenderer>();
        if(spriterenderer.sprite == spr)
        {
            Arrows[Index++].SetActive(false);
            return true;
        }
        return false; 
    }

    public void WrongNote()
    {
        twinkleCount = 0;
        ChangeRed();
        GameOver.SetActive(true);
    }

    private void ChangeRed()
    {
        Arrows[Index].GetComponent<SpriteRenderer>().color = Color.red;
        Invoke("ChangeWhite", 0.1f);
        twinkleCount++;
    }

    private void ChangeWhite()
    {
        Arrows[Index].GetComponent<SpriteRenderer>().color = Color.white;
        if(twinkleCount<2)
        {
            Invoke("ChangeRed", 0.1f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(!compare(sprites[0]))
            {
                WrongNote();
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(!compare(sprites[1]))
            {
                WrongNote();
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(!compare(sprites[2]))
            {
                WrongNote();
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(!compare(sprites[3]))
            {
                WrongNote();
            }
        }        

        if(Index == 4)
        {
            complete.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Index = 0;
                foreach(GameObject arrow in Arrows)
                {
                    arrow.SetActive(true);
                }
                play+=1;
            }
            Arrows[0].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[1].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[2].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[3].GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(gauge.fillAmount<=0.01f)
        {
            WrongNote();            
        }
    }
}