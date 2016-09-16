using UnityEngine;
using System.Collections;

public class ObstaculoController : MonoBehaviour {

	public float velocidade;
	float x;

	void Start () {
	
	}


	void Update () {
		x = transform.position.x;
		x = x - (velocidade * Time.deltaTime);

		transform.position = new Vector2(x, transform.position.y);
	}
}
