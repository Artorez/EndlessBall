using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EndlessBall.Controllers;


namespace EndlessBall
{
    /// <summary>
    /// Точка входа в программу
    /// </summary>
    public sealed class Main : MonoBehaviour
    {
        private GameObject controllersGameObject;
        private InputController inputController;
        private BallController ballController;

        //Реализация паттерна Singleton
        public static Main Instance { get; private set; }

        private void Start()
        {
            Instance = this;
            controllersGameObject = new GameObject { name = "Controllers" };
            inputController = controllersGameObject.AddComponent<InputController>();
            ballController = controllersGameObject.AddComponent<BallController>();
        }

        /// <summary>
        /// Получение контроллера горячих клавиш
        /// </summary>
        /// <returns></returns>
        public InputController GetInputController()
        {
            return inputController;
        }

        /// <summary>
        /// Получение контроллера шарика
        /// </summary>
        /// <returns></returns>
        public BallController GetBallController
        {
            get { return ballController; }
        }

    }
}
