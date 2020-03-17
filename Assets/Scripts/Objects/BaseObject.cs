using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EndlessBall
{
    /// <summary>
    /// Базовый класс всех объектов
    /// </summary>
    public abstract class BaseObject : MonoBehaviour
    {
        protected int layer;
        protected Color color;
        protected Material material;
        protected Transform myTransform;
        protected Vector3 position;
        protected Quaternion rotation;
        protected Vector3 scale;
        protected GameObject instanceObject;
        protected Rigidbody myRigidbody;
        protected string myName;
        protected bool isVisible;


        protected virtual void Awake()
        {
            instanceObject = gameObject;
            myName = instanceObject.name;

            if (GetComponent<Renderer>())
            {
                material = GetComponent<Renderer>().material;
            }
            myRigidbody = instanceObject.GetComponent<Rigidbody>();
            myTransform = instanceObject.GetComponent<Transform>();
        }
    }

}
