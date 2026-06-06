using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text keyText;
    public Text hintText;
    public Text messageText;

    void Start()
    {
        GameState.Instance.OnKeyChanged += UpdateKeyUI;
        GameState.Instance.OnHintChanged += UpdateHintUI;

        UpdateKeyUI();
        UpdateHintUI();
    }

    void UpdateKeyUI()
    {
        keyText.text = GameState.Instance.HasKey ? "Key: Yes" : "Key: No";
    }

    void UpdateHintUI()
    {
        hintText.text = $"Hint: {GameState.Instance.HintCount}/3";
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        Invoke(nameof(ClearMessage), 2f);
    }

    void ClearMessage()
    {
        messageText.text = "";
    }
}