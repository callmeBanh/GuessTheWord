using UnityEngine;
using TMPro;


public class ShopManager : MonoBehaviour
{
    public TextMeshProUGUI displayScoreText;
    void OnEnable()
    {
        // Mỗi khi mở cửa hàng lên thì cập nhật lại chữ hiển thị điểm
        UpdateUI();
    }



    public void UpdateUI()
    {
        displayScoreText.text = "Điểm: " + GameDataManager.Instance.GetScore().ToString();
    }

    // Hàm này gắn vào các nút Đổi Quà
    public void OnBuyButtonClick(int price)
    {
        bool success = GameDataManager.Instance.SpendScore(price);
        if (success)
        {
            Debug.Log("Đổi quà thành công!");
            UpdateUI();
            // Thêm hiệu ứng âm thanh hoặc thông báo chúc mừng ở đây
        }
        else
        {
            Debug.Log("Bạn không đủ điểm!");
        }
    }
}