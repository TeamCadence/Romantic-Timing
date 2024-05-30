using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HHappyEnd : MonoBehaviour
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
    public GameObject Pizhom;
    public GameObject End;
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
        Pizhom.SetActive(false);
        StartCoroutine(PineText());
    }
    IEnumerator PineText()
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        string replaceText = Pinetexts[index].Replace("(player)", playerName).Replace("#", "\n");
        HotNameChange();
        isTyping = true;
        for (int i = 0; i <= replaceText.Length; i++)
        {
            audioSource.Play();
            textDisplay.text = replaceText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
    }

    void HotNameChange()
    {
        if (index == 1)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            People.SetActive(true);
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 2)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 3)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 4)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 5)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 6)
        {
            Pizhom.SetActive(true);
            Sun.SetActive(false);
            nameText.text = "";
            Peopleimage.sprite = EyeEatingimage;
        }
        else if (index == 7)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 8)
        {
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 9)
        {
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 10)
        {
            Peopleimage.sprite = Eyeimage;
        }
        else if (index == 11)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 12)
        {
            nameText.text = "";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 13)
        {
            Sun.SetActive(true);
            Pizhom.SetActive(false);
            People.SetActive(false);
        }
        else if (index == 14)
        {
            People.SetActive(true);
            Peopleimage.sprite = Eyeimage;
            nameText.text = "이혜원";
        }
        else if (index == 15)
        {
            Peopleimage.sprite = Smileimage;
            nameText.text = "이혜원";
        }   
        else if (index == 16)
        {
            People.SetActive(false);
            nameText.text = "";
            Pizhom.SetActive(false);
            Sun.SetActive(false);
            End.SetActive(true);
        }
        else if (index == 17)
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

    

