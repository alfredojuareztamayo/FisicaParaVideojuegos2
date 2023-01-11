
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class QuaternionO : MonoBehaviour
{
    public GameObject ObjectWithQuaternion; //ObjectToRotateOrTraslate;
    float PositionX, PositionY, PositionZ;
    public double qx, qy, qz;
    public double angleQ;
    float[] QuaternionTemp;
    float[] QuaternionTempX;
    float[] QuaternionTempY;
    float[] QuaternionTempZ;
    float[] NewPositionTemp;


    public float timeToMove = 0.5f;
    float timingToMove = 0;

   

    void Start()
    {

        PositionX = ObjectWithQuaternion.transform.rotation.x;
        PositionY = ObjectWithQuaternion.transform.rotation.y;
        PositionZ = ObjectWithQuaternion.transform.rotation.z;





    }
    void Update()
    {




        timingToMove += Time.deltaTime;


        Debug.Log(timingToMove);
        if (timingToMove > timeToMove)
        {
            PositionX = ObjectWithQuaternion.transform.rotation.x;
            PositionY = ObjectWithQuaternion.transform.rotation.y;
            PositionZ = ObjectWithQuaternion.transform.rotation.z;
            CalcularQuartenion();
            timingToMove = 0;
    };

}

    float[] Quaternion(double qx, double qy, double qz, double angleQ)
    {
        angleQ *= 0.0174533;   //Pasar los grados a radianes 
        double magnitude; //variable para calcular la magnitud del vector dado 

        magnitude = Mathf.Sqrt((float)(qx * qx) + (float)(qy * qy) + (float)(qz * qz));

        // variable para calcular el cuarternion en su formula q= w +(vx,vy,vz)
        //calcular w
        double w = Mathf.Cos((float)(angleQ / 2));
        //calcular Vx
        double Vx = (qx / magnitude) * (Mathf.Sin((float)(angleQ / 2)));
        //calcular Vy
        double Vy = (qy / magnitude) * (Mathf.Sin((float)(angleQ / 2)));
        //calcular Vz
        double Vz = (qz / magnitude) * (Mathf.Sin((float)(angleQ / 2)));

        //Quaternion4 = {w,vx,vy,vz}
        float[] Quaternion4 = { (float)(w), (float)(Vx), (float)(Vy), (float)(Vz) };
        QuaternionTemp = Quaternion4;
        return Quaternion4;

    }

    // calcular la matriz de Quaternion 

    float[] QuaternionX(float[] Quaternion4)
    {
        // float[] Quaternion4 = { (float)(w), (float)(Vx), (float)(Vy), (float)(Vz) };
        //-------------------------------0-----------1------------2-----------3
        //Para Qx {1-(2*Vy*Vy)-(2*Vz*Vz), ((2*Vx*Vy)-(2*w*Vz)),((2*Vx*Vz)+(2*w*Vy))}
        float Qx1 = 1 - (2 * Quaternion4[2] * Quaternion4[2]) - (2 * Quaternion4[3] * Quaternion4[3]);
        float Qx2 = ((2 * Quaternion4[1] * Quaternion4[2]) - (2 * Quaternion4[0] * Quaternion4[3]));
        float Qx3 = ((2 * Quaternion4[1] * Quaternion4[3]) + (2 * Quaternion4[0] * Quaternion4[2]));

        float[] QuaternionXF = { Qx1, Qx2, Qx3 };
        QuaternionTempX = QuaternionXF;
        return QuaternionXF;
    }

    float[] QuaternionY(float[] Quaternion4)
    {
        // float[] Quaternion4 = { (float)(w), (float)(Vx), (float)(Vy), (float)(Vz) };
        //-------------------------------0-----------1------------2-----------3
        //Para Qy {(2*Vx*Vy)+(2*w*Vz), 1-(2*Vx*Vx)-(2*Vz*Vz), (2*Vy*Vz)-(2*w*Vx) }
        float Qy1 = (2 * Quaternion4[1] * Quaternion4[2]) + (2 * Quaternion4[0] * Quaternion4[3]);
        float Qy2 = 1 - (2 * Quaternion4[1] * Quaternion4[1]) - (2 * Quaternion4[3] * Quaternion4[3]);
        float Qy3 = (2 * Quaternion4[2] * Quaternion4[3]) - (2 * Quaternion4[0] * Quaternion4[1]);

        float[] QuaternionYF = { Qy1, Qy2, Qy3 };
        QuaternionTempY = QuaternionYF;
        return QuaternionYF;
    }

    float[] QuaternionZ(float[] Quaternion4)
    {
        // float[] Quaternion4 = { (float)(w), (float)(Vx), (float)(Vy), (float)(Vz) };
        //-------------------------------0-----------1------------2-----------3
        //Para Qz {(2*Vx*Vz)-(2*w*Vy),(2*Vy*Vz)+(2*w*Vx),1-(2*Vx*Vx)-(2*Vy*Vy)}
        float Qz1 = (2 * Quaternion4[1] * Quaternion4[3]) - (2 * Quaternion4[0] * Quaternion4[2]);
        float Qz2 = (2 * Quaternion4[2] * Quaternion4[3]) + (2 * Quaternion4[0] * Quaternion4[1]);
        float Qz3 = 1 - (2 * Quaternion4[1] * Quaternion4[1]) - (2 * Quaternion4[2] * Quaternion4[2]);

        float[] QuaternionZF = { Qz1, Qz2, Qz3 };
        QuaternionTempZ = QuaternionZF;
        return QuaternionZF;
    }

    float[] NewPositionWithQuaternion(float[] QuaternionXF, float[] QuaternionYF, float[] QuaternionZF)
    {
        float Px = (QuaternionXF[0] * (float)PositionX) + (QuaternionXF[1] * (float)PositionY) + (QuaternionXF[2] * (float)PositionZ);
        float Py = (QuaternionYF[0] * (float)PositionX) + (QuaternionYF[1] * (float)PositionY) + (QuaternionYF[2] * (float)PositionZ);
        float Pz = (QuaternionZF[0] * (float)PositionX) + (QuaternionZF[1] * (float)PositionY) + (QuaternionZF[2] * (float)PositionZ);
        float[] NewPositionQuart = { Px, Py, Pz };
        NewPositionTemp = NewPositionQuart;
        return NewPositionQuart;

    }

    public void CalcularQuartenion()
    {
        Quaternion(qx, qy, qz, angleQ);
        CalcularArrayQuaternion();
        //Debug.Log(QuaternionTemp[1]);
    }
    public void CalcularArrayQuaternion()
    {
        QuaternionX(QuaternionTemp);
        QuaternionY(QuaternionTemp);
        QuaternionZ(QuaternionTemp);
        //Debug.Log(QuaternionTempX[0]);
        //  Debug.Log(QuaternionTempY[0]);
        // Debug.Log(QuaternionTempZ[0]);
        newPositionQuater();
    }
    public void newPositionQuater()
    {
        NewPositionWithQuaternion(QuaternionTempX, QuaternionTempY, QuaternionTempZ);
        // Debug.Log(NewPositionTemp[0]+ " : " +  NewPositionTemp[1] + " : " +  NewPositionTemp[2]);
        PositionFinal();
    }
    public void PositionFinal()
    {
        ObjectWithQuaternion.transform.rotation = new Quaternion(NewPositionTemp[0], NewPositionTemp[1], NewPositionTemp[2], QuaternionTemp[0]);
        Debug.Log("Holi");
    }

}
