using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XiaoPushDown : MonoBehaviour
{
    private bool isUsedSpell = false; 
    [SerializeField] public Rigidbody2D rigidbody2DBullet;
    [SerializeField] public float initialVelocity = 1f;
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
                print("AAAA");
                isUsedSpell = true;
                rigidbody2DBullet.AddForce(new Vector2(0, -45), ForceMode2D.Impulse);
                StartCoroutine(setMasToBack(rigidbody2DBullet.mass));
                //rigidbody2DBullet.mass=50;
            }
        }
    }
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        
        isUsedSpell = true;
        //rigidbody2DBullet.mass=1;
    }
    IEnumerator setMasToBack(float value)
    {
        rigidbody2DBullet.mass=50;
        yield return new WaitForSeconds(0.3f);
        rigidbody2DBullet.mass=value;
    }
}
