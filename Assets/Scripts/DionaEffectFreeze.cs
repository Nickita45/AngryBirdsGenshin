using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DionaEffectFreeze : MonoBehaviour
{
    // Start is called before the first frame update
    bool isFly = false;
    private bool isUsedSpell = false; 
    public float range = 2.0f;
    public GameObject FreezeEffectPrefab;

    // Update is called once per frame
    void Update()
    {
        if(this.GetComponent<BallShoot>().enabled == false && isFly == false)
        {
            isFly = true;
            isUsedSpell = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if(this.GetComponent<BallShoot>().enabled == false && isUsedSpell == false)
            {
                isUsedSpell = true;
                Search();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        isUsedSpell = true;

        //rigidbody2DBullet.mass=1;
    }
    void Search()
    {

        Collider2D[] targetInViewRadius = Physics2D.OverlapCircleAll(transform.position, range);
        foreach (var item in targetInViewRadius)
        {
            if(item.gameObject.layer == 6) // building
            {
            
                item.gameObject.GetComponent<EntityClass>().setFreeze();

                GameObject ExploisionEffect = Instantiate(FreezeEffectPrefab,transform.position,Quaternion.identity);
                Destroy(ExploisionEffect,2f);
                //this.GetComponent<BallShoot>().nextBirdOrFinish();
                this.GetComponent<MusicBalls>().playSpecialAttackSound();
                this.GetComponent<SpriteRenderer>().enabled = false;
                this.GetComponent<CircleCollider2D>().enabled = false;
                //ShowElementsButton.Instance.elements.Remove(this.gameObject);
                ShowElementsButton.Instance.changeActive(false);
                //Destroy(gameObject);
            }
        }
    }   
}
