using UnityEngine;

public class Test : MonoBehaviour
{

    public GameObject Demon;
    public GameObject Summon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var demon = Instantiate(Demon, gameObject.GetComponent<Transform>().position, gameObject.GetComponent<Transform>().rotation);

        demon.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
