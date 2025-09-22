using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Protagonist : MonoBehaviour
{
   [SerializeField] float moveSpeed = 10f;
   [SerializeField] float cooldownTime = 5f;
   [SerializeField] Sprite defaultSprite;
   [SerializeField] Sprite defaultSpriteWalkingLeftLeftFoot;
   [SerializeField] Sprite defaultSpriteWalkingLeftRightFoot;
   [SerializeField] Sprite defaultSpriteWalkingRightLeftFoot;
   [SerializeField] Sprite defaultSpriteWalkingRightRightFoot;
   [SerializeField] Sprite defaultSpriteWalkingUptLeftFoot;
   [SerializeField] Sprite defaultSpriteWalkingUpRightFoot;
   [SerializeField] Sprite defaultSpriteWalkingDownLeftFoot;
   [SerializeField] Sprite defaultSpriteWalkingDownRightFoot;
   [SerializeField] Sprite defaultSpriteLightAttackLeft;
   [SerializeField] Sprite defaultSpriteLightAttackRight;
   [SerializeField] Sprite defaultSpriteLightAttackUp;
   [SerializeField] Sprite defaultSpriteLightAttackDown;
   [SerializeField] Sprite altSprite1;
   [SerializeField] Sprite altSprite1WalkingLeftLeftFoot;
   [SerializeField] Sprite altSprite1WalkingLeftRightFoot;
   [SerializeField] Sprite altSprite1WalkingRightLeftFoot;
   [SerializeField] Sprite altSprite1WalkingRightRightFoot;
   [SerializeField] Sprite altSprite1WalkingUptLeftFoot;
   [SerializeField] Sprite altSprite1WalkingUpRightFoot;
   [SerializeField] Sprite altSprite1WalkingDownLeftFoot;
   [SerializeField] Sprite altSprite1WalkingDownRightFoot;
   [SerializeField] Sprite altSprite1LightAttackLeft;
   [SerializeField] Sprite altSprite1LightAttackRight;
   [SerializeField] Sprite altSprite1LightAttackUp;
   [SerializeField] Sprite altSprite1LightAttackDown;
   [SerializeField] Sprite altSprite2;
   [SerializeField] Sprite altSprite2WalkingLeftLeftFoot;
   [SerializeField] Sprite altSprite2WalkingLeftRightFoot;
   [SerializeField] Sprite altSprite2WalkingRightLeftFoot;
   [SerializeField] Sprite altSprite2WalkingRightRightFoot;
   [SerializeField] Sprite altSprite2WalkingUptLeftFoot;
   [SerializeField] Sprite altSprite2WalkingUpRightFoot;
   [SerializeField] Sprite altSprite2WalkingDownLeftFoot;
   [SerializeField] Sprite altSprite2WalkingDownRightFoot;
   [SerializeField] Sprite altSprite2LightAttackLeft;
   [SerializeField] Sprite altSprite2LightAttackRight;
   [SerializeField] Sprite altSprite2LightAttackUp;
   [SerializeField] Sprite altSprite2LightAttackDown;
   [SerializeField] Sprite altSprite3;
   [SerializeField] Sprite altSprite3WalkingLeftLeftFoot;
   [SerializeField] Sprite altSprite3WalkingLeftRightFoot;
   [SerializeField] Sprite altSprite3WalkingRightLeftFoot;
   [SerializeField] Sprite altSprite3WalkingRightRightFoot;
   [SerializeField] Sprite altSprite3WalkingUptLeftFoot;
   [SerializeField] Sprite altSprite3WalkingUpRightFoot;
   [SerializeField] Sprite altSprite3WalkingDownLeftFoot;
   [SerializeField] Sprite altSprite3WalkingDownRightFoot;
   [SerializeField] Sprite altSprite3LightAttackLeft;
   [SerializeField] Sprite altSprite3LightAttackRight;
   [SerializeField] Sprite altSprite3LightAttackUp;
   [SerializeField] Sprite altSprite3LightAttackDown;
   [SerializeField] Sprite altSprite4;
   [SerializeField] Sprite altSprite4WalkingLeftLeftFoot;
   [SerializeField] Sprite altSprite4WalkingLeftRightFoot;
   [SerializeField] Sprite altSprite4WalkingRightLeftFoot;
   [SerializeField] Sprite altSprite4WalkingRightRightFoot;
   [SerializeField] Sprite altSprite44WalkingUptLeftFoot;
   [SerializeField] Sprite altSprite4WalkingUpRightFoot;
   [SerializeField] Sprite altSprite4WalkingDownLeftFoot;
   [SerializeField] Sprite altSprite4WalkingDownRightFoot;
   [SerializeField] Sprite altSprite4LightAttackLeft;
   [SerializeField] Sprite altSprite4LightAttackRight;
   [SerializeField] Sprite altSprite4LightAttackUp;
   [SerializeField] Sprite altSprite4LightAttackDown;
   [SerializeField] Sprite altSprite5;
   [SerializeField] Sprite altSprite5WalkingLeftLeftFoot;
   [SerializeField] Sprite altSprite5WalkingLeftRightFoot;
   [SerializeField] Sprite altSprite5WalkingRightLeftFoot;
   [SerializeField] Sprite altSprite5WalkingRightRightFoot;
   [SerializeField] Sprite altSprite5WalkingUptLeftFoot;
   [SerializeField] Sprite altSprite5WalkingUpRightFoot;
   [SerializeField] Sprite altSprite5WalkingDownLeftFoot;
   [SerializeField] Sprite altSprite5WalkingDownRightFoot;
   [SerializeField] Sprite altSprite5LightAttackLeft;
   [SerializeField] Sprite altSprite5LightAttackRight;
   [SerializeField] Sprite altSprite5LightAttackUp;
   [SerializeField] Sprite altSprite5LightAttackDown;
   [SerializeField] TMP_Text selectCharacterText;
   [SerializeField] TMP_Text expText;
   [SerializeField] string lastDir = "up";
    float exp = 0;
    
    public float Experience
    {
        get { return exp; }
        set { exp = Mathf.Max(0, value); } // prevent negative XP
    }
   int selectedCharter = 0;
   private SpriteRenderer sr;
   private bool canSelectCharacter = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       sr = GetComponent<SpriteRenderer>();
       selectCharacterText.gameObject.SetActive(true);
       sr.sprite = defaultSprite;
        expText.text = "EXP 0";
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float moveY = Input.GetAxisRaw("Vertical");   // W/S or Up/Down

        float move = 0;
        //float steer = 0;

        selectCharacterText.gameObject.SetActive(canSelectCharacter);

            // Direction logic
            if (moveX > 0)
            {
                sr.sprite = defaultSpriteWalkingRightRightFoot;
                lastDir = "right";
                move = 1f;
            }
            else if (moveX < 0)
            {
                sr.sprite = defaultSpriteWalkingLeftRightFoot;
                lastDir = "left";
                move = -1f;
            }
            else if (moveY > 0)
            {
                sr.sprite = defaultSpriteWalkingUpRightFoot;
                lastDir = "up";
                move = 1f;
            }
            else if (moveY < 0)
            {
                sr.sprite = defaultSpriteWalkingDownRightFoot;
                lastDir = "down";
                move = -1f;
            }
            else
            {
                // Stay in last facing direction when idle
                if (lastDir == "up") sr.sprite = defaultSpriteWalkingUpRightFoot;
                if (lastDir == "down") sr.sprite = defaultSpriteWalkingDownRightFoot;
                if (lastDir == "left")
                {
                    sr.sprite = defaultSpriteWalkingLeftRightFoot;
                }
                if (lastDir == "right")
                {
                    sr.sprite = defaultSpriteWalkingRightRightFoot;
                }
            }

        float moveAmt = move * moveSpeed * Time.deltaTime;

        if (lastDir == "up" || lastDir == "down")
        {
            transform.Translate(0, moveAmt, 0);
        }
        else
        {
            transform.Translate(moveAmt, 0,  0);
        }
    }

    private System.Collections.IEnumerator Cooldown()
    {
        canSelectCharacter = false;
        yield return new WaitForSeconds(cooldownTime);
        canSelectCharacter = true;
    }

    public void AddExperience(float amount)
    {
        Experience += amount;
        expText.text = "EXP " + Experience.ToString();
        Debug.Log("XP is now: " + Experience);
    }
}
