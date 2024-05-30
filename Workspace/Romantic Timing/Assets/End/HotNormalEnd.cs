using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class HotNormalEnd : MonoBehaviour
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

    public GameObject hom;
    public GameObject food;
    public GameObject kang;
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

        hom.SetActive(true);
        food.SetActive(false);
        kang.SetActive(false);
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
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 2)
        {
            hom.SetActive(false);
            food.SetActive(true);
            People.SetActive(false);
            nameText.text = "";
        }
        else if (index == 3)
        {
            hom.SetActive(true);
            food.SetActive(false);
            People.SetActive(true);
            nameText.text = "이혜원";
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 5)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 6)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 7)
        {
            nameText.text = "";
            People.SetActive(false);
        }
        else if (index ==9)
        {
            hom.SetActive(false);
            kang.SetActive(true);
        }
        else if (index == 10)
        {
            kang.SetActive(false);
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 11)
        {
            nameText.text = "이혜원";

        }
        else if (index == 13)
        {
            nameText.text = "";
        }
        else if (index == 14)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 15)
        {
            nameText.text = "이혜원";
        }
        else if (index == 16)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 17)
        {
            nameText.text = "";
        }
        else if (index == 18)
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
