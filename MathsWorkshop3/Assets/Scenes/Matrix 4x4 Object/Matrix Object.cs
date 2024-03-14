using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MatrixObject : MonoBehaviour
{
    GameObject Player;
    MyVector3 up = new MyVector3(0, 1, 0);
    Vector3[] ModelSpaceVertices;
    



    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<GameObject>();

        //Mesh filter stores the information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Get a copy pof all thje vertices (Not effeicent)
        ModelSpaceVertices = (MF.mesh.vertices);

    }

    // Update is called once per frame
    void Update()
    {
        MyVector3 F = new MyVector3(transform.position - Player.transform.position);

        MyVector3 R = MyVector3.CrossProduct(up, F);

        MyVector3 U = MyVector3.CrossProduct(F, R);

        //To-DO: Use R and U to re-calcuate position of vertices or anything for that matter

        //Define a new array witht the correct size
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        //Create our rotation matrix
        MyMatrix4x4 scaleMatrix = new MyMatrix4x4(new MyVector3(1, 0, 0), new MyVector3(0, 1, 0), new MyVector3(0, 0, 1), new MyVector3(0, 0, 0));
        MyMatrix4x4 rotationMatrix = new MyMatrix4x4(new MyVector3(1, 0, 0) , new MyVector3(0, 1, 0), new MyVector3(0, 0, 1), new MyVector3(0, 0, 0));
        MyMatrix4x4 translationMatrix = new MyMatrix4x4(new MyVector3(1, 0, 0), new MyVector3(0, 1, 0), new MyVector3(0, 0, 1), new MyVector3(0, 0, 0));

        //For each individual vertex
        for (int i = 0; i < ModelSpaceVertices.Length; i++)
        {
            TransformedVertices[i] = scaleMatrix * ModelSpaceVertices[i];
            TransformedVertices[i] = rotationMatrix * ModelSpaceVertices[i];
            TransformedVertices[i] = translationMatrix * ModelSpaceVertices[i];

        }
        //Stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //Assign our new vertices
         MF.mesh.vertices = TransformedVertices;

        // to make the mesh look correct
        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }

}
