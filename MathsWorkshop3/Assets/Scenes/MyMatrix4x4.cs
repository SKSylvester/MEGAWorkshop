using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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


    public static MyMatrix4x4 Identity
    {
        get
        {
            return new MyMatrix4x4(
        new Vector4(1, 0, 0, 0),
        new Vector4(0, 1, 0, 0),
        new Vector4(0, 0, 1, 0),
        new Vector4(0, 0, 0, 1));
        }
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

    public static MyMatrix4x4 operator *(MyMatrix4x4 lhs, MyMatrix4x4 rhs)
    {
        MyMatrix4x4 rv = Identity;

        rv.values[0, 0] = lhs.values[0, 0] * rhs.values[0,0] + lhs.values[0, 1] * rhs.values[1, 0] + lhs.values[0, 2] * rhs.values[2, 0] + lhs.values[0, 3] * rhs.values[3, 0];
        rv.values[1, 0] = lhs.values[1, 0] * rhs.values[0, 0] + lhs.values[1, 1] * rhs.values[1, 0] + lhs.values[1, 2] * rhs.values[2, 0] + lhs.values[1, 3] * rhs.values[3, 0];
        rv.values[2, 0]= lhs.values[2, 0] * rhs.values[0,0] + lhs.values[2, 1] * rhs.values[1, 0] + lhs.values[2, 2] * rhs.values[2, 0] + lhs.values[2, 3] * rhs.values[3, 0];
        rv.values[3, 0] = lhs.values[3, 0] * rhs.values[0, 0] + lhs.values[3, 1] * rhs.values[1, 0] + lhs.values[3, 2] * rhs.values[2, 0] + lhs.values[3, 3] * rhs.values[3, 0];
        rv.values[4, 0] = lhs.values[4, 0] * rhs.values[0, 0] + lhs.values[4, 1] * rhs.values[1, 0] + lhs.values[4, 2] * rhs.values[2, 0] + lhs.values[4, 3] * rhs.values[3, 0];
        rv.values[5, 0] = lhs.values[5, 0] * rhs.values[0, 0] + lhs.values[5, 1] * rhs.values[1, 0] + lhs.values[5, 2] * rhs.values[2, 0] + lhs.values[5, 3] * rhs.values[3, 0];
        rv.values[6, 0] = lhs.values[6, 0] * rhs.values[0, 0] + lhs.values[6, 1] * rhs.values[1, 0] + lhs.values[6, 2] * rhs.values[2, 0] + lhs.values[6, 3] * rhs.values[3, 0];
        rv.values[7, 0] = lhs.values[7, 0] * rhs.values[0, 0] + lhs.values[7, 1] * rhs.values[1, 0] + lhs.values[7, 2] * rhs.values[2, 0] + lhs.values[7, 3] * rhs.values[3, 0];
        rv.values[8, 0] = lhs.values[8, 0] * rhs.values[0, 0] + lhs.values[8, 1] * rhs.values[1, 0] + lhs.values[8, 2] * rhs.values[2, 0] + lhs.values[8, 3] * rhs.values[3, 0];
        rv.values[9, 0] = lhs.values[9, 0] * rhs.values[0, 0] + lhs.values[9, 1] * rhs.values[1, 0] + lhs.values[9, 2] * rhs.values[2, 0] + lhs.values[9, 3] * rhs.values[3, 0];
        rv.values[10, 0] = lhs.values[10, 0] * rhs.values[0, 0] + lhs.values[10, 1] * rhs.values[1, 0] + lhs.values[10, 2] * rhs.values[2, 0] + lhs.values[10, 3] * rhs.values[3, 0];
        rv.values[11, 0] = lhs.values[11, 0] * rhs.values[0, 0] + lhs.values[11, 1] * rhs.values[1, 0] + lhs.values[11, 2] * rhs.values[2, 0] + lhs.values[11, 3] * rhs.values[3, 0];
        rv.values[12, 0] = lhs.values[12, 0] * rhs.values[0, 0] + lhs.values[12, 1] * rhs.values[1, 0] + lhs.values[12, 2] * rhs.values[2, 0] + lhs.values[12, 3] * rhs.values[3, 0];
        rv.values[13, 0] = lhs.values[13, 0] * rhs.values[0, 0] + lhs.values[13, 1] * rhs.values[1, 0] + lhs.values[13, 2] * rhs.values[2, 0] + lhs.values[13, 3] * rhs.values[3, 0];
        rv.values[14, 0] = lhs.values[14, 0] * rhs.values[0, 0] + lhs.values[14, 1] * rhs.values[1, 0] + lhs.values[14, 2] * rhs.values[2, 0] + lhs.values[14, 3] * rhs.values[3, 0];
        rv.values[15, 0] = lhs.values[15, 0] * rhs.values[0, 0] + lhs.values[15, 1] * rhs.values[1, 0] + lhs.values[15, 2] * rhs.values[2, 0] + lhs.values[15, 3] * rhs.values[3, 0];

        return rv;

    }

        
}
