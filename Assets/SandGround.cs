using System;
using System.Collections;
using System.Collections.Generic;
using F4B1.Core;
using UnityEngine;

namespace F4B1
{
    public class SandGround : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (!col.CompareTag("BallTrigger")) return;
            
            col.GetComponentInParent<BallController>().SandGroundChanged(true);
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            if (!col.CompareTag("BallTrigger")) return;
            
            col.GetComponentInParent<BallController>().SandGroundChanged(false);
        }
    }
}
