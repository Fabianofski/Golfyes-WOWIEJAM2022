// /**
//  * This file is part of: Golf, yes?
//  * Copyright (C) 2022 Fabian Friedrich
//  * Distributed under the terms of the MIT license (cf. LICENSE.md file)
//  **/

using UnityEngine;

namespace F4B1
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float dir;
        [SerializeField] private float startPosition;
        [SerializeField] private float resetPosition;

        private void Update()
        {
            transform.Translate(new Vector2(dir, 0) * (speed * Time.deltaTime));
            if (Mathf.Abs(transform.position.x) > Mathf.Abs(resetPosition))
                transform.position = new Vector2(startPosition, transform.position.y);
        }
    }
}