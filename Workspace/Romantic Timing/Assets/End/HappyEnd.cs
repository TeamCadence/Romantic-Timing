using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HappyEnd : MonoBehaviour
{   
    public TMP_Text textDisplay;
    public GameObject TextPanel;
    public GameObject EndText;    
    public string[] Pinetexts;
    private int index;
    public float typingSpeed = 0.1f;
    private bool isTyping = false;

    public TMP_Text nameText;
    public AudioSource audioSource;
    public GameObject Countd;

    public GameObject Sun;
    public GameObject hom;
    public GameObject food;
    public GameObject car;
    public GameObject Moon;
    public GameObject BGM;

    public GameObject People;
    public Sprite Normalimage;
    public Sprite Eyeimage;
    public Sprite Smileimage;
    public Sprite Sadimage;
    public Sprite Talkimage;
    public Sprite EyeEatingimage;
    public Sprite Eatingimage;
    private Image Peopleimage;

    void Start()
    {
        Peopleimage = People.GetComponent<Image>();
        People.SetActive(false);
        BGM = GameObject.Find("bgmManager");
        Destroy(BGM);
        Sun.SetActive(true);
        hom.SetActive(false);
        food.SetActive(false);
        car.SetActive(false);
        Moon.SetActive(false);
        StartCoroutine(PineText());
    }
    IEnumerator PineText()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        string replaceText = Pinetexts[index].Replace("(player)", playerName).Replace("#", "\n");
        PineNameChange();
        isTyping = true;
        for (int i = 0; i <= replaceText.Length; i++)
        {
            audioSource.Play();
            textDisplay.text = replaceText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void PineNameChange()
    {
        if (index == 1)
        {
            nameText.text = "이혜원";
            People.SetActive(true);
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 2)
        {
            nameText.text = "";
        }
        else if (index == 3)
        {
            Sun.SetActive(false);
            hom.SetActive(true);
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 4)
        {
            People.SetActive(false);
            hom.SetActive(false);
            food.SetActive(true);
        }
        else if (index == 5)
        {
            People.SetActive(true);
            hom.SetActive(true);
            food.SetActive(false);
            nameText.text = "이혜원";
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 6)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 7)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 8)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = EyeEatingimage;
        }
        else if (index == 9)
        {
            Peopleimage.sprite = Eatingimage;
            nameText.text = "";
        }
        else if (index == 10)
        {
            Peopleimage.sprite = Talkimage;
            nameText.text = "이혜원";
        }
        else if (index == 11)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 12)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 13)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 14)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 15)
        {
            nameText.text = "";
        }
        else if (index == 16)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 17)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 18)
        {
            hom.SetActive(false);
            car.SetActive(true);
            nameText.text = "";
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 19)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 20)
        {
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 21)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = EyeEatingimage;
        }
        else if (index == 22)
        {
            car.SetActive(false);
            Moon.SetActive(true);
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 23)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 24)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 25)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 26)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 27)
        {
            nameText.text = "";
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 28)
        {
            People.SetActive(false);
            Moon.SetActive(false);
        }
        else if(index == 29)
        {
            StartCoroutine("Ending");
        }
    }

    IEnumerator Ending()
    {
        TextPanel.SetActive(false);
        EndText.SetActive(true);
        yield return new WaitForSeconds(3);
        StartCoroutine("GoToTitle");
    }

    IEnumerator GoToTitle()
    {
        Countd.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Main");
    }

    private void Update()
    {
        if (!isTyping && Input.GetKeyDown(KeyCode.Space))
        {
            NextText();
        }
        if (isTyping && Input.GetKey(KeyCode.Space))
        {
            typingSpeed = 0.01f;
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            typingSpeed = 0.1f;
        }
    }

    void NextText()
    {
        if (index < Pinetexts.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(PineText());
        }
        else
        {
           
            
        }
    }
}
