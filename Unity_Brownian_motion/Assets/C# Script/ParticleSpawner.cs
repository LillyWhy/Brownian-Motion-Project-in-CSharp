using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{

    public GameObject particlePrefab;
    public int numberOfParticles = 8500;
    public float areaSize = 25f;

    void Start()
    {
        GameObject pinkBall = GameObject.Find("Sphere");

        if (pinkBall == null)
        {
            Debug.LogError("BŁĄD: Nie znalazłem obiektu o nazwie 'Sphere' na scenie!");
            return;
        }


        for (int i = 0; i < numberOfParticles; i++)
        {
            Vector2 randomPoint = Random.insideUnitCircle * areaSize;
            Vector3 spawnPos = new Vector3(randomPoint.x, 0, randomPoint.y);

            GameObject newParticle = Instantiate(particlePrefab, spawnPos, Quaternion.identity);

            FleeingParticle fleeingScript = newParticle.GetComponent<FleeingParticle>();

            if (fleeingScript != null)
            {
                fleeingScript.pinkLeader = pinkBall.transform;
            }

            float randomScale = Random.Range(0.02f, 0.08f);
            newParticle.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}