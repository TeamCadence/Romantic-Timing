using UnityEngine;

public class MoveUp : MonoBehaviour
{
    public RectTransform TitleUP;
    public RectTransform[] ButtonsUP;
    public float moveSpeed = 100f;
    public float fadeSpeed = 0.5f; // Ÿ��Ʋ �� ��ư�� ���̵� �ӵ�

    private bool titleMoved = false;
    private bool buttonsMoved = false;
    private Vector2 targetTitlePosition;
    private Vector2[] targetButtonPositions;
    private CanvasGroup titleCanvasGroup;

    void Start()
    {
        // Ÿ��Ʋ�� ��ǥ ��ġ ���� (��Ŀ ��ġ)
        targetTitlePosition = TitleUP.anchoredPosition;
        targetTitlePosition.y = 0; // ȭ�� �� ���� �̵�

        // ��ư���� ��ǥ ��ġ ���� (��Ŀ ��ġ)
        targetButtonPositions = new Vector2[ButtonsUP.Length];
        for (int i = 0; i < ButtonsUP.Length; i++)
        {
            targetButtonPositions[i] = ButtonsUP[i].anchoredPosition;
            targetButtonPositions[i].y = 0; // ȭ�� �� ���� �̵�
        }

        // Ÿ��Ʋ�� CanvasGroup ������Ʈ ��������
        titleCanvasGroup = TitleUP.GetComponent<CanvasGroup>();

        // CanvasGroup ������Ʈ�� ������ ��� ���
        if (titleCanvasGroup == null)
        {
            Debug.LogWarning("CanvasGroup ������Ʈ�� ã�� �� �����ϴ�. Ÿ��Ʋ ������Ʈ�� �������� �߰����ּ���.");
        }
        else
        {
            // ���۽� ������ 0���� ����
            titleCanvasGroup.alpha = 0f;
        }

        // ��ư���� CanvasGroup ������Ʈ ��������
        foreach (RectTransform button in ButtonsUP)
        {
            CanvasGroup buttonCanvasGroup = button.GetComponent<CanvasGroup>();
            if (buttonCanvasGroup == null)
            {
                Debug.LogWarning("CanvasGroup ������Ʈ�� ã�� �� �����ϴ�. �� ��ư ������Ʈ�� �������� �߰����ּ���.");
            }
            else
            {
                // ���۽� ������ 0���� ����
                buttonCanvasGroup.alpha = 0f;
            }
        }
    }

    void Update()
    {
        if (!titleMoved)
        {
            // Ÿ��Ʋ ��ġ �̵�
            TitleUP.anchoredPosition = Vector2.MoveTowards(TitleUP.anchoredPosition, targetTitlePosition, moveSpeed * Time.deltaTime);
            // ���� ���������� ����
            titleCanvasGroup.alpha += fadeSpeed * Time.deltaTime;

            if (TitleUP.anchoredPosition == targetTitlePosition)
            {
                titleMoved = true;
            }
        }

        if (titleMoved && !buttonsMoved)
        {
            // ��ư�� ���ÿ� �̵� �� ���� ����
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
