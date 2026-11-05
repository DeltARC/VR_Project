using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CandlePlace : MonoBehaviour
{
    public GameObject CandlePlacement;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        Candle candle = other.GetComponent<Candle>();

        
        if (candle)
        {
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.GetComponent<XRGrabInteractable>().enabled = false;
            other.transform.position = CandlePlacement.transform.position;
            other.transform.rotation = CandlePlacement.transform.rotation;
            Debug.Log("ok");
        }
    }

}
