using UnityEngine;
using TMPro;

public class DisplayName : MonoBehaviour
{
    public TMP_Text nameText;
    void Update()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string playerName = PlayerPrefs.GetString("PlayerName");
            nameText.text = playerName;
        }
    }
}
