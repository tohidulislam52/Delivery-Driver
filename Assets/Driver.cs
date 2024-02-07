using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float rotate = 0.15f;
    [SerializeField] float movespeed = 0.013f;
    float speedup = 0;
    float speedDown= 0;
    float inpuy= 0;

    bool timee ;
    bool slowtimee ; 
    void Update()
    {
        float rotateAmaund = Input.GetAxis("Horizontal") * rotate * Time.deltaTime;
        float movespeedAmaund = Input.GetAxis("Vertical") * movespeed * Time.deltaTime; 
        transform.Rotate(0, 0, -rotateAmaund);
        transform.Translate(0, movespeedAmaund, 0);
        
        if(timee)
        {
            speedup += Time.deltaTime;
            if(speedup > 5)
            {
                movespeed -=10;
                timee = false;
                speedup = 1;
            }
        }
        if(slowtimee)
        {
            speedDown += Time.deltaTime;
            if(speedDown >5)
            {
                movespeed += 10;
                slowtimee = false;
                speedDown =1;
            }
        }
        if(Input.GetKey(KeyCode.P) && inpuy==0){
            Application.Quit();
            Debug.Log("Quit");
            inpuy = 1;
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "speedup" && !timee)
        {
            movespeed += 10;
            timee = true;
            
            
        }    

        if(other.tag == "slow" && !slowtimee)
        {
            movespeed -= 10;
            slowtimee = true;
        }
    }
}
