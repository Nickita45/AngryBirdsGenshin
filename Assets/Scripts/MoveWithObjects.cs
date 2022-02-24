using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithObjects : MonoBehaviour
{
    Transform startPosition;
    public Transform followObject;
    Vector3 delta;
    void Awake()
    {
        startPosition = transform;
    }
    public void setFollowObject(Transform trans)
    {
        
        followObject = trans;
        delta = startPosition.position - trans.position;   
    }
    // Update is called once per frame
    void Update()
    {
        if(followObject == null)
        {
            Destroy(this.gameObject);
        }
        else if(delta != transform.position - followObject.position )
        {
            transform.position = followObject.position+ delta;
        }
    }
}
