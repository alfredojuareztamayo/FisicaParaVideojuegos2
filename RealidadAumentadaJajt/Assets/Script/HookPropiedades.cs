using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookPropiedades : MonoBehaviour
{
   
        public GameObject hook;
        public float masa;
        public float AguanteDelHook;
        public GameManager manager;
    public PropertyPescadito pescadito;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
        ItBreak();

        }
 

    public void ItBreak()
    {
        if (AguanteDelHook > pescadito.masa )
        {
            manager.IsAttach = true;
          
        }
        else
        {
            manager.IsAttach = false;
            Debug.Log("Muy pesado");
            Object.Destroy(hook);
        }
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag== "Pescadito")
    //    {
    //        if (AguanteDelHook > pescadito.masa)
    //        {
    //            manager.IsAttach = true;
    //            manager.speed *= -1;
    //        }
    //        else
    //        {
    //            manager.IsAttach = false;
    //            Debug.Log("Muy pesado");
    //            Object.Destroy(hook);
    //        }

    //    }
    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Pescadito")
    //    {
    //        if (AguanteDelHook > pescadito.masa)
    //        {
    //            manager.IsAttach = true;
    //            manager.speed *= -1;
    //        }
    //        else
    //        {
    //            manager.IsAttach = false;
    //            Debug.Log("Muy pesado");
    //            Object.Destroy(hook);
    //        }
    //    }
    //}

}

