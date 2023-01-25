using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   private float dist;

   [Header("Velocity of the hook andd the object")]
   public float speed = 2f;
   public float speedRandom = 5f;

   [Header("Hook and Object")]
   public GameObject gameObject1 ;
   public GameObject gameObject2 ;

   [Header("Variables para hacer atraer el object with the hook")]
   public GameObject gameObject3;
   public Transform gameObject4;
   public bool IsAttach = false;
   public float distanceToAttach;


   
   [SerializeField] private LayerMask layerMask;

   FisicalManager Formulas;
    void Start()
    {
        Formulas = new FisicalManager(); 
    }

    // Update is called once per frame
    void Update()
    {
        dist = Formulas.Distance(gameObject1, gameObject2);
        Debug.Log(dist);
        CrashHook();
        //gameObject2.transform.position = Formulas.Position(gameObject2, -speedRandom * Time.deltaTime, 0, 0);
        attachObject();
    }
    public void CrashHook()
    {
        RaycastHit hit;
        Ray ray;
        ray = new Ray(gameObject1.transform.position, Vector3.forward);
        Debug.DrawRay(ray.origin, ray.direction);
        if (!IsAttach)
        {
            gameObject1.transform.position = Formulas.Position(gameObject1, 0, 0, speed * Time.deltaTime);
            if (Physics.Raycast(ray, out hit, dist = 0.5f))
            {
                Debug.Log("Golpee pared izq");
                Debug.Log("Hit");
                IsAttach = true;
                speed *= -1;
            }

        }
        else
        {
         gameObject1.transform.position = Formulas.Position(gameObject1, 0, 0, speed * Time.deltaTime);
           
        }
        

        
       
    }
    
    public void attachObject()
    {
        if (IsAttach)
        {
            gameObject3.transform.SetParent(gameObject4);
            
        }
    }
   

}
