using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dlivery : MonoBehaviour
{
    [SerializeField] float distroyDilay =0.5f ;
    [SerializeField] Color32 hascolor = new Color32(1,1,1,1);
    [SerializeField] Color32 notColor = new Color32(1,1,1,1);
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    

    void OnTriggerEnter2D(Collider2D other) 
    {
        
        if(other.tag == "Package" && !hasPackage){
            
            hasPackage = true;
            spriteRenderer.color = hascolor;
            Destroy(other.gameObject , distroyDilay);
        }    
        if(other.tag == "Dliver" && hasPackage){
            
            hasPackage = false;
            spriteRenderer.color= notColor;
            Destroy(other.gameObject,distroyDilay );
        }
        
            
        
    }
}
