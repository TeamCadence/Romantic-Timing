using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public RectTransform TitleUP;
    public RectTransform[] ButtonsUP;
    public float moveSpeed = 100f;
    public float fadeSpeed = 0.5f; // 타이틀 및 버튼의 페이드 속도

    private bool titleMoved = false;
    private bool buttonsMoved = false;
    private Vector2 targetTitlePosition;
    private Vector2[] targetButtonPositions;
    private CanvasGroup titleCanvasGroup;

    void Start()
    {
        // 타이틀의 목표 위치 설정 (앵커 위치)
        targetTitlePosition = TitleUP.anchoredPosition;
        targetTitlePosition.y = 0; // 화면 맨 위로 이동

        // 버튼들의 목표 위치 설정 (앵커 위치)
        targetButtonPositions = new Vector2[ButtonsUP.Length];
        for (int i = 0; i < ButtonsUP.Length; i++)
        {
            targetButtonPositions[i] = ButtonsUP[i].anchoredPosition;
            targetButtonPositions[i].y = 0; // 화면 맨 위로 이동
        }

        // 타이틀의 CanvasGroup 컴포넌트 가져오기
        titleCanvasGroup = TitleUP.GetComponent<CanvasGroup>();

        // CanvasGroup 컴포넌트가 없으면 경고 출력
        if (titleCanvasGroup == null)
        {
            Debug.LogWarning("CanvasGroup 컴포넌트를 찾을 수 없습니다. 타이틀 오브젝트에 수동으로 추가해주세요.");
        }
        else
        {
            // 시작시 투명도를 0으로 설정
            titleCanvasGroup.alpha = 0f;
        }

        // 버튼들의 CanvasGroup 컴포넌트 가져오기
        foreach (RectTransform button in ButtonsUP)
        {
            CanvasGroup buttonCanvasGroup = button.GetComponent<CanvasGroup>();
            if (buttonCanvasGroup == null)
            {
                Debug.LogWarning("CanvasGroup 컴포넌트를 찾을 수 없습니다. 각 버튼 오브젝트에 수동으로 추가해주세요.");
            }
            else
            {
                // 시작시 투명도를 0으로 설정
                buttonCanvasGroup.alpha = 0f;
            }
        }
    }

    void Update()
    {
        if (!titleMoved)
        {
            // 타이틀 위치 이동
            TitleUP.anchoredPosition = Vector2.MoveTowards(TitleUP.anchoredPosition, targetTitlePosition, moveSpeed * Time.deltaTime);
            // 투명도 점진적으로 증가
            titleCanvasGroup.alpha += fadeSpeed * Time.deltaTime;

            if (TitleUP.anchoredPosition == targetTitlePosition)
            {
                titleMoved = true;
            }
        }

        if (titleMoved && !buttonsMoved)
        {
            // 버튼들 동시에 이동 및 투명도 조절
            foreach (RectTransform button in ButtonsUP)
            {
                button.anchoredPosition = Vector2.MoveTowards(button.anchoredPosition, targetButtonPositions[0], moveSpeed * Time.deltaTime);
                CanvasGroup buttonCanvasGroup = button.GetComponent<CanvasGroup>();
                if (buttonCanvasGroup != null)
                {
                    buttonCanvasGroup.alpha += fadeSpeed * Time.deltaTime;
                }
            }

            if (ButtonsUP[ButtonsUP.Length - 1].anchoredPosition == targetButtonPositions[ButtonsUP.Length - 1])
            {
                buttonsMoved = true;
            }
        }
    }
}
