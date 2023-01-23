using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public float speed = 2f;
    public float speedRandom = 5f;
   public GameObject gameObject1 ;
   public GameObject gameObject2 ;
    private float dist;

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
        MovRandom();
        
    }
    public void CrashHook()
    {
        if (dist > 1)
        {
            gameObject1.transform.position = Formulas.Position(gameObject1, 0, 0, speed * Time.deltaTime);
        }
        else if(dist <= 1)
        {
            Debug.Log("Hit");
            
        }
       
    }
    public void MovRandom()
    {
        //-5 en x position y 5 en x 
        if (gameObject2.transform.position.x < 5)
        {
            gameObject2.transform.position = Formulas.Position(gameObject2, -speedRandom * Time.deltaTime, 0, 0);
        }
        else if (gameObject2.transform.position.x > 5)
        {
            gameObject2.transform.position = Formulas.Position(gameObject2, speedRandom * Time.deltaTime, 0, 0);
        }
       
    }
}
