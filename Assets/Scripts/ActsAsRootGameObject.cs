using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsRootGameObject : MonoBehaviour {

    public static GameObject root;

    private GameObject rootPrefab = null;
    
    private Transform gameOrigin = null;

    private void Awake()
    {
        gameOrigin.position = Camera.main.transform.position;
    }
    // Use this for initialization
    void Start () {
        root = Instantiate(rootPrefab, gameOrigin);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
