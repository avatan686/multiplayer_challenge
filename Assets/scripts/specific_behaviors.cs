using System.Collections;
using UnityEngine;

// Base class for all creatures
public abstract class Creature : MonoBehaviour
{
    protected virtual void Start()
    {
        // Initialize creature
    }

    protected abstract IEnumerator BehaviorCoroutine();
}

// A creature that moves in a random pattern and drops a trail
public class RandomWalker : Creature
{
    public GameObject trailPrefab;

    protected override IEnumerator BehaviorCoroutine()
    {
        while (true)
        {
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            transform.Translate(randomDirection * Time.deltaTime);

            Instantiate(trailPrefab, transform.position, Quaternion.identity);

            yield return new WaitForSeconds(1f);
        }
    }
}

// A creature that looks for others of its kind and swarms together
public class Swarmer : Creature
{
    public float detectionRadius = 5f;

    protected override IEnumerator BehaviorCoroutine()
    {
        while (true)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.GetComponent<Swarmer>())
                {
                    // Logic to move towards other swarmers
                }
            }

            yield return null;
        }
    }
}
