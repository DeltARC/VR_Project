using UnityEngine;
using UnityEngine.UIElements;

public class Respawn : MonoBehaviour
{
    private Vector3 SpawnLocation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnLocation = gameObject.transform.position;
        
        Debug.Log("Saved "+ gameObject+ " to "+ SpawnLocation);
    }

    public void Respawning()
    {
        gameObject.transform.position = SpawnLocation;
        Debug.Log("Respawn"+ gameObject+" : "+ gameObject.transform.position+" to " + SpawnLocation);
    }
}
