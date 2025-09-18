using UnityEngine;
using UnityEngine.InputSystem;

public class Protagonist : MonoBehaviour
{
   [SerializeField] float moveSpeed = 0.05f;
   [SerializeField] float turnSpeed = 1.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float move = 0;
        float steer = 0;

        //forwards/backwards
        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        transform.Translate(0, move * moveSpeed, 0);

        //rotate anti-/clockwise
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }
        transform.Rotate(0, 0, turnSpeed * steer);
    }
}
