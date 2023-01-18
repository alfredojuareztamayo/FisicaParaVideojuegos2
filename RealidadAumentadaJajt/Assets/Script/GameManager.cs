using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public GameObject gameObject1 ;
   public GameObject gameObject2 ;

   FisicalManager Formulas;
    void Start()
    {
        Formulas = new FisicalManager(); 
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Formulas.Distance(gameObject1, gameObject2);
        Debug.Log(dist);
    }
}
