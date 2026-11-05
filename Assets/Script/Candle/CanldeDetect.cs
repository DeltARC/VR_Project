using UnityEngine;

public class CanldeDetect : MonoBehaviour
{
    public GameObject Flame;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Torch torch= other.GetComponent<Torch>();

        if(torch)
        {
            Spawnflame();
        }
    }

    void Spawnflame()
    {
        Instantiate(Flame,gameObject.transform);
    }
}
