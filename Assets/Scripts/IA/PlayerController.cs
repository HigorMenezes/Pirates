using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private bool flag = true;

	private RaycastHit hit;

	private ArrayList discardObject = new ArrayList();

	private ArrayList movements = new ArrayList();

	public GameObject player;
	public GameObject move;
	public GameObject attack;
	public GameObject win;

	void Start () {
		/*if (this.tag.Equals ("Red")) {
			for (int i = 0; i < Table.LINE; i++) {
				for (int j = 0; j < Table.COLUMN; j++) {
					if (GameController.table.getTable () [i, j] == GameController.playerRed) {
						Vector3 pos = new Vector3 (i, j, 0);
						Instantiate (player, this.transform.position + pos, Quaternion.Euler (0f, 0f, 0f));
					}
						
				}
			}
		} else if (this.tag.Equals ("Blue")) {
			for (int i = 0; i < Table.LINE; i++) {
				for (int j = 0; j < Table.COLUMN; j++) {
					if (GameController.table.getTable () [i, j] == GameController.playerBlue) {
						Vector3 pos = new Vector3 (i, j, 0);
						Instantiate (player, this.transform.position + pos, Quaternion.Euler (0f, 0f, 0f));
					}

				}
			}
		}*/


	}

	void Update () {
		if (GameController.currentTurn.ToString().Equals (this.tag)) {
			if (Input.GetKeyDown (KeyCode.Mouse0) && flag) {
				flag = false;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				destroy ();
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag.Equals (this.tag)) {
						movementCalculator (hit.transform.position);
					}else if (hit.collider.tag.Equals ("Move")){
						destroy ();
						MakeMovement.makeMovement (selectedMovement(hit.collider.gameObject), this.tag);
					}
				}

			}
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				flag = true;
			}
		}
	}
		
	public void movementCalculator(Vector3 pos){
		movements.Clear ();

		Vector2 from = new Vector2 (pos.x, pos.y);
		movements = MovementCalculator.movementCalculate (GameController.table.getTable(), from, this.tag);
	
		foreach(Movement movement in movements){
			if (movement.MoveType == Movement.Move.move){
				Vector3 pos2 = new Vector3 (movement.To.x, movement.To.y, -0.41f);
				discardObject.Add (Instantiate (move, pos2, Quaternion.Euler (0f, 0f, 0f)));
			} else if (movement.MoveType == Movement.Move.attack){
				Vector3 pos2 = new Vector3 (movement.To.x, movement.To.y, -1.41f);
				discardObject.Add (Instantiate (attack, pos2, Quaternion.Euler (0f, 0f, 0f)));
			} else if (movement.MoveType == Movement.Move.win){
				Vector3 pos2 = new Vector3 (movement.To.x, movement.To.y, -1f);
				discardObject.Add (Instantiate (win, pos2, Quaternion.Euler (0f, 0f, 0f)));
			}
		}

	}

	public void destroy(){
		foreach (GameObject gameObject in discardObject){
			Destroy (gameObject);
		}
		discardObject.Clear ();
	}

	public Movement selectedMovement(GameObject selected){
		foreach (Movement movement in movements){
			Vector3 pos = selected.transform.position;
			if (pos.x == movement.To.x && pos.y == movement.To.y){
				return movement;
			}
		}

		Debug.Log ("OBJETO SELECIONADO PARA MOVER NÃO ENCONTRADO");

		return null;
	}
		
}
