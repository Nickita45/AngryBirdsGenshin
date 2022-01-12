using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonerEfferct : MonoBehaviour
{
    public Sprite[] spritesToSumoEffect;
    public GameObject shablonToSummon;

    

    public void setChareckteristics(int countSummon, Vector2 vectorMoveTo, int speedDisable, Vector2 startposition)
    {
        for (int i = 0; i < countSummon; i ++)
        {
            GameObject objSummoned = Instantiate(shablonToSummon, gameObject.transform.position, Quaternion.identity);
            objSummoned.transform.localPosition += (Vector3)startposition;
            objSummoned.GetComponent<ObjectEffetct>().setStats(spritesToSumoEffect[Random.Range(0, spritesToSumoEffect.Length)], speedDisable, vectorMoveTo);
            
        }
    }
}
