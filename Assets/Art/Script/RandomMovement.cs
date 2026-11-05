
using UnityEngine;
using UnityEngine.AI;

public class RandomRoam : MonoBehaviour
{
    [Header("Roaming Settings")]
    public float roamRadius = 10f;
    public float minWaitTime = 2f;
    public float maxWaitTime = 5f;

    [Header("Movement")]
    public NavMeshAgent agent;

    [Header("Animations")]
    public Animator animator;
    public string speedParameter = "Speed";

    private float waitTimer;
    private bool waiting;

    void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        if (animator == null)
            animator = GetComponentInChildren<Animator>();

        ChooseNewDestination();
    }

    void Update()
    {
        if (agent == null || !agent.isOnNavMesh)
            return;

        // Mise à jour de l'animation
        if (animator != null)
        {
            animator.SetFloat(
                speedParameter,
                agent.velocity.magnitude,
                0.1f,
                Time.deltaTime
            );
        }

        // Gestion de l'attente
        if (waiting)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0)
            {
                waiting = false;
                ChooseNewDestination();
            }

            return;
        }

        // Vérifie si le personnage est arrivé
        if (!agent.pathPending &&
            agent.remainingDistance <= agent.stoppingDistance)
        {
            waiting = true;
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    void ChooseNewDestination()
    {
        Vector3 randomDirection =
            Random.insideUnitSphere * roamRadius;

        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(
            randomDirection,
            out hit,
            roamRadius,
            NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
        }
    }
}
