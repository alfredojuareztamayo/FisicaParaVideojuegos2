using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RaycastCube : MonoBehaviour
{
    public float distanciaRay;
    public bool isHitting;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovRandom();
      
    }
    public void MovRandom()
    {

        RaycastHit hit;
        RaycastHit hit2;
        Ray rayray;
        Ray rayray2;
        rayray = new Ray(transform.position, Vector3.right);
        rayray2 = new Ray(transform.position, Vector3.left);
        Debug.DrawRay(rayray.origin,rayray.direction);
        Debug.DrawRay(rayray2.origin,rayray2.direction);
       
        //-5 en x position y 5 en x 
       
            if (Physics.Raycast(rayray, out hit, distanciaRay))
            {
                
                    Debug.Log("Golpee pared izq");
                    manager.speedRandom *= -1;
                   
                

            }
            else if (Physics.Raycast(rayray2, out hit2, distanciaRay))
            {
                    
                Debug.Log("Golpee pared derecha");
                manager.speedRandom *= -1;
            
            }



    }
    public void hitWallLeft()
    {
        isHitting = true;
        //gameObject2.transform.position = Formulas.Position(gameObject2, -speedRandom * Time.deltaTime, 0, 0);


    }
    public void hitWallRight()
    {
        isHitting = true;
        //gameObject2.transform.position = Formulas.Position(gameObject2, -speedRandom * Time.deltaTime, 0, 0);
       

    }
}
