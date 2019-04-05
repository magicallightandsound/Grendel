using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActsAsIndex : MonoBehaviour {

    [SerializeField] Transform transform1 = null;
    [SerializeField] Transform transform2 = null;
    [SerializeField] Transform transform3 = null;
    [SerializeField] float timeToMove = .33f;

    List<Object> prefabs = new List<Object>();
    List<GameObject> gameObjects = new List<GameObject>();



    float timer = 0f;
    float waitTime = .33f;


	// Use this for initialization
	void Start () {

        Object[] indexables = Resources.LoadAll("GameObjects", typeof(GameObject));
        prefabs = new List<Object>(indexables);

        foreach (var obj in prefabs)
        {
            GameObject prefab = obj as GameObject;
            GameObject gameObject = Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
            gameObjects.Add(gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {

        bool forward = Input.GetKey(KeyCode.LeftArrow);
        bool backward = Input.GetKey(KeyCode.RightArrow);

        gameObjects[0].GetComponent<ActsAsLerpMovement>().SetDestination(transform1.position, timeToMove);
        gameObjects[1].GetComponent<ActsAsLerpMovement>().SetDestination(transform2.position, timeToMove);
        gameObjects[2].GetComponent<ActsAsLerpMovement>().SetDestination(transform3.position, timeToMove);


        timer += Time.deltaTime;

        if (timer > waitTime)
        {

            timer = timer - waitTime;



            if (forward)
            {
                CursorForward();
            }

            if (backward)
            {
                CursorBackward();
            }
            
        }


    }


    public void CursorForward()
    {
        GameObject first = gameObjects[0] as GameObject;
        gameObjects.RemoveAt(0);
        gameObjects.Add(first);
    }

    public void CursorBackward()
    {
        GameObject last = gameObjects[gameObjects.Count - 1] as GameObject;
        gameObjects.RemoveAt(gameObjects.Count - 1);
        gameObjects.Insert(0, last);
    }
}
