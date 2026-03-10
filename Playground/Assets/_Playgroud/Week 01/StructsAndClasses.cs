using System;
using UnityEngine;

public class StructsAndClasses : MonoBehaviour
{ 
    private MyClass m_Class;
    Vector3 m_Position;

    private void Start()
    {
        MyStruct myStruct = new MyStruct();
        m_Class.myFloat = 10.0f;
        m_Class.MyFunction();
    }

    [Serializable]
    public struct MyStruct
    {
        public float x;
        public float y;
        public float z;

        public MyStruct(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}

public class MyClass
{
    public float myFloat;
    private GameObject myGameObject;

    public void MyFunction()
    {
        Debug.Log("My function is");
    }
}