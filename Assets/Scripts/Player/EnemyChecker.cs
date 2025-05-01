using UnityEngine;

public class EnemyChecker : MonoBehaviour
{
    public GameObject[] enemies;

    private GameObject enemy;

    void Awake()
    {
        enemy = FindActiveEnemy();
    }

    void Update()
    {
        if (!enemy.activeInHierarchy)
        {
            enemy = FindActiveEnemy();
            Debug.Log("Next enemy is " + enemy.name);
        }

        if (enemy == null)
            Debug.Log("Enemies are all down. You Win!");
    }

    private GameObject FindActiveEnemy()
    {
        GameObject activeEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.activeInHierarchy)
            {
                activeEnemy = enemy;
                break;
            }
        }
        Debug.Log("Now, Enemy is " + activeEnemy.name);
        return activeEnemy;
    }

    public GameObject GetEnemy() { return enemy; }
}
