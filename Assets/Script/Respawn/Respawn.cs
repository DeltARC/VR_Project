using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 SpawnLocation;

    [Header("Portal")]
    [SerializeField] private GameObject portalPrefab;
    [SerializeField] private float portalHeight = 0f;
    [SerializeField] private float portalDuration = 2f;

    void Start()
    {
        SpawnLocation = transform.position;
        Debug.Log("Saved " + gameObject + " to " + SpawnLocation);
    }

    public void Respawning()
    {
        gameObject.transform.position = SpawnLocation;

        Vector3 portalPosition = SpawnLocation + Vector3.up * portalHeight;

        if (portalPrefab != null)
        {
            GameObject portal = Instantiate(
                portalPrefab,
                portalPosition,
                Quaternion.Euler(0f, 0f, 0f)
            );

            Destroy(portal, portalDuration);
        }

        Debug.Log("Respawn " + gameObject + " : " + gameObject.transform.position);
    }
}