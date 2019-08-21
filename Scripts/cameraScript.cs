using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public float cameraSpeed = 1f;

public class cameraScript : MonoBehaviour {

    GameObject objectToFollow;

	// Use this for initialization
	void Start () {
        objectToFollow = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update () {

    Vector3 position = this.transform.position;
    float interpolation = cameraSpeed * Time.deltaTime;
    position.y = Mathf.Lerp(this.transform.position.y, objectToFollow.transform.position.y, interpolation);
    position.x = Mathf.Lerp(this.transform.position.x, objectToFollow.transform.position.x, interpolation);
    this.transform.position = position;
	}
}
