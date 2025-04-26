using UnityEngine;

// Genel Singleton sınıfı
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // Tipe göre instance oluşturuluyor
                _instance = FindObjectOfType<T>();
                
                // Eğer scene'de yoksa, yeni bir GameObject oluşturulup ona bağlanıyor
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(T).Name);
                    _instance = singletonObject.AddComponent<T>();
                }

                // Singleton'ın var olduğunu belirten bir mesaj
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

}
