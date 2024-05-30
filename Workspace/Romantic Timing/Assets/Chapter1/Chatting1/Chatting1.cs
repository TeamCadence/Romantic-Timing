using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Chatting1 : MonoBehaviour
{
    // �޼��� ���
    public GameObject[] messages;
    public GameObject[] messages1;
    public GameObject[] messages2;
    public GameObject[] messages3;
    public GameObject[] messages4;
    public GameObject TextPanel;
    public float moveDistance = 1f;
    public float delay = 1f;
    // ������ ���
    public GameObject[] Button;
    // �÷��̾� ���
    public GameObject messageMy;
    public GameObject messageMy2;
    public GameObject messageMy3;
    public TMP_Text textDisplay;
    public TMP_Text textDisplay2;
    public TMP_Text textDisplay3;
    public string[] texts;
    public float typingSpeed = 0.05f;
    private int Click = 0;
    //����Ű�� ����
    public float threshold = 0.1f;
    //�Ҹ�
    public AudioSource audioSource;
    public AudioClip audioClipA;
    public AudioClip audioClipB;
    public GameObject What;
    public GameObject What2;
    public Image heartgauge;
    public GameObject play;

    private void Start()
    {
        heartgauge = GameObject.Find("Play").transform.Find("Canvas").transform.Find("HeartGauge").GetComponent<Image>();
        play = GameObject.Find("Play");
        foreach (GameObject obj in messages)
        {
            obj.SetActive(false);
        }
        messageMy.SetActive(false);
        messageMy2.SetActive(false);
        messageMy3.SetActive(false);
        What.SetActive(false);
        What2.SetActive(false);

        //선택지 비활성화
        disableButton();
        //혜원이 카톡 2개 올라옴
        StartCoroutine(Chat());
    }

    //혜원이 카톡 보내기
    IEnumerator Chat()
    {
        for (int i = 0; i < 2; i++)
        {
            Vector2 currentPosition = TextPanel.transform.position;
            Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
            TextPanel.transform.position = newPosition;
            messages[i].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
        //선택지 활성화
        Button[0].SetActive(true);
        Button[1].SetActive(true);
        What.SetActive(true);
    }

    public void disableButton()
    {
        foreach (GameObject obj in Button)
        {
            obj.SetActive(false);
        }    
    }

    //하와이안 피자고름
    public void Click1()
    {
        StartCoroutine(TypeText(texts[0]));
        Click = 1;
        audioSource.clip = audioClipA;
        audioSource.Play();
    }

    //엽떡고름
    public void Click2()
    {
        StartCoroutine(TypeText(texts[1]));
        Click = 2;
        audioSource.clip = audioClipB;
        audioSource.Play();
    }

    //하와이안 피자 강행
    public void Click3()
    {
        StartCoroutine(TypeText2(texts[3]));
        Click = 5;
        audioSource.clip = audioClipA;
        audioSource.Play();
    }

    //엽떡 강행
    public void Click4()
    {
        StartCoroutine(TypeText3(texts[2]));
        Click = 6;
        audioSource.clip = audioClipB;
        audioSource.Play();
    }

    //하와이안/엽떡 골랐을 때 내 메시지
    IEnumerator TypeText(string dialogue)
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        Vector2 currentPosition = TextPanel.transform.position;
        Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
        TextPanel.transform.position = newPosition;
        messageMy.SetActive(true);
        for (int i = 0; i <= dialogue.Length; i++)
        {
            textDisplay.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        //혜원이 대답

        yield return new WaitForSeconds(1);
        StartCoroutine(Chat2());

    }

    //강행했을 때 내 메시지
    IEnumerator TypeText2(string dialogue)
    {
        string playerName = PlayerPrefs.GetString("PlayerName");
        Vector2 currentPosition = TextPanel.transform.position;
        Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
        TextPanel.transform.position = newPosition;
        messageMy2.SetActive(true);
        for (int i = 0; i <= dialogue.Length; i++)
        {
            textDisplay2.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        //강행 후 혜원이 대답
        yield return new WaitForSeconds(1);
        StartCoroutine(Chat3());
    }
    IEnumerator TypeText3(string dialogue)
    {
        messages[0].SetActive(false);
        string playerName = PlayerPrefs.GetString("PlayerName");
        Vector2 currentPosition = TextPanel.transform.position;
        Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
        TextPanel.transform.position = newPosition;
        messageMy3.SetActive(true);
        for (int i = 0; i <= dialogue.Length; i++)
        {
            textDisplay3.text = dialogue.Substring(0, i);
            yield return new WaitForSeconds(typingSpeed);
        }
        //강행 후 혜원이 대답

        yield return new WaitForSeconds(1);
        StartCoroutine(Chat3());
    }

    void Update()
    {
        GameObject selectedObject = EventSystem.current.currentSelectedGameObject;
        //2번째 선택지 고르기 전
        if (Click == 0)
        {
            //하와이안 피자 선택
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {                
                Button[0].GetComponent<Button>().Select();
            }
            //엽떡 선택
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Button[1].GetComponent<Button>().Select();
            }
            if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[0].gameObject)
            {
                disableButton();
                Click1();
                What.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[1].gameObject)
            {
                disableButton();
                Click2();
                What.SetActive(false);
            }
        }
        //하와이안 2번째 선택지
        else if (Click == 3)
        {
            //강행
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Button[2].GetComponent<Button>().Select();
            }
            //다시생각
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            { 
                Button[3].GetComponent<Button>().Select();
            }
            if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[2].gameObject)
            {
                disableButton();
                Click3();
                What2.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[3].gameObject)
            {
                SceneManager.LoadScene("chatting1");
            }
        }
        //엽떡 2번째 선택지
        else if (Click == 4)
        {
            //강행
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Button[2].GetComponent<Button>().Select();
            }
            //다시생각
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            { 
                Button[3].GetComponent<Button>().Select();
                
            }
            if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[2].gameObject)
            {
                disableButton();
                Click4();
                What2.SetActive(false);
            }
            else if(Input.GetKeyDown(KeyCode.Space)&&selectedObject == Button[3].gameObject)
            {
                SceneManager.LoadScene("chatting1");
            }
        }
        
    }

    //
    IEnumerator Chat2()
    {
        //하와이안 피자 골랐을 때 
        if(Click ==1)
        {
            for (int i = 0; i < messages1.Length; i++)
            {
                Vector2 currentPosition = TextPanel.transform.position;
                Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
                TextPanel.transform.position = newPosition;
                messages1[i].SetActive(true);
                yield return new WaitForSeconds(delay);
            }
            //하와이안피자 2번째 선택지
            Click = 3;
            //선택지 활성화
            Button[2].SetActive(true);
            Button[3].SetActive(true);  
            What2.SetActive(true);
        }
        //엽떡 골랐을 때
        if (Click ==2)
        {
            for (int i = 0; i < messages2.Length; i++)
            {
                // �޽��� �ø���
                Vector2 currentPosition = TextPanel.transform.position;
                Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
                TextPanel.transform.position = newPosition;
                messages2[i].SetActive(true);
                yield return new WaitForSeconds(delay);
            }
            //엽떡 2번째 선택지
            Click = 4;
            //선택지 활성화
            Button[2].SetActive(true);
            Button[3].SetActive(true);  
            What2.SetActive(true);
        }
    }

    IEnumerator Chat3()
    {
        //하와이안 피자 강행 혜원이 대답
        if(Click == 5)
        {
            messages[0].SetActive(false);
            for (int i = 0; i < messages3.Length; i++)
            {
                Vector2 currentPosition = TextPanel.transform.position;
                Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
                TextPanel.transform.position = newPosition;
                messages3[i].SetActive(true);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(1);

            Destroy(play);

            if(heartgauge.fillAmount>=0.8f)
            {
                SceneManager.LoadScene("Pine Happy");
            }
            else if(heartgauge.fillAmount<0.8f&&heartgauge.fillAmount>=0.5f)
            {
                SceneManager.LoadScene("Pine Normal");
            }
            else if(heartgauge.fillAmount<0.5f)
            {
                SceneManager.LoadScene("Pine Bad");
            }
        }
        //엽떡 강행 혜원이 대답
        if (Click == 6)
        {
            messages[0].SetActive(false);
            messages[1].SetActive(false);
            for (int i = 0; i < messages4.Length; i++)
            {
                Vector2 currentPosition = TextPanel.transform.position;
                Vector2 newPosition = currentPosition + Vector2.up * moveDistance;
                TextPanel.transform.position = newPosition;
                messages4[i].SetActive(true);
                yield return new WaitForSeconds(delay);
            }

            yield return new WaitForSeconds(1);

            Destroy(play);

            if(heartgauge.fillAmount==1f)
            {
                SceneManager.LoadScene("Hot Happy");
            }
            else if(heartgauge.fillAmount<1f&&heartgauge.fillAmount>=0.7f)
            {
                SceneManager.LoadScene("Hot Normal");
            }
            else if(heartgauge.fillAmount<0.7f)
            {
                SceneManager.LoadScene("Hot Bad");
            }
        }
    }
}




