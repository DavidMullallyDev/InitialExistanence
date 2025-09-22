using TMPro;
using UnityEngine;

public class PersistantUI : MonoBehaviour
{
    public static PersistantUI Instance { get; private set; }

    [SerializeField] private TMP_Text persistentText;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetText(string newText)
    {
        persistentText.text = newText;
    }
}