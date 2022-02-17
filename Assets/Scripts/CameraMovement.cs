using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] SpriteRenderer mapRender;
    private Vector3 drag;
    private float mapMinX,mapMaxX,mapMinY,mapMaxY;
    private float heightCam;
    public bool isFollowObj = false;
    public bool isPressedOnBall = false;
    public GameObject objFollow;
    void Awake()
    {
        mapMinX = mapRender.transform.position.x - mapRender.bounds.size.x / 2f;
        mapMaxX = mapRender.transform.position.x + mapRender.bounds.size.x / 2f;

        mapMinY = mapRender.transform.position.y - mapRender.bounds.size.y / 2f;
        mapMaxY = mapRender.transform.position.y + mapRender.bounds.size.y / 2f;
        
        heightCam = cam.transform.position.y;
        
    }
    void Update()
    {
        PanCamera();
    }
    void PanCamera()
    {
        //cam.transform.position.y=heightCam;
        if(!isPressedOnBall)
        {
            if(Input.GetMouseButtonDown(0))
            {    
                drag = cam.ScreenToWorldPoint(Input.mousePosition);
                isFollowObj = false;
            }
            if(Input.GetMouseButton(0))
            {
                Vector3 difference = drag - cam.ScreenToWorldPoint(Input.mousePosition) ;
                cam.transform.position = ClampCamera(cam.transform.position + difference);
            }
            
        }
        //if(isFollowObj)
        //    StartCoroutine(FollowObjectCamera(objFollow));
    }
    private Vector3 ClampCamera(Vector3 targetPostion)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;
        
        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPostion.x,minX,maxX);
        float newY = Mathf.Clamp(targetPostion.y,minY,maxY);

        return new Vector3(newX,heightCam,targetPostion.z);
    }
    public IEnumerator FollowObjectCamera()
    {
        int koef = (int)(mapRender.transform.localScale.x * 30); 

        while (isFollowObj)
        {
            Vector3 oldPos = objFollow.transform.position;
            yield return new WaitForSeconds(0.001f);
            //print(positionObj);
            
            Vector3 differ = (objFollow.transform.position - oldPos) * Time.deltaTime * koef;
            cam.transform.position = ClampCamera(cam.transform.position  + differ);
            
        }
    }
}
