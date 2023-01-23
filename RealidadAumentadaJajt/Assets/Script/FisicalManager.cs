using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FisicalManager 
{
  
    public float Distance(GameObject pos1, GameObject pos2)
    {
       float distancia;
       float X = (pos2.transform.position.x - pos1.transform.position.x);
       float Y = (pos2.transform.position.y - pos1.transform.position.y);
       float Z = (pos2.transform.position.z - pos1.transform.position.z);

       float XX = Mathf.Pow(X, 2f);
       float YY = Mathf.Pow(Y, 2f);
       float ZZ = Mathf.Pow(Z, 2f);
       distancia = Mathf.Sqrt(XX + YY + ZZ);

        return distancia;
    }

    public float Magnitud(Vector3 pos)
    {
        float xCuadrada = pos.x * pos.x;
        float yCuadrada = pos.y * pos.y;
        float zCuadrada = pos.z * pos.z;

        float mag = Mathf.Sqrt(xCuadrada+ yCuadrada + zCuadrada);

        return mag;
    }

    public Vector3 Position(GameObject pos1, float x1, float y1, float z1)
    {
        // pos1 es la posicion original 
        // , float x1 posicion a mover en x, float y1 posicion a mover en y, float z1
        
        float X = pos1.transform.position.x + x1;
        float Y = pos1.transform.position.y + y1;
        float Z = pos1.transform.position.z + z1;
        Vector3 newPosition = new Vector3(X, Y, Z);
       // pos1.transform.position = newPosition;
       // pos1.transform.Translate = newPosition;
        return newPosition;
    }


}
