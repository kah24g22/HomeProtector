using System.Collections;
using UnityEngine;

public class IntruderAttack : MonoBehaviour
{
    public PlayerStatus playerStatus;

    private RandomWeight random;
    private Animator animator;
    private EnemyStatus status;

    private int guardVal = 30;
    private int straightVal = 75;
    private int jabVal = 100;

    private bool isAction = false;

    void Awake()
    {
        random = new RandomWeight();
        animator = GetComponent<Animator>();
        status = GetComponent<EnemyStatus>();
    }

    void Update()
    {
        int val = random.GetValue();

        if (!isAction)
        {
            isAction = true;

            if (status.isHit) val += 40;

            if (val <= guardVal)
            {
                animator.SetBool("isGuard", true);
                status.isGuard = true;
            }
            else if (val <= straightVal)
            {
                animator.SetBool("isLPunch", true);
                Debug.Log("l punch start");
            }
            else if (val <= jabVal)
            {
                animator.SetBool("isRPunch", true);
                Debug.Log("R punch start");
            }
        }
    }

    private IEnumerator Jab()
    {
        Debug.Log("jab is run");
        float damage = 1f;

        isAction = true;

        playerStatus.Hit(damage);

        yield return new WaitForSeconds(1);
        animator.SetBool("isLPunch", false);
        animator.SetBool("isRPunch", false);

        isAction = false;
        Debug.Log("L punch done");
    }

    private IEnumerator Guard()
    {
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        animator.SetBool("isGuard", false);
        status.isGuard = false;

        isAction = false;
    }

    private IEnumerator Idle()
    {
        float cooltime = 1.0f;

        isAction = true;
        Debug.Log("Stay");
        yield return new WaitForSeconds(cooltime);

        isAction = false;
    }
}
