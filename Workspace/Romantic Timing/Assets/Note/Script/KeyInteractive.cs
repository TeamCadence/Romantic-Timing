using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyInteractive : MonoBehaviour
{
    public List<GameObject> Arrows;

    public Sprite[] sprites;

    public GameObject complete;

    public Image heartgauge;

    public Image gauge;

    public int Index = 0; 

    public int play = 0;

    public int twinkleCount = 0;

    public GameObject ArrowSound;

    public GameObject spaceSound;

    public Sprite Sadimage;

    public GameObject People;

    private SpriteRenderer Peopleimage;

    public GameObject StartPanel;

    public GaugeSet gaugeset;

    public ScriptShowing scriptshow;

    public GameObject dontDestroy;

    public GameObject Countd;

    public GameObject GameOverPanel;

    public GameObject Play;

    public void Start()
    {
        Play = GameObject.Find("Play");
        gaugeset = FindObjectOfType<GaugeSet>();
        Peopleimage = People.GetComponent<SpriteRenderer>();
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

    void arrowSound()
    {
        ArrowSound.SetActive(true);
        Invoke("arrowSoundfalse", 0.12f);       
    }

    void arrowSoundfalse()
    {
        ArrowSound.SetActive(false);    
    }

    void SpaceSound()
    {
        spaceSound.SetActive(true);
        Invoke("SpaceSoundfalse", 1f);       
    }

    void SpaceSoundfalse()
    {
        spaceSound.SetActive(false);    
    }

    void EscapeBackdoor()
    {
        dontDestroy.transform.Find("Main Camera").gameObject.SetActive(false);
        dontDestroy.transform.Find("InGameUi").gameObject.SetActive(false);
        dontDestroy.transform.Find("GameManager").gameObject.SetActive(false);
        dontDestroy.transform.Find("Canvas").gameObject.SetActive(false);
        dontDestroy.transform.Find("Arrow").gameObject.SetActive(false);
        dontDestroy.transform.Find("EventSystem").gameObject.SetActive(false);
        dontDestroy.transform.Find("FakeComplete").gameObject.SetActive(false);
        SceneManager.LoadScene("Chatting1");
    }

    void Update()
    {
        //Backdoor
        if (Input.GetKeyDown(KeyCode.Q))
            EscapeBackdoor();

        if (Input.GetKeyDown(KeyCode.UpArrow) && StartPanel.activeSelf==false && GameOverPanel.activeSelf == false)
        {
            if(!compare(sprites[0]))
            {
                heartgauge.GetComponent<Image>().fillAmount -= 0.02f;
                WrongNote();
            }
            else
            {
                arrowSound();
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow) && StartPanel.activeSelf==false && GameOverPanel.activeSelf == false)
        {
            if(!compare(sprites[1]))
            {
                heartgauge.GetComponent<Image>().fillAmount -= 0.02f;
                WrongNote();
            }
            else
            {
                arrowSound();
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && StartPanel.activeSelf==false && GameOverPanel.activeSelf == false)
        {
            if(!compare(sprites[2]))
            {
                heartgauge.GetComponent<Image>().fillAmount -= 0.02f;
                WrongNote();
            }
            else
            {
                arrowSound();
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow) && StartPanel.activeSelf==false && GameOverPanel.activeSelf == false)
        {
            if(!compare(sprites[3]))
            {
                heartgauge.GetComponent<Image>().fillAmount -= 0.02f;
                WrongNote();
            }
            else
            {
                arrowSound();
            }
        }        

        if(Index == 4)
        {
            complete.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SpaceSound();
                Index = 0;
                foreach(GameObject arrow in Arrows)
                {
                    arrow.SetActive(true);
                }
                play+=1;
                heartgauge.fillAmount+=0.01f;
                complete.SetActive(false);
                gaugeset.StartGaugeAnimation(0, 100, 100, 1, 2f);
                scriptshow.NextText();
            }
            Arrows[0].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[1].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[2].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[3].GetComponent<SpriteRenderer>().color = Color.white;
        }

        if(heartgauge.fillAmount<=0.02f)
        {
            StartCoroutine("GameOver");
        }

        if(gauge.fillAmount<=0.01f)
        {
            gauge.fillAmount = 1f;
            Peopleimage.sprite = Sadimage;
            Index = 0;   
            foreach(GameObject arrow in Arrows)
            {
                arrow.SetActive(false);
                arrow.SetActive(true);
            }         
            heartgauge.GetComponent<Image>().fillAmount -= 0.02f; 
            complete.SetActive(false);
            Arrows[0].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[1].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[2].GetComponent<SpriteRenderer>().color = Color.white;
            Arrows[3].GetComponent<SpriteRenderer>().color = Color.white;            
        }

        if(play==53)
        {
            EscapeBackdoor();
        }
    }
    IEnumerator GameOver()
    {
        GameOverPanel.SetActive(true);
        StartCoroutine("GoToTitle");
        yield return null;
    }

    IEnumerator GoToTitle()
    {
        Countd.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(Play);
        SceneManager.LoadScene("Main");
    }

}