using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class carController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject player;
    bool faceLeft, firstTab;

    // Update is called once per frame
    private void Start()
    {
        faceLeft = true;
    }
    void Update()
    {

        if (GameManager.instance.isGameStarted)
        {

            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        if (transform.position.y<=-2f)
        {

            GameManager.instance.GameOver();
        }
        
    }
  public  void CheckInpu()
  {
        ChangeDir();
  }

    void ChangeDir()
    {
        if (faceLeft)
        {
            faceLeft = false;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
