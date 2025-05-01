using System.Collections;
using UnityEngine;

public class PunchChecker : MonoBehaviour
{
    public PlayerStatus status;

    private EnemyChecker enemyChecker;

    private EnemyStatus enemyHp;

    private GameObject enemy;

    private Animator animator;

    void Awake()
    {
        enemyChecker = GetComponent<EnemyChecker>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        enemy = enemyChecker.GetEnemy();
        Debug.Log("Enemy: " + enemy.name + " Check.");
        enemyHp = enemy.GetComponent<EnemyStatus>();
    }

    void Update()
    {
        if (!enemy.activeInHierarchy)
        {
            Debug.Log("Enemy down!");
            enemy = enemyChecker.GetEnemy();
        }

        if (!status.isStun)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                animator.SetBool("isLPunch", true);
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                animator.SetBool("isRPunch", true);
            }
        }
    }

    private IEnumerator LPunch()
    {
        float damage = 1.0f;

        enemyHp.Hit(damage);
        Debug.Log("Jab!");

        yield return new WaitForSeconds(0.25f);

        animator.SetBool("isLPunch", false);
    }

    private IEnumerator RPunch()
    {
        float damage = 2.0f;

        enemyHp.Hit(damage);
        Debug.Log("Straigth");

        yield return new WaitForSeconds(0.25f);

        animator.SetBool("isRPunch", false);
    }
}
