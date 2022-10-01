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
            
            transform.position += transform.forward*moveSpeed*Time.deltaTime;
            //Rotate();
            CheckInput();
        }
        if (transform.position.y<=0.4f)
        {
            GameManager.instance.GameOver();
        }
        
    }

    private void Rotate()
    {
        Vector3 rot = player.transform.rotation.eulerAngles;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (rot.y == 0f)
            {
                rot.y = 90f;
                player.transform.rotation = Quaternion.Euler(rot);
                return;
            }
            if (rot.y == 90f)
            {
                rot.y = 0f;
                player.transform.rotation = Quaternion.Euler(rot);
                return;
            }

        }
    }
    void CheckInput()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ChangeDir();
        }
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
