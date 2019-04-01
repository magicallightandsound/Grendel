using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(ActsAsLerpMovement))]
public class ActsAsIndex : MonoBehaviour {

    [SerializeField] Transform transform1 = null;
    [SerializeField] Transform transform2 = null;
    [SerializeField] Transform transform3 = null;

    List<GameObject> gameObjects = new List<GameObject>();

    private bool update = false;

	// Use this for initialization
	void Start () {


        Object[] indexables = Resources.LoadAll("GameObjects", typeof(GameObject));
        gameObjects = new List<GameObject>(indexables as GameObject[]);

        foreach (var gameObject in gameObjects)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.transform.position = gameObject.transform.position;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            CursorForward();
            ReloadData();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            CursorBackward();
            ReloadData();
        }
            

        if (update)
        {
            if (gameObjects.Count > 3)
            {
                gameObjects[0].GetComponent<Renderer>().enabled = true;
                gameObjects[0].GetComponent<MeshRenderer>().enabled = true;
                gameObjects[0].GetComponent<ActsAsLerpMovement>().SetDestination(transform1.position, 5);

                gameObjects[1].GetComponent<Renderer>().enabled = true;
                gameObjects[1].GetComponent<MeshRenderer>().enabled = true;
                gameObjects[1].GetComponent<ActsAsLerpMovement>().SetDestination(transform2.position, 5);

                gameObjects[2].GetComponent<Renderer>().enabled = true;
                gameObjects[2].GetComponent<MeshRenderer>().enabled = true;
                gameObjects[2].GetComponent<ActsAsLerpMovement>().SetDestination(transform3.position, 5);

            }
            else if (gameObjects.Count == 3)
            {
                gameObjects[0].transform.position = transform1.position;
                gameObjects[1].transform.position = transform2.position;
                gameObjects[2].transform.position = transform3.position;
            }
            else if (gameObjects.Count == 2)
            {
                gameObjects[0].transform.position = transform1.position;
                gameObjects[1].transform.position = transform2.position;

            }
            else if (gameObjects.Count == 1)
            {
                gameObjects[0].transform.position = transform1.position;

            }
            update = false;
        }

    }

    public void ReloadData()
    {
        update = true;
    }

    public void CursorForward()
    {
        GameObject first = gameObjects[0];
        gameObjects.RemoveAt(0);
        gameObjects.Add(first);
    }

    public void CursorBackward()
    {
        GameObject last = gameObjects[gameObjects.Count - 1];
        gameObjects.RemoveAt(gameObjects.Count - 1);
        gameObjects.Insert(0, last);
    }
}
