using UnityEngine;

public class CanldeDetect : MonoBehaviour
{
    public GameObject Flame;
    public GameObject Summoning;

    public bool isflame = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Torch torch = other.GetComponent<Torch>();

        if (!isflame)
        {
            if (torch)
            {
                Instantiate(Flame, gameObject.transform);
                isflame = true;
            }
        }

        Summoning.GetComponent<Summon>().CheckSumonning();

    }
}
