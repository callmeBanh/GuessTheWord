using UnityEngine;
using TMPro;

public class GameDataManager : MonoBehaviour
{
    // Singleton để các script khác dễ dàng truy cập mà không cần kéo thả
    public static GameDataManager Instance;

    private string SCORE_KEY = "PlayerScore"; // Tên biến lưu dưới máy
    private int currentScore;

    void Awake()
    {
        // Khởi tạo Singleton
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        // Load điểm từ máy khi bắt đầu game
        currentScore = PlayerPrefs.GetInt(SCORE_KEY, 500);
    }

    // Hàm lấy điểm hiện tại
    public int GetScore() => currentScore;

    // Hàm cộng điểm (Gọi khi thắng câu hỏi)
    public void AddScore(int amount)
    {
        currentScore += amount;
        SaveData();
    }

    // Hàm trừ điểm (Gọi khi đổi quà)
    public bool SpendScore(int amount)
    {
        if (currentScore >= amount)
        {
            currentScore -= amount;
            SaveData();
            return true; // Đổi thành công
        }
        return false; // Không đủ điểm
    }

    private void SaveData()
    {
        PlayerPrefs.SetInt(SCORE_KEY, currentScore);
        PlayerPrefs.Save();
    }
}