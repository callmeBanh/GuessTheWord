using UnityEngine;
using UnityEngine.UI; // Cần thư viện này để chỉnh sửa hình ảnh UI

public class SoundButton : MonoBehaviour
{
    [Header("Kéo hình ảnh vào đây")]
    public Sprite soundOnIcon;  // Hình loa mở
    public Sprite soundOffIcon; // Hình loa tắt

    private Image buttonImage;  // Biến để lưu cái Image của nút
    private bool isMuted = false;

    void Start()
    {
        buttonImage = GetComponent<Image>();
        
        // Kiểm tra xem lần trước chơi game người ta có tắt tiếng không
        if (PlayerPrefs.GetInt("Muted", 0) == 1)
        {
            isMuted = true;
            AudioListener.volume = 0; // Tắt tiếng toàn bộ game
            buttonImage.sprite = soundOffIcon;
        }
        else
        {
            isMuted = false;
            AudioListener.volume = 1; // Mở tiếng
            buttonImage.sprite = soundOnIcon;
        }
    }

    // Hàm này sẽ gán cho nút bấm
    public void ToggleSound()
    {
        isMuted = !isMuted; // Đảo ngược trạng thái (đang mở thành tắt, tắt thành mở)

        if (isMuted)
        {
            AudioListener.volume = 0; // Tắt tiếng
            buttonImage.sprite = soundOffIcon; // Đổi hình
            PlayerPrefs.SetInt("Muted", 1); // Lưu lại là đã tắt
        }
        else
        {
            AudioListener.volume = 1; // Mở tiếng
            buttonImage.sprite = soundOnIcon; // Đổi hình
            PlayerPrefs.SetInt("Muted", 0); // Lưu lại là đã mở
        }
    }
}
