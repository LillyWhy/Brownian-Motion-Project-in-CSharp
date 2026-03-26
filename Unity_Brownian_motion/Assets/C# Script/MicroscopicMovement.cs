using UnityEngine;

public class MicroscopicMovement : MonoBehaviour
{
    [Header("Ustawienia Ruchu")]
    public float speed = 8f;
    public float jitter = 15f;
    public float changeInterval = 0.1f;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            PickNewDirection();
            timer = 0;
        }

        transform.position += moveDirection * speed * Time.deltaTime;

        Vector3 randomJitter = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        ) * jitter * Time.deltaTime;

        transform.position += randomJitter;
    }

    void PickNewDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
}