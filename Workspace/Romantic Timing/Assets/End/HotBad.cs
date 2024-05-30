using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
public class HotBad : MonoBehaviour
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
    public GameObject school;
    public GameObject BGM;
    public GameObject ending;

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
        school.SetActive(false);
        ending.SetActive(false);
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
            People.SetActive(true);
            nameText.text = "이혜원";
            Peopleimage.sprite = Smileimage;
        }
        else if (index == 2)
        {
            People.SetActive(false);
            nameText.text = "";
        }
        else if (index == 3)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 4)
        {
            People.SetActive(true);
            nameText.text = "이혜원";
            Peopleimage.sprite = Talkimage;
        }
        else if (index == 5)
        {
            Peopleimage.sprite = Normalimage;
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 6)
        {
            People.SetActive(false);
            hom.SetActive(false);
            food.SetActive(true);
            nameText.text = "";
        }
        else if (index == 7)
        {
            People.SetActive(true);
            Peopleimage.sprite = Smileimage;
            hom.SetActive(true);
            food.SetActive(false);
            nameText.text = "이혜원";
        }
        else if (index == 8)
        {
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 9)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 10)
        {
            nameText.text = "";
            Peopleimage.sprite = EyeEatingimage;
        }
        else if (index == 11)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 12)
        {
            nameText.text = "";
            Peopleimage.sprite = Eatingimage;
        }
        else if (index == 13)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 14)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 15)
        {
            nameText.text = "";
            Peopleimage.sprite = Eatingimage;
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
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 18)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
            Peopleimage.sprite = Normalimage;
        }
        else if (index == 19)
        {
            nameText.text = "이혜원";
            Peopleimage.sprite = Sadimage;
        }
        else if (index == 20)
        {
            nameText.text = "";
            People.SetActive(false);
        }
        else if (index == 22)
        {
            hom.SetActive(false);
            school.SetActive(true);
        }
        else if (index == 24)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
        else if (index == 25)
        {
            school.SetActive(false);
            ending.SetActive(true);
            nameText.text = "이혜원";
        }
        else if (index == 26)
        {
            nameText.text = "";
        }
        else if (index == 28)
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
