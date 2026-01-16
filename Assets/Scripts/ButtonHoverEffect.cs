using UnityEngine;
using UnityEngine.EventSystems; // Thư viện để bắt sự kiện chuột

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Cấu hình hiệu ứng")]
    public float scaleFactor = 1.1f; // Độ to ra (1.1 là to hơn 10%)
    public float speed = 5.0f;       // Tốc độ nhấp nháy

    private Vector3 originalScale;
    private bool isHovering = false;

    void Start()
    {
        // Lưu lại kích thước ban đầu của nút
        originalScale = transform.localScale;
    }

    void OnDisable()
    {
        // Khi tắt menu thì reset lại nút để tránh bị lỗi to nhỏ
        transform.localScale = originalScale;
        isHovering = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Khi chuột đi VÀO
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Khi chuột đi RA
        isHovering = false;
        transform.localScale = originalScale; // Trả về kích thước gốc ngay lập tức
    }

    void Update()
    {
        if (isHovering)
        {
            // Công thức toán học (Sin) để tạo nhịp điệu lên xuống mượt mà
            float scale = 1 + Mathf.Sin(Time.time * speed) * (scaleFactor - 1) * 0.5f;

            // Áp dụng kích thước mới
            transform.localScale = originalScale * (1 + (scale - 1));

            // Hoặc đơn giản hơn: 
            // transform.localScale = Vector3.Lerp(transform.localScale, originalScale * scaleFactor, Time.deltaTime * speed);
            // Nhưng dùng Mathf.Sin ở trên sẽ tạo hiệu ứng "thở" (to ra rồi nhỏ lại liên tục)
        }
    }
}