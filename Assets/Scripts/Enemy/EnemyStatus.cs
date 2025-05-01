using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStatus : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource def;

    public GameObject open;
    public GameObject close;
    public GameObject eye;
    public GameObject blood;
    public GameObject cheek;
    public GameObject nose;

    public PlayerStatus status;

    public bool isGuard;
    public bool isHit;

    [SerializeField]
    private float hp;

    private Animator animator;
    private RandomWeight random;

    void Awake()
    {
        random = new RandomWeight();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (hp <= 24) eye.SetActive(true);
        if (hp <= 18) blood.SetActive(true);
        if (hp <= 12) cheek.SetActive(true);
        if (hp <= 6) nose.SetActive(true);


        if (hp <= 0)
            SceneManager.LoadScene("ProTectEnd");
    }

    public void Hit(float damage)
    {
        if (!isGuard)
        {
            StartCoroutine(Damage(damage));
            hit.Play();
        }
        else
        {
            status.BlockedStun();
            def.Play();
        }
    }

    private IEnumerator Damage(float damage)
    {
        isHit = true;
        EyesBlink();
        hp -= damage;
        Debug.Log(gameObject.name + " is Hit. hp is " + hp);

        yield return new WaitForSeconds(0.5f);

        EyesBlink();

        isHit = false;
    }

    private void EyesBlink()
    {
        open.SetActive(!open.activeInHierarchy);
        close.SetActive(!close.activeInHierarchy);
    }
}
