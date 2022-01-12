using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaticAnimation : MonoBehaviour
{
    public Sprite[] stayAnim;
    public Sprite staticSprite;
    public float timeDelta = 3f;
    void Start()
    {
        timeDelta = Random.Range(2f,6f);
    }
    void Update()
    {
        if(timeDelta > 0)
        {
            timeDelta -= Time.deltaTime;
        }
        else
        {
            timeDelta = Random.Range(4f,6f);
            StartCoroutine(playAnim());
            //timeDelta = Random.Range(0f,3f);
        }
        
    }
    IEnumerator playAnim()
    {
        //int current = 0;
        for(int i=0;i<stayAnim.Length;i++)
        {
            this.GetComponent<SpriteRenderer>().sprite = stayAnim[i];
            yield return new WaitForSeconds(0.5f);
        }
        
        this.GetComponent<SpriteRenderer>().sprite = staticSprite;
    }
}
