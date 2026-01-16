using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LetterButton : MonoBehaviour
{
public TextMeshProUGUI letterText; // Kéo Text (TMP) vào đây
    public Button btnComp;             // Kéo Button vào đây
    public Image bgImage;              // Kéo Image nền vào đây

    [HideInInspector] public char myLetter; // Chữ cái của nút này
    private GameController gameController;

    public void Setup(char letter, GameController controller)
    {
        myLetter = letter;
        letterText.text = letter.ToString();
        gameController = controller;
        
        btnComp.onClick.RemoveAllListeners();
        btnComp.onClick.AddListener(OnClicked);
    }

    void OnClicked()
    {
        // Khi bấm nút, gọi Controller xử lý
        gameController.OnSourceLetterClicked(this);
    }

    public void SetVisible(bool isVisible)
    {
        // Ẩn/Hiện nút 
        bgImage.enabled = isVisible;
        letterText.enabled = isVisible;
        btnComp.interactable = isVisible;
    }
}
