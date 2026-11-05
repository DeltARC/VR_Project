using UnityEngine;

public class CanldeDetect : MonoBehaviour
{
    public GameObject Flame;

    bool isflame = false;

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

    }
}
