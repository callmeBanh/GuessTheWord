using UnityEngine;

public class MusicDontDestroy : MonoBehaviour
{
    // Biến static để kiểm tra xem đã có nhạc chưa
    public static MusicDontDestroy instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
       
        else
        {
            Destroy(gameObject);
        }
    }
}