using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector3 distance;
    [SerializeField] float followSpeed;
    // Start is called before the first frame update
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y>=0)
        {
            Follow();
        }
       
    }

    void Follow()
    {
        Vector3 currPos = transform.position;
        Vector3 targetPos = target.position - distance;

        transform.position = Vector3.Lerp(currPos, targetPos, followSpeed * Time.deltaTime);
    }
}
