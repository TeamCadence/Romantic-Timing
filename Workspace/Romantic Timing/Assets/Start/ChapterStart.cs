using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ChapterStart : MonoBehaviour
{
    public GameObject NamePanel;
    public TMP_InputField nameInputField;
    public TMP_Text WhattextDisplay;
    public string WhatNameText;
    public TMP_Text textDisplay;
    public string[] texts;
    private int index;
    public float typingSpeed = 0.1f;
    private bool isTyping = false;
    //�Ҹ�
    public AudioSource audioSource;
    public GameObject BGM;
    public GameObject bgm;

    void Start()
    {
        BGM = GameObject.Find("AudioManager");
        bgm.SetActive(false);
        NamePanel.SetActive(true);
        StartCoroutine(WhatText());
        nameInputField.onEndEdit.AddListener(delegate { SaveName(); });

    }
    IEnumerator WhatText()
    {
        for (int i = 0; i <= WhatNameText.Length; i++)
        {
            audioSource.Play();
            WhattextDisplay.text = WhatNameText.Substring(0, i);

            yield return new WaitForSeconds(typingSpeed);

        }
    }
    public void SaveName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
        NamePanel.SetActive(false);
        Destroy(BGM);
        bgm.SetActive(true);
        StartCoroutine(TypeText());

    }
    IEnumerator TypeText()
    {
        isTyping = true;
        string playerName = PlayerPrefs.GetString("PlayerName");
        string replaceText = texts[index].Replace("(player)", playerName).Replace("#", "\n");
        for (int i = 0; i <= replaceText.Length; i++)
            {
            audioSource.Play();
            textDisplay.text = replaceText.Substring(0, i);
            
            yield return new WaitForSeconds(typingSpeed); 
           
            }
           
            isTyping = false;
    }   
    private void Update()
    {
        if (!NamePanel.activeSelf && !isTyping && Input.GetKeyDown(KeyCode.Space))
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
        if (index < texts.Length - 1)
        {
            index++;
            textDisplay.text = ""; 
            StartCoroutine(TypeText());
        }
        else
        {
            SceneManager.LoadScene("Chapter1");
        }
    }
}


