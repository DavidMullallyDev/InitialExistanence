using UnityEngine;
using UnityEngine.InputSystem;

public class Ogre : MonoBehaviour
{
    private SpriteRenderer sr;
    bool isNearOgre;
    private float cooldownTime = 0.1f;
    [SerializeField] Sprite deathSceneFrame1;
    [SerializeField] Sprite deathSceneFrame2;
    [SerializeField] Sprite deathSceneFrame3;
    [SerializeField] Sprite deathSceneFrame4;
    [SerializeField] Sprite deathSceneFrame5;
    [SerializeField] Sprite deathSceneFrame6;
    [SerializeField] Sprite deathSceneFrame7;
    [SerializeField] Sprite deathSceneFrame8;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isNearOgre && Keyboard.current.eKey.IsPressed())
        {
            StartCoroutine(DeathExplosion());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isNearOgre = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isNearOgre= false;
    }

    private System.Collections.IEnumerator DeathExplosion()
    {
        sr.sprite = deathSceneFrame1;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame2;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame3;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame4;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame5;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame6;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame7;
        yield return new WaitForSeconds(cooldownTime);
        sr.sprite = deathSceneFrame8;
        Protagonist protagonist = FindFirstObjectByType<Protagonist>();
        Destroy(gameObject);
        protagonist.AddExperience(100f);
    }
}
