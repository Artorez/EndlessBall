using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace EndlessBall.Controllers
{
    /// <summary>
    /// Класс отвечающий за горячие клавиши
    /// </summary>
    public sealed class InputController : BaseController
    {        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Main.Instance.GetBallController.SetUp();
            }
        }
    }
}
