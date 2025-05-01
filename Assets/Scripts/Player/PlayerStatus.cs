using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource def;

    public SpriteRenderer lHands;
    public SpriteRenderer rHands;

    public bool isGuard;
    public bool isStun;
    public float hp;

    private float maxHealth = 10f;
    private float regenRate = 1f;
    private float regenCooltime = 10f;
    private float lastDamageTime;

    void Awake()
    {
        hp = maxHealth;
    }

    void Update()
    {
        if (hp <= 0)
        {
            SceneManager.LoadScene("VictimEnd");
        }

        if (hp < maxHealth && Time.time >= lastDamageTime + regenCooltime)
            Regenerate();
    }

    public void Hit(float damage)
    {
        if (!isGuard)
        {
            hp -= damage;
            hit.Play();
            lastDamageTime = Time.time;
            StartCoroutine(Stun(5));
        }
        else
            def.Play();
    }

    public void BlockedStun()
    {
        StartCoroutine(Stun(3));
    }

    private void Regenerate()
    {
        hp += regenRate * Time.deltaTime;
        hp = Mathf.Clamp(hp, 0f, maxHealth);
    }

    private IEnumerator Stun(float t)
    {
        isStun = true;
        lHands.color = Color.gray;
        rHands.color = Color.gray;

        yield return new WaitForSeconds(t);

        isStun = false;
        lHands.color = Color.white;
        rHands.color = Color.white;
    }
}
