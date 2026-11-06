using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class Summon : MonoBehaviour
{

    [SerializeField] public GameObject[] CandlePlacement;
    [SerializeField] public GameObject[] ZoneFlame;
    [SerializeField] public GameObject Chaudron;
    [SerializeField] public GameObject[] Demon;

    public Vector3[] scaleDemon;
    public int SelectDemon;

    public GameObject Summoning;

    public bool[] candleV;
    public bool[] fireV;

    bool Verif = false;
    bool AlreadySummon = false;

    public void CheckSumonning()
    {
        for (int i = 0; i < CandlePlacement.Length; i++)
        {
            if(CandlePlacement[i].GetComponent<CandlePlace>().isplace == true)
            {
                candleV[i] = true;
                Debug.Log("CandleV"+i + candleV[i]);
            }
        }

        for (int j = 0; j < ZoneFlame.Length; j++) 
        {

            if (ZoneFlame[j].GetComponent<CanldeDetect>().isflame == true)
            {
                fireV[j] = true;
                Debug.Log("FireV"+j + fireV[j]);
            }
        }

        for (int k = 0; k < ZoneFlame.Length; k++)
        {
            if (candleV[k] == true && fireV[k] == true)
            {
                Verif = true;
                Debug.Log("Summoning");
            }
            else
            {
                return;
            }
            
        }

        if(Verif == true)
        {
            if (!AlreadySummon && Chaudron.GetComponent<PotionUpdate>().PotionSuccess)
            {
                Instantiate(Summoning, gameObject.transform);
                Instantiate(Demon[SelectDemon], gameObject.transform).transform.localScale = scaleDemon[SelectDemon];
                Debug.Log("Summoning");
                AlreadySummon = true;
            }
            
        }


    }
}
