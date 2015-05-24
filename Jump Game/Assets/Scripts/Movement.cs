using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public float fuerzaSalto = 100f;


	//no toca el suelo
	public bool enSuelo = true;
	public Transform comprobadorSuelo;
	float comprobadorRadio= 0.07f;
	public LayerMask mascaraSuelo;

	//Doblesalto
	private bool dobleSalto = false;


	// Use this for initialization
	void Start () {
	
	}
	void FixedUpdate () {
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		if (enSuelo) {
			dobleSalto = false;
		}

	
	}
	// Update is called once per frame
	void Update () {
		//Salto cuando pulses
		if((enSuelo || !dobleSalto) && Input.GetMouseButtonDown(0)){
			GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, fuerzaSalto));
			if(!dobleSalto && !enSuelo) {
				dobleSalto = true;
			}
		}
	}
}
