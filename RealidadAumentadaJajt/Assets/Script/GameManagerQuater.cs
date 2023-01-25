using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerQuater : MonoBehaviour
{
    FisicalManager FisicalManager;
    public GameObject gameObject1;
    public float angle = 30f;
    public float speedToRotate = 5f;
    // Start is called before the first frame update
    void Start()
    {
        FisicalManager = new FisicalManager();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 rotarx = FisicalManager.RotateX(gameObject1, angle);
        gameObject1.transform.position = (rotarx*speedToRotate*Time.deltaTime);
      //  gameObject1.transform.Rotate(rotarx*speedToRotate*Time.fixedDeltaTime);
        
    }
}
