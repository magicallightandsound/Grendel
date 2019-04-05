﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsLerpMovement : MonoBehaviour {

    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;


    void Start()
    {
        startPosition = target = transform.position;
    }



    void Update()
    {
        if (target != transform.position)
        {
            t += Time.deltaTime / timeToReachTarget;
            transform.position = Vector3.Lerp(startPosition, target, t);
        }

    }
    public void SetDestination(Vector3 destination, float time)
    {
        t = 0;
        startPosition = transform.position;
        timeToReachTarget = time;
        target = destination;
    }
}
