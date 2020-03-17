using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EndlessBall.Controllers
{
    /// <summary>
    /// Контроллер отвечающий за поведение шарика
    /// </summary>
    public sealed class BallController : BaseController
    {
        private Ball ball;

        private void Awake()
        {
            ball = GameObject.FindGameObjectWithTag("Hero").GetComponent<Ball>();
        }

        private void Start()
        {

        }


        private void Update()
        {

        }

        public void SetUp()
        {
            ball.Position = new Vector3(10f, 10f, 10f);
        }
    }
}
