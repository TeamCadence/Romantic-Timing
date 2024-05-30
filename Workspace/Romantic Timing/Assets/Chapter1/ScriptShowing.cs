using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class ScriptShowing : MonoBehaviour
{
    public TMP_Text textDisplay;
    public string[] texts;
    private int index;
    public float typingSpeed = 0.1f;
    private bool isTyping = false;
    public bool activeSelf;
    public GameObject complete;

    public Sprite Normalimage;
    public Sprite Eyeimage;
    public Sprite Smileimage;
    public Sprite Sadimage;
    public Sprite Talkimage;
    public Sprite EyeEatingimage;
    public Sprite Eatingimage;
    private SpriteRenderer Peopleimage;
    public GameObject People;

    // Start is called before the first frame update
    void Start()
    {
        Peopleimage = People.GetComponent<SpriteRenderer>();
        Coroutine = TypeText();
        StartCoroutine(Coroutine);
    }

    IEnumerator Coroutine;

    IEnumerator TypeText()
    {
        // 대화 텍스트 표시
        string playerName = PlayerPrefs.GetString("PlayerName");
        string replaceText = texts[index].Replace("(player)", playerName);
        FaceChange();
        isTyping = true;
        for (int i = 0; i <= replaceText.Length; i++)
        {
            textDisplay.text = replaceText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void FaceChange()
    {
        // 표정 변경
        if(index == 0)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 1)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 2)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 3)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 4)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if(index ==5)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 6)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 7)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if(index == 8)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 9)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 10)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 11)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 12)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 13)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 14)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 15)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 16)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 17)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 18)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 19)
        {
            Peopleimage.sprite = EyeEatingimage;
        }
        else if (index == 20)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if(index == 21)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 22)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 23)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if(index == 24)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 25)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 26)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 27)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 28)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 29)
        {
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 30)
        {
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 31)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 32)
        {
            Peopleimage.sprite = Normalimage;
        }else if (index == 33)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 34)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 35)
        {
            Peopleimage.sprite = Smileimage;
        }else if (index == 36)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 37)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 38)
        {
            Peopleimage.sprite = Smileimage;
        }else if (index == 39)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 40)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 41)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 42)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 43)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 44)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 45)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 46)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 47)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 48)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 49)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 50)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 51)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 52)
        {
            Peopleimage.sprite = Normalimage;
        }
    }

    void Update()
    {
        //NextText();
    }

    public void NextText()
    {
        if (index < texts.Length - 1)
        {
            Debug.Log("c");
            StopCoroutine(Coroutine);
            Coroutine = TypeText();
            index++; // 텍스트 인덱스를 증가
            textDisplay.text = ""; // 텍스트 표시를 초기화
            StartCoroutine(Coroutine); // TypeText 코루틴을 시작
            /*
            Debug.Log("a");
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("b");
                if(complete.activeSelf==true)
                {
                    Debug.Log("c");
                    StopCoroutine(Coroutine);
                    Coroutine = TypeText();
                    index++; // 텍스트 인덱스를 증가
                    textDisplay.text = ""; // 텍스트 표시를 초기화
                    StartCoroutine(Coroutine); // TypeText 코루틴을 시작
                }
            }
            */
        }
        else
        {
            // 텍스트가 모두 표시된 후의 동작
        }
    }

    
}
