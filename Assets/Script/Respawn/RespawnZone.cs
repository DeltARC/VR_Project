using UnityEngine;
using UnityEngine.Rendering;

public class RespawnZone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Respawn RespawnObjet = other.GetComponent<Respawn>();
        Debug.Log("Touch " + other);

        if (RespawnObjet)
        {
            RespawnObjet.Respawning();
        }
    }
}
