using UnityEngine;

public class HealthCheker : MonoBehaviour
{
    public GameObject player;

    private PlayerStatus status;
    private SpriteRenderer health;
    private Color color;

    void Awake()
    {
        status = player.GetComponent<PlayerStatus>();
        health = GetComponent<SpriteRenderer>();
        color = health.color;
    }

    void Update()
    {
        color.a = 1f - (status.hp / 10);
        health.color = color;
    }
}
