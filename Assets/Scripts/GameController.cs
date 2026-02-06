using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Dùng cho Image thường
using TMPro;
using UnityEngine.SceneManagement;
using System;          // Dùng cho Text

public class GameController : MonoBehaviour
{
   // cấu hình level trò chơi ở đây
   public List<LevelData> levels; // tạo danh sách màng chơi
   public string randomChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; // các ký tự ngẫu nhiên

   // giao diện game
   public Image questionImage;
    public TextMeshProUGUI scoreText;
    public Transform answerContainer; // Nơi chứa các ký tự trả lời
    public Transform sourceContainer;  // Nơi chứa các ký tự lựa chọn

    // prefabs
    public GameObject answerCharPrefab; // ô trả lời
    public GameObject sourceCharPrefab; // ô kí tự lựa chọn

    private int currentLevelIndex = 0; // chỉ số level hiện tại
    private List <AnswerSlot> answerSlots = new List<AnswerSlot>();
    private List <LetterButton> letterButtons = new List<LetterButton>();
    public GameDataManager gameDataManager;

    void Start()
    {
       currentLevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
         LoadLevel(currentLevelIndex);
    }

    public void LoadLevel(int index)
    {
        if(index >= levels.Count)
        {
            Debug.LogError("end Game!");
            return;
        }

        currentLevelIndex = index;
        LevelData level = levels[index];

        // Cập nhật giao diện
       questionImage.sprite = level.image;
       scoreText.text = "Điểm: " + gameDataManager.GetScore().ToString();
     


       // Xóa các ký tự cũ

       foreach(Transform child in answerContainer)
       {
           Destroy(child.gameObject);
       }
         foreach(Transform child in sourceContainer)
         {
              Destroy(child.gameObject);

         }

         answerSlots.Clear();
         letterButtons.Clear();
         // Tạo các ô trả lời

         String answer = level.answer.ToUpper();

         foreach(char c in answer)
         {
             GameObject answerObj = Instantiate(answerCharPrefab, answerContainer);
             AnswerSlot slot = answerObj.GetComponent<AnswerSlot>();
             slot.Setup(this);
             answerSlots.Add(slot);
         }
            // Tạo các nút chữ cái lựa chọn

            List<char> sourceChars = new List<char>();
            sourceChars.AddRange(answer.ToCharArray());
            // Thêm các ký tự ngẫu nhiên vào
            int totalButton = 12;
            while(sourceChars.Count < totalButton)
            {
                sourceChars.Add(randomChars[UnityEngine.Random.Range(0, randomChars.Length)]);
            }
            // Trộn danh sách ký tự
            Shuffle(sourceChars);

            foreach(char c in sourceChars)
            {
                GameObject letterObj = Instantiate(sourceCharPrefab, sourceContainer);
                LetterButton letterBtn = letterObj.GetComponent<LetterButton>();
                letterBtn.Setup(c, this);
                letterButtons.Add(letterBtn);
            }

             
         
        
    }

    // Xử lý khi bấm nút bên phải
    public void OnSourceLetterClicked(LetterButton clickedBtn)
    {
        // Tìm ô trống đầu tiên
        foreach (AnswerSlot slot in answerSlots)
        {
            if (!slot.IsOccupied)
            {
                slot.FillLetter(clickedBtn); // Điền chữ vào
                clickedBtn.SetVisible(false); // Ẩn nút gốc
                CheckWin(); // Kiểm tra thắng chưa
                return;
            }
        }
    }

    public void OnAnswerChanged()
    {
        // Hàm này chạy khi người chơi xóa bớt chữ -> chắc chắn chưa thắng
        // Có thể ẩn hiệu ứng sai nếu cần
    }

    void CheckWin()
    {
        string currentAnswer = "";
        foreach (AnswerSlot slot in answerSlots)
        {
            if (!slot.IsOccupied) return; // Chưa điền hết
            currentAnswer += slot.letterText.text;
        }

        if (currentAnswer == levels[currentLevelIndex].answer.ToUpper())
        {
            Debug.Log("CHIẾN THẮNG!");
            SceneManager.LoadScene("Victory");
            gameDataManager.AddScore(100); // Thưởng 100 điểm khi thắng
        }
    }

    // Nút "Bài tiếp theo" sẽ gọi hàm này
    public void NextLevel()
    {
        LoadLevel(currentLevelIndex + 1);
    }

    void Shuffle<T>(List<T> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            T temp = list[i];
            int r = UnityEngine.Random.Range(i, list.Count);
            list[i] = list[r];
            list[r] = temp;
        }
    }
}
