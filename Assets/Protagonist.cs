using UnityEngine;
using UnityEngine.InputSystem;

public class Protagonist : MonoBehaviour
{
   [SerializeField] float moveSpeed = 10f;
   [SerializeField] float steerSpeed = 200f;

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
        
        //rotate anti-/clockwise
        if (Keyboard.current.aKey.isPressed)
        {
            steer = 1f;
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            steer = -1f;
        }

        float moveAmt = move * moveSpeed * Time.deltaTime;
        float steerAmt = steer * steerSpeed * Time.deltaTime;
        transform.Translate(0, moveAmt, 0);
        transform.Rotate(0, 0, steerSpeed * steerAmt);
    }
}
