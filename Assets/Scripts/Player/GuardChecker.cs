using UnityEngine;

public class GuardChecker : MonoBehaviour
{
    private PlayerStatus status;

    private Animator animator;

    void Awake()
    {
        status = GetComponent<PlayerStatus>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            status.isGuard = true;
            animator.SetBool("isGuard", true);
            Debug.Log("Guard Up.");
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            status.isGuard = false;
            animator.SetBool("isGuard", false);
            Debug.Log("Guard Down");
        }
    }
}
