using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public float filedofImpact;
    public float force;
    public LayerMask LayerToHit;
    public GameObject ExploisionEffectPrefab;

    void Explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, filedofImpact, LayerToHit);
        foreach(Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject ExploisionEffect = Instantiate(ExploisionEffectPrefab,transform.position,Quaternion.identity);
        Destroy(ExploisionEffect,2f);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,filedofImpact);
    }
    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        float current_stamine = GetComponent<EntityClass>().stamine;
        current_stamine = current_stamine - collision2D.relativeVelocity.magnitude;
        
        if(current_stamine <= 0)
        {
            Explode();
        }
    }
}
