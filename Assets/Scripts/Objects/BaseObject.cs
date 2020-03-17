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
        protected GameObject instanceObject;
        protected Rigidbody myRigidbody;
        protected Transform myTransform;
        protected Material material;

        protected string myName;
        protected int layer;
        protected Color color;
                
        protected Vector3 position;
        protected Vector3 scale;
        protected Quaternion rotation;
                       
        protected bool isVisible;

        #region Property

        /// <summary>
        /// Ссылка на объект (gameObject)
        /// </summary>
        public GameObject InstanceObject
        {
            get { return instanceObject; }
        }

        /// <summary>
        /// Физическое свойство объекта
        /// </summary>
        public Rigidbody GetRigidbody
        {
            get { return myRigidbody; }
        }

        /// <summary>
        /// Transform объекта
        /// </summary>
        public Transform GetTransform
        {
            get { return myTransform; }
        }

        /// <summary>
        /// Материал объекта
        /// </summary>
        public Material GetMaterial
        {
            get { return material; }
        }

        /// <summary>
        /// Имя объекта
        /// </summary>
        public string Name
        {
            get { return myName; }
            set
            {
                myName = value;
                instanceObject.name = myName;
            }
        }

        /// <summary>
        /// Слой объекта
        /// </summary>
        public int Layers
        {
            get { return layer; }
            set
            {
                layer = value;
                if(InstanceObject != null)
                {
                    instanceObject.layer = layer;
                    AskLayer(GetTransform, layer);
                }
            }
        }

        /// <summary>
        /// Цвет объекта
        /// </summary>
        public Color Color
        {
            get { return color; }
            set
            {
                color = value;
                if(material != null)
                {
                    material.color = color;
                    AskColor(GetTransform, color);
                }
                if (InstanceObject != null)
                {
                    AskColor(GetTransform, color);
                }
            }
        }

        /// <summary>
        /// Позиция объекта
        /// </summary>
        public Vector3 Position
        {
            get
            {
                if(InstanceObject != null)
                {
                    position = GetTransform.position;
                }
                return position;
            }
            set
            {
                position = value;
                if(InstanceObject != null)
                {
                    GetTransform.position = position;
                }
            }
        }

        /// <summary>
        /// Размер объекта
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                if(InstanceObject != null)
                {
                    scale = GetTransform.localScale;
                }
                return scale;
            }
            set
            {
                scale = value;
                if(InstanceObject != null)
                {
                    GetTransform.localScale = scale;
                }
            }
        }

        /// <summary>
        /// Поворот объекта
        /// </summary>
        public Quaternion Rotation
        {
            get
            {
                if(InstanceObject != null)
                {
                    rotation = GetTransform.rotation;
                }
                return rotation;
            }
            set
            {
                rotation = value;
                if(InstanceObject != null)
                {
                    GetTransform.rotation = rotation;
                }
            }
        }

        /// <summary>
        /// Скрыть/показать объект
        /// </summary>
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                if (instanceObject.GetComponent<MeshRenderer>())
                {
                    instanceObject.GetComponent<MeshRenderer>().enabled = isVisible;
                }
                    
                if (instanceObject.GetComponent<SkinnedMeshRenderer>())
                {
                    instanceObject.GetComponent<SkinnedMeshRenderer>().enabled = isVisible;
                }                    
            }
        }
        #endregion

        #region PrivateFunction
        /// <summary>
        /// Установка слоя
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="lvl">Слой</param>
        private void AskLayer(Transform obj, int lvl)
        {
            obj.gameObject.layer = lvl;
            if (obj.childCount > 0)
            {
                foreach (Transform el in obj)
                {
                    AskLayer(el, lvl);
                }
            }
        }

        /// <summary>
        /// Установка цвета
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <param name="color">Цвет</param>
        private void AskColor(Transform obj, Color color)
        {
            if(material != null)
            {
                material.color = color;
            }

            if (obj.childCount > 0)
            {
                foreach (Transform el in obj)
                {
                    AskColor(el, color);
                }
            }
        }
        #endregion

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
