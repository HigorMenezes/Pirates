﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject prefab;

	private GameObject objToMove;
	private GameObject moveAt;

	private RaycastHit hit;
	private ArrayList objDiscart = new ArrayList();

	private bool flag = true;

	void Start () {
		
	}


	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0) && flag) {
			destroiObj ();
			flag = false;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.tag.Equals ("Player")) {
					objToMove = hit.transform.gameObject;
					calculaMovimentos ();
				}else if (hit.collider.tag.Equals ("Move")) {
					moveAt = hit.transform.gameObject;
					moverObj ();
				}
			}
		}
		if (Input.GetKeyUp (KeyCode.Mouse0)){
			flag = true;
		}
	}

	public void calculaMovimentos (){
		Vector2 pos = new Vector2 (hit.transform.position.x, hit.transform.position.y);
		ArrayList moviments = MovimentCalculater.calculaMovimento (TabuleiroController.tabuleiro.matrizTabuleiro, pos, 9);
		foreach (Moviment moviment in moviments) {
			Vector3 pos2 = new Vector3(moviment.pos.x, moviment.pos.y, -0.41f);
			objDiscart.Add(Instantiate (prefab, pos2, Quaternion.Euler(0f,0f,0f)));
		}

	}

	public void moverObj(){
		atualizaMatriz (objToMove, moveAt);
		objToMove.transform.position = new Vector3 (moveAt.transform.position.x,
													moveAt.transform.position.y,
													objToMove.transform.position.z);
		
	}

	private void atualizaMatriz(GameObject from, GameObject to){
		Vector2 pos = new Vector2 (from.transform.position.x, from.transform.position.y);
		TabuleiroController.tabuleiro.matrizTabuleiro[(int)pos.x, (int)pos.y] = 0;
		pos = new Vector2 (to.transform.position.x, to.transform.position.y);
		TabuleiroController.tabuleiro.matrizTabuleiro[(int)pos.x, (int)pos.y] = 1;
	}

	public void destroiObj(){
		foreach (GameObject gameObject in objDiscart) {
			Destroy (gameObject);
		}
	}


}