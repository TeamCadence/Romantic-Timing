using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Chapter1 : MonoBehaviour
{
    //é�� ���
    public GameObject ChapterPanel;
    public TMP_Text chapterDisplay;
    public string chaptertext;
    //��ȭâ ���
    public TMP_Text textDisplay;
    public string[] texts;
    private int index;
    public float typingSpeed = 0.1f;
    private bool isTyping = false; 
    //ǥ�� ��ȭ
    public Sprite Normalimage;
    public Sprite Eyeimage;
    public Sprite Smileimage;
    public Sprite Sadimage;
    public Sprite Talkimage;
    public Image Peopleimage;
    public GameObject People;
    //�̸� ��ȭ
    public TMP_Text nameText;
    public AudioSource audioSource;
    public GameObject bgm;
    public AudioSource backmusic;

    void Start()
    {
        bgm = GameObject.Find("BGMManager");
        backmusic = bgm.GetComponent<AudioSource>();
        Peopleimage = GameObject.Find("People").GetComponent<Image>();
        People.SetActive(false);
        //é�� ���
        ChapterPanel.SetActive(true);
        StartCoroutine(ChapterText());
    }

    IEnumerator ChapterText()
    {

        yield return new WaitForSeconds(1);
        for (int i = 0; i <= chaptertext.Length; i++)
        {
            audioSource.Play();
            chapterDisplay.text = chaptertext.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(1);
        ChapterPanel.SetActive(false);
        chapterDisplay.gameObject.SetActive(false);
        StartCoroutine(TypeText());

    }
    IEnumerator TypeText()
    {
        //��ȭâ �� �÷��̾� �̸� ��� 
        string playerName = PlayerPrefs.GetString("PlayerName");
        string replaceText = texts[index].Replace("(player)", playerName).Replace("#", "\n");
        FaceChange();
        //��ȭâ ���
        isTyping = true;
        for (int i = 0; i <= replaceText.Length; i++)
        {
            audioSource.Play();
            textDisplay.text = replaceText.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        isTyping = false;
        
    }
    void FaceChange()
    {

        //ǥ�� ��ȭ
        if (index == 3)
        {
            //���̵� �ƿ�
            ChapterPanel.SetActive(true);
            //��ȭâ �ѱ��
            NextText();
            Invoke("ComeOn", 1f);
        }
        else if (index == 5)
        {
            //ǥ�� ��ȭ
            Peopleimage.sprite = Eyeimage;
            nameText.text = "  ???";
        }
        else if (index == 6)
        {
            nameText.text = "";
        }
        else if (index == 7)
        {
            Peopleimage.sprite = Talkimage;
            nameText.text = "  ???";
        }
        else if(index ==8)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = "  " + playerName;
        }
        else if (index == 9)
        {
            Peopleimage.sprite = Smileimage;
            nameText.text = "  ???";
        }
        else if (index == 10)
        {
            nameText.text = "";
        }
        else if (index == 11)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = "  " + playerName;
        }
        else if(index == 12)
        {
            nameText.text = "  이혜원";
        }
        else if (index == 13)
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = "  " + playerName;
        }
        else if (index ==14)
        {
            nameText.text = "";
        }
        else if(index == 16)
        {
            Destroy(bgm);
            SceneManager.LoadScene("Note");
        }
    }
    public void ComeOn()
    {
        People.SetActive(true);
        Peopleimage.sprite = Normalimage;
        ChapterPanel.SetActive(false);
    }
    private void Update()
    {
        //��ȭâ �ѱ��
        if (!ChapterPanel.activeSelf && !isTyping && Input.GetKeyDown(KeyCode.Space))
        {
            NextText();
        }
        //��ȭâ ��� �ӵ� ����
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
        //��ȭâ ���
        if (index < texts.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeText());
        }
        else
        {
            //�ؽ�Ʈ�� ��� ��� �Ϸ��
        }
    }
}