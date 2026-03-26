using UnityEngine;

public class BrownianMotion : MonoBehaviour
{
    public float speed = 25f;
    public float scale = 3.5f;

    void Update()
    {
        Vector3 randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f)
        );

        randomDirection.Normalize();

        transform.position += randomDirection * scale * speed * Time.deltaTime;
    }
}