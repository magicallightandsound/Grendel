using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActsAsRootGameObject : MonoBehaviour {

    public static GameObject root;

    public GameObject rootPrefab = null;

    private Transform gameOrigin = null;

    private void Awake()
    {
        gameOrigin = Camera.main.transform;
    }
    // Use this for initialization
    void Start () {
        if (rootPrefab != null)
        {
            root = Instantiate(rootPrefab, gameOrigin);
        }
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
