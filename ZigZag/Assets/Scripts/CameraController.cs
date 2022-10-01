using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 distance;
    [SerializeField] float followSpeed;

    [SerializeField]
    [Range(0f, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex=0;
    float change = 0f;
    int len;
    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
        len=myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y>=0)
        {
            Follow();
        }
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColors[colorIndex], lerpTime*Time.deltaTime);
        change = Mathf.Lerp(change, 1f, lerpTime * Time.deltaTime);
       
    }

    void Follow()
    {
        Vector3 currPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currPos, targetPos, followSpeed * Time.deltaTime);
    }
}
