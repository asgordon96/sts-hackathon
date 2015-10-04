using UnityEngine;
using System.Collections;

public class Balancer : MonoBehaviour {

	public GameObject cube;
	public GameObject sphere;
	public Camera camera;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		var position = cube.GetComponent<Transform> ().position;
		var transform = sphere.GetComponent<Transform> ();
		transform.position = position;
		transform.LookAt (Camera.main.transform);
    }
}
