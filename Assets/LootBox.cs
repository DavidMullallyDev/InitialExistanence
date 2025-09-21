using UnityEngine;
using UnityEngine.InputSystem;

public class LootBox : MonoBehaviour
{
    [SerializeField] Sprite lootOpened;
    [SerializeField] Sprite lootClosed;
    private SpriteRenderer sr;
    bool isNearLoot;
    bool isOpened;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = lootClosed;
    }

    // Update is called once per frame
    void Update()
    {
        if (isNearLoot && !isOpened && Keyboard.current.qKey.IsPressed()) sr.sprite = lootOpened;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isNearLoot = true;
        Debug.Log("Collision Entered");
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isNearLoot = false;
        Debug.Log("Collision Exited");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Entered");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Trigger Exited");
    }
}
