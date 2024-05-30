using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    public GameObject ExplainPanel;
    public GameObject MakerPanel;
    public AudioSource audioSource;
    public GameObject eastereggpanel;
    public int easteregg = 0;
    
    void Start()
    {
        ExplainPanel.SetActive(false);
        MakerPanel.SetActive(false);
        eastereggpanel.SetActive(false);
        audioSource.Stop();
    }
    public void SelectStart()
    {
        audioSource.Play();
        SceneManager.LoadScene("Start");
    }
    public void SelectExplain()
    {
        audioSource.Play();
        ExplainPanel.SetActive(true);
    }
    public void SelectMaker()
    {
        audioSource.Play();
        MakerPanel.SetActive(true);
    }
    public void PanelOff()
    {
        audioSource.Play();
        ExplainPanel.SetActive(false);
        MakerPanel.SetActive(false);
        eastereggpanel.SetActive(false);
        easteregg = 0;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            easteregg ++;
        }
        if(easteregg > 10)
        {
            eastereggpanel.SetActive(true);
        }
    }
}
