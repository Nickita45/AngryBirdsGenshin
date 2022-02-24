using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaoPushDown : MonoBehaviour
{
    private bool isUsedSpell = false; 
    [SerializeField] public Rigidbody2D rigidbody2DBullet;
    [SerializeField] public float initialVelocity = 1f;
    public GameObject particleFly,particleHitGround;
    bool isFly = false;
    void Start()
    {
        rigidbody2DBullet = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //print(this.GetComponent<BallShoot>().enabled);
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
                //rigidbody2DBullet.AddForce(new Vector2(0, -90) , ForceMode2D.Impulse);//.velocity = -transform.up * 10.0f;
                //transform.Translate(Vector3.down * Time.deltaTime * 10.0f, Space.World);
                rigidbody2DBullet.AddForce(new Vector2(0, -90) , ForceMode2D.Impulse);
                StartCoroutine(setMasToBack(rigidbody2DBullet.mass));
                StartCoroutine(spawnEffectFly());
                //rigidbody2DBullet.mass=50;
            }
        }

        
    }
    bool isGroundHit=false;
    IEnumerator spawnEffectFly()
    {
        while(isGroundHit == false)
        {
           
            yield return new WaitForSeconds(0.01f);
            GameObject ExploisionEffect = Instantiate(particleFly,transform.position,Quaternion.identity);
            Destroy(ExploisionEffect,2f);
        }
    }
    
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        if(isUsedSpell == true && isGroundHit == false)
        {
           
            GameObject ExploisionEffect = Instantiate(particleHitGround,transform.position,particleHitGround.transform.rotation);
            Destroy(ExploisionEffect,2f);
            isGroundHit = true;
        }
        if(this.GetComponent<BallShoot>().enabled == false)
        {
            isUsedSpell = true;
            isGroundHit = true;
        }
        //rigidbody2DBullet.mass=1;
    }
    IEnumerator setMasToBack(float value)
    {
        rigidbody2DBullet.mass=5;
        yield return new WaitForSeconds(0.3f);
        //gameObject.transform.GetChild(1).GetComponent<SummonerEfferct>().setChareckteristics(Random.Range(7, 10), 
        //    new Vector2(0, Random.Range(0.2f, 0.65f)), Random.Range(500, 1000),
        //    new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(0.3f, 0.6f)));
            
        rigidbody2DBullet.mass=value;
        
    }
}
