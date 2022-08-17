// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1.Core.Ball
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