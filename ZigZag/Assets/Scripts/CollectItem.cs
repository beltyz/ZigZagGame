using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public GameObject  diamondBlast;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            
            if (gameObject.tag == "Diamond")
            {
                GameManager.instance.GetDiamond();
            }
            Destroy(gameObject); 
        }
    }
}
