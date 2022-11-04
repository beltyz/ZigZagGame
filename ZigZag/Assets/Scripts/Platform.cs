using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject particlePlatform;
    [SerializeField] GameObject diamond;

    // Start is called before the first frame update
    void Start()
    {
        
        int randNum = Random.Range(1,60);
        Vector3 tempPos = transform.position;
        tempPos.y += 0.5f;
        if (randNum==7)
        {
            Instantiate(diamond, tempPos, diamond.transform.rotation);

        }
    }

   

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            Invoke("FallDown",0.2f);
        }
       
    }
    public void FallDown()
    {
      
        Instantiate(particlePlatform,transform.position,Quaternion.identity);
        GetComponent<Rigidbody>().isKinematic = false;
        Destroy(gameObject,0.5f);


    }

}

