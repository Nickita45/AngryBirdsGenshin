using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EntityClass : MonoBehaviour
{
    [SerializeField] public float stamine = 5.0f;
    private float current_stamine;
    [SerializeField] private Sprite damageStatus;
    [SerializeField] private bool isEnity = false;
    [SerializeField] private int countRating = 10;
    [SerializeField] private float sizeText = 1;
    [SerializeField] private Color colorText;
    public GameObject spawnNumbers;
    bool isDeath = false;
    // Start is called before the first frame update
    private void Start(){
        current_stamine = stamine;
        //colorText = spawnNumbers.GetComponent<TextMeshPro>().color;
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        //print(collision2D.relativeVelocity.magnitude);
        
        if(collision2D.gameObject.tag != gameObject.tag || gameObject.tag  == "Untagged")
            current_stamine = current_stamine - collision2D.relativeVelocity.magnitude;
        if(current_stamine <= 0)
        {
            if(!isDeath)
            StartCoroutine(killSelf());
        }
        else if(current_stamine <= stamine/2)
        {
            GetComponent<DestroyElementsSound>().playDestroySound();
            this.GetComponent<SpriteRenderer>().sprite = damageStatus;
        }
    }
    IEnumerator killSelf()
    {
        isDeath = true;
        GameObject gmj;
        gmj = Instantiate(spawnNumbers,transform.position,Quaternion.identity);
        gmj.GetComponent<TextMeshPro>().text = countRating.ToString();
        //gmj.GetComponent<TextMeshPro>().fontSize = gmj.GetComponent<TextMeshPro>().fontSize * sizeText;
        if(!isEnity)
        gmj.GetComponent<TextMeshPro>().color = colorText;
        print(gmj.GetComponent<Animation>().clip);
        gmj.GetComponent<Animation>()["Test_Display"].speed = 0.5f;
        gmj.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(0.5f);

        Destroy(gameObject);
        LevelManager.Instance.increaseRating(countRating,isEnity);
        if(gameObject.tag  != "Untagged")
        ShowElementsButton.Instance.changeActive(false);
    }
    public void setFreeze()
    {
        this.GetComponent<SpriteRenderer>().color = Color.cyan;
        current_stamine = 1f;
    }
}
