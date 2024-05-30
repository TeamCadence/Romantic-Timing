using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartPanel : MonoBehaviour
{
    public GameObject Countdown3;
    public GameObject Countdown2;
    public GameObject Countdown1;
    public GameObject CountdownGo;    
    public GameObject Dialog;

    private float timeset;

    // Start is called before the first frame update
    void Start()
    {
        Dialog.SetActive(false);
        timeset = 0;
        Countdown3.SetActive(true);
        Countdown2.SetActive(false);
        Countdown1.SetActive(false);
        CountdownGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeset += Time.deltaTime;
        if (timeset < 0.7f)
        {
            Countdown3.SetActive(true);
        }
        else if (timeset < 0.7f * 2)
        {
            Countdown3.SetActive(false);
            Countdown2.SetActive(true);
        }
        else if (timeset < 0.7f * 3)
        {
            Countdown2.SetActive(false);
            Countdown1.SetActive(true);
        }
        else if(timeset < 0.7f * 4)
        {
            Countdown1.SetActive(false);
            CountdownGo.SetActive(true);
        }
        else
        {
            suicide();
        }
    }

    void suicide()
    {
        Dialog.SetActive(true);
        gameObject.SetActive(false);
    }
}
