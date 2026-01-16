using UnityEngine;

public class GiftBoxAnimation : MonoBehaviour
{
    [Header("Cấu hình hiệu ứng")]
    public float speed = 3.0f;        // Tốc độ nhấp nháy
    public float minScale = 0.9f;     // Kích thước nhỏ nhất
    public float maxScale = 1.1f;     // Kích thước lớn nhất

    private Vector3 originalScale;

    void Start()
    {
        // Lưu lại kích thước ban đầu của hộp quà
        originalScale = transform.localScale;
    }

    void Update()
    {
        // Dùng hàm PingPong để giá trị chạy qua lại giữa 0 và 1
        float t = Mathf.PingPong(Time.time * speed, 1.0f);

        // Dùng hàm Lerp để biến đổi mượt mà từ Min lên Max
        float currentScale = Mathf.Lerp(minScale, maxScale, t);

        // Áp dụng kích thước mới
        transform.localScale = originalScale * currentScale;
    }
}