using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsControl : MonoBehaviour
{
    public float speed = 0f;
    float t;
    Vector3 startPosition;
    Vector3 target;
    float timeToReachTarget;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = target = transform.position;


    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);

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

    public void Rotate(float speed)
    {
        this.speed = speed;
    }
}
