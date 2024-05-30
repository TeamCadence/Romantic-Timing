using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeSet : MonoBehaviour
{
    public Image gauge;
    public Image heartgauge;
    public GameObject complete;
    public bool activeSelf;
    private bool isAnimating = false;
    private float elapsedTime = 0f;
    private float startValue;
    private float targetValue;
    private float animationTime;
    private int min;
    private int max;
    public GameObject StartPanel;
    public GameObject GameOverPanel;

    void OnEnable()
    {
        SomeMethod();
    }

    void Update()
    {
        if(StartPanel.activeSelf==true)
        {
            return;
        }

        if(GameOverPanel.activeSelf==true)
        {
            return;
        }

        if (isAnimating)
        {
            elapsedTime += Time.deltaTime;
            float currentValue = startValue + ((targetValue - startValue) * (elapsedTime / animationTime));
            gauge.fillAmount = (currentValue - min) / (max - min);

            if (elapsedTime >= animationTime)
            {
                isAnimating = false;
                gauge.fillAmount = (targetValue - min) / (max - min);
            }
        }
        /*
        if(complete.activeSelf == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("q");
                SomeMethod();
            }
        }
        */

        if(gauge.fillAmount<=0.01f)
        {
            SomeMethod();
        }
    }

    public void StartGaugeAnimation(int min, int max, int startValue, int targetValue, float animationTime)
    {
        this.min = min;
        this.max = max;
        this.startValue = startValue;
        this.targetValue = targetValue;
        this.animationTime = animationTime;

        elapsedTime = 0f;
        isAnimating = true;
    }

    public void SomeMethod()
    {
        StartGaugeAnimation(0, 100, 100, 1, 2f); // 예: 5초 동안 20에서 80으로 애니메이션
    }

}
