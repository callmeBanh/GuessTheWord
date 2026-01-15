using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerSlot : MonoBehaviour
{public TextMeshProUGUI letterText; // Kéo Text (TMP) vào đây
    public Button btnComp;             // Kéo Button vào đây

    private LetterButton sourceButton; // Lưu nút gốc đã bay vào đây
    private GameController gameController;

    // Kiểm tra xem ô này có chữ chưa
    public bool IsOccupied { get { return sourceButton != null; } }

    public void Setup(GameController controller)
    {
        gameController = controller;
        btnComp.onClick.RemoveAllListeners();
        btnComp.onClick.AddListener(OnClicked);
        ClearSlot(); // Mặc định xóa sạch khi mới tạo
    }

    public void FillLetter(LetterButton source)
    {
        sourceButton = source;
        letterText.text = source.myLetter.ToString();
        letterText.enabled = true;
    }

    public void ClearSlot()
    {
        sourceButton = null;
        letterText.text = "";
        letterText.enabled = true;
    }

    void OnClicked()
    {
        if (IsOccupied)
        {
            // 1. Trả nút gốc về trạng thái hiện
            sourceButton.SetVisible(true);
            
            // 2. Xóa ô này đi
            ClearSlot();

            // 3. Báo game biết là người chơi vừa xóa chữ (để bỏ trạng thái thắng/thua nếu có)
            gameController.OnAnswerChanged();
        }
    }
}
