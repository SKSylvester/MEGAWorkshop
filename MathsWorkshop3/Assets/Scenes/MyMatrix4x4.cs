using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMatrix4x4
{
    public float[,] values; //Mulidiemensional array of floats that store the matrix vlaue.

    //Matrix Columns
    public MyMatrix4x4(Vector4 Column1, Vector4 Column2, Vector4 Column3, Vector4 Column4)
    {
        values = new float[4, 4];

        // Column1
        values[0, 0] = Column1.x;
        values[1, 0] = Column1.y;
        values[2, 0] = Column1.z;
        values[3, 0] = Column1.w;

        // Column2 
        values[0, 1] = Column2.x;
        values[1, 1] = Column2.y;
        values[2, 1] = Column2.z;
        values[3, 1] = Column2.w;

        //column3 
        values[0, 2] = Column3.x;
        values[1, 2] = Column3.y;
        values[2, 2] = Column3.z;
        values[3, 2] = Column3.w;

        //column4
        values[0, 3] = Column4.x;
        values[1, 3] = Column4.y;
        values[2, 3] = Column4.z;
        values[3, 3] = Column4.w;
    }
    public MyMatrix4x4(MyVector3 Column1, MyVector3 Column2, MyVector3 Column3, MyVector3 Column4)
    {
        values = new float[4, 4];

        // Column1
        values[0, 0] = Column1.x;
        values[1, 0] = Column1.y;
        values[2, 0] = Column1.z;
        values[3, 0] = 0;

        // Column2 
        values[0, 1] = Column2.x;
        values[1, 1] = Column2.y;
        values[2, 1] = Column2.z;
        values[3, 1] = 0;

        //column3 
        values[0, 2] = Column3.x;
        values[1, 2] = Column3.y;
        values[2, 2] = Column3.z;
        values[3, 2] = 0;

        //column4
        values[0, 3] = Column4.x;
        values[1, 3] = Column4.y;
        values[2, 3] = Column4.z;
        values[3, 3] = 0;
    }

    public static Vector4 operator *(MyMatrix4x4 lhs, Vector4 rhs) //Matrix multiplication 
    {
        Vector4 rv = new Vector4();

        rv.x = lhs.values[0, 0] * rhs.x + lhs.values[0, 1] * rhs.y + lhs.values[0, 2] * rhs.z + lhs.values[0, 3] * rhs.w;
        rv.y = lhs.values[1, 0] * rhs.x + lhs.values[1, 1] * rhs.y + lhs.values[1, 2] * rhs.z + lhs.values[1, 3] * rhs.w;
        rv.z = lhs.values[2, 0] * rhs.x + lhs.values[2, 1] * rhs.y + lhs.values[2, 2] * rhs.z + lhs.values[2, 3] * rhs.w;
        rv.w = lhs.values[3, 0] * rhs.x + lhs.values[3, 1] * rhs.y + lhs.values[3, 2] * rhs.z + lhs.values[3, 3] * rhs.w;

        return rv;
    }

}
