using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject Demon;
    public GameObject Summon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Instantiate(Demon, Summon.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
