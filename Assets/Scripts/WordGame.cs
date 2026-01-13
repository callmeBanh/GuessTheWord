using UnityEngine;
using UnityEngine.UI; // Thư viện để làm việc với UI (Text, InputField)
using TMPro;           // Nếu bạn dùng TextMeshPro (khuyên dùng)

public class WordGame : MonoBehaviour
{
    [Header("Cấu hình trò chơi")]
    public string[] wordList = { "APPLE", "BANANA", "UNITY", "GITHUB" };
    private string targetWord;
    private string hiddenWord;

    [Header("Giao diện UI")]
    public TextMeshProUGUI displayWordText; // Hiển thị từ dạng _ _ _
    public TMP_InputField inputField;      // Ô để người chơi nhập chữ

    void Start()
    {
        InitGame();
    }

    // Hàm khởi tạo trò chơi mới
    void InitGame()
    {
        // 1. Chọn ngẫu nhiên một từ trong danh sách
        targetWord = wordList[Random.Range(0, wordList.Length)].ToUpper();
        
        // 2. Tạo chuỗi gạch dưới tương ứng với độ dài của từ
        hiddenWord = "";
        for (int i = 0; i < targetWord.Length; i++)
        {
            hiddenWord += "_";
        }
        
        UpdateUI();
    }

    // Hàm kiểm tra khi người chơi nhấn nút đoán
    public void GuessLetter()
    {
        string input = inputField.text.ToUpper();

        if (!string.IsNullOrEmpty(input))
        {
            char letter = input[0]; // Chỉ lấy chữ cái đầu tiên
            char[] currentHidden = hiddenWord.ToCharArray();

            // Duyệt qua từ mục tiêu để xem chữ cái có tồn tại không
            for (int i = 0; i < targetWord.Length; i++)
            {
                if (targetWord[i] == letter)
                {
                    currentHidden[i] = letter;
                }
            }

            hiddenWord = new string(currentHidden);
            UpdateUI();
        }
        
        inputField.text = ""; // Xóa ô nhập sau khi đoán
    }

    void UpdateUI()
    {
        displayWordText.text = hiddenWord;
        
        if (hiddenWord == targetWord)
        {
            displayWordText.text = "CHIẾN THẮNG: " + targetWord;
        }
    }
}