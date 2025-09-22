using UnityEngine;

public class PersistentCam : MonoBehaviour
{
    private static PersistentCam instance;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // Persist across scenes
    }
}

