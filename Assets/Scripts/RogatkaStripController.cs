using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RogatkaStripController : MonoBehaviour
{
    public LineRenderer[] lineRenderers;
    public Transform[] stripPositions; //??
    public Transform IdlePosition;
    // Start is called before the first frame update
    void Start()
    {
        lineRenderers[0].positionCount = 2;
        lineRenderers[1].positionCount = 2;
        lineRenderers[0].SetPosition(0,stripPositions[0].position);
        lineRenderers[1].SetPosition(0,stripPositions[1].position);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetStrips()
    {
        setStrips(IdlePosition.position);
    }
    public void setStrips(Vector3 pos)
    {
        lineRenderers[0].SetPosition(1,pos);
        lineRenderers[1].SetPosition(1,pos);
    }
}
