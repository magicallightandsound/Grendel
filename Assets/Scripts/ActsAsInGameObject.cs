using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsInGameObject : MonoBehaviour {

    GameObject parentGameObject;

    [SerializeField] Vector3 position = Vector3.zero;

	// Use this for initialization
	void Start () {

        parentGameObject = ActsAsRootGameObject.root;

        // Places GameObject at origin of parent
        this.transform.parent = parentGameObject.transform;

        // Get the Vector3 of the parent Local Origin 
        Vector3 parentLocalOrigin = parentGameObject.transform.localPosition;

        // Move GameObject to actual position, relative to the origin of the parentGameObject
        this.transform.position = parentLocalOrigin + position;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
