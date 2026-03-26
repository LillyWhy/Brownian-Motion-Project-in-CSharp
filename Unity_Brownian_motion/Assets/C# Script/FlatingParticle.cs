using UnityEngine;

public class FleeingParticle : MonoBehaviour
{
    [Header("Ustawienia Ucieczki (Ważniejsze)")]
    public Transform pinkLeader;
    public float detectionRange = 5f; public float fleeSpeed = 30f;
    [Header("Ustawienia Dryfowania (Gdy bezpieczne)")]
    public float idleSpeed = 3f;
    public float changeInterval = 0.5f;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        PickNewDirection();
    }

    void Update()
    {
        if (pinkLeader == null)
        {
            Dryfuj();
            return;
        }

        float distance = Vector3.Distance(transform.position, pinkLeader.position);

        if (distance < detectionRange)
        {

            Vector3 fleeDirection = (transform.position - pinkLeader.position).normalized;

            fleeDirection.y = 0;

            transform.position += fleeDirection * fleeSpeed * Time.deltaTime;
        }
        else
        {
            Dryfuj();
        }
    }

    void Dryfuj()
    {
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            PickNewDirection();
            timer = 0;
        }

        transform.position += moveDirection * idleSpeed * Time.deltaTime;
    }

    void PickNewDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
    }
}