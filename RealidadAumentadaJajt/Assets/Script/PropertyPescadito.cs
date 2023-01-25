using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropertyPescadito : MonoBehaviour
{
    public GameObject Pescado;
    public float masa;
    public GameManager manager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "Hook")
    //    {
    //        if(manager.AguanteDelHook > masa)
    //        {
    //            manager.IsAttach = true;
    //            manager.speed *= -1;
    //        }
    //        else
    //        {
    //            manager.IsAttach = false;
    //            Debug.Log("Muy pesado");
    //            Object.Destroy(manager.gameObject1);
    //        }
    //    }
    //}
}
