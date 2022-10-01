using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject starBlast, diamondBlast;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            if (gameObject.tag=="Star")
            {
                GameManager.instance.GetStar();
            }
            if (gameObject.tag == "Diamond")
            {
                GameManager.instance.GetDiamond();
            }
            Destroy(gameObject); 
        }
    }
}
