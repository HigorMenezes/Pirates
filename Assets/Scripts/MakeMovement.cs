using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMovement : MonoBehaviour {

	public float time = 0f;
	public float maxTime = 0.5f;
	public float lerp = 0.2f;

	private static RaycastHit hit;

	private static GameObject objectToMove;
	private static GameObject objectToRemove;

	private static Vector3 from;
	private static Vector3 to;

	void Start () {
		objectToMove = null;
		objectToRemove = null;
	}

	void Update () {
		
	}

	void FixedUpdate (){
		if (GameController.currentTurn.ToString().Equals ("Movement")) {
			
			time += Time.deltaTime;
			objectToMove.transform.position = Vector3.Lerp (
				objectToMove.transform.position, 
				new Vector3 (to.x, to.y, objectToMove.transform.position.z), 
				lerp);
			if (time > maxTime / 2 && objectToRemove != null) {
				Destroy (objectToRemove);
				objectToRemove = null;
			}

			if (time > maxTime){
				objectToMove.transform.position = new Vector3 (to.x, to.y, objectToMove.transform.position.z);
				time = 0;



				GameController.changeCurrent ();
			}
		}
	}

	public static void makeMovement (Movement movement, string tag) {

		GameController.table.TableMatrix = MovementCalculator.MatrixCalculator (GameController.table.TableMatrix, movement, tag);

		string enemyTag = "";

		if (tag.Equals ("Red")) {
			enemyTag = "Blue";
		} else if (tag.Equals ("Blue")) {
			enemyTag = "Red";
		} else {
			Debug.Log ("TAG NÃO ENCONTRADA PARA UM INIMIGO NO MOVIMENTO");
		}

		from = new Vector3 ( movement.From.x, movement.From.y, 0f );
		to = new Vector3 ( movement.To.x, movement.To.y, 0f);

		//Debug.Log (from);
		//Debug.Log (to);

		if (Physics.Raycast (from, -Vector3.forward, out hit)) {
			
			if (hit.collider.tag.Equals (tag)) {
				//Debug.Log ("Encontrou objeto para ser movido" + tag);
				objectToMove = hit.collider.gameObject;
			}
		}

		if (Physics.Raycast (to, -Vector3.forward, out hit)) {
			
			if (hit.collider.tag.Equals (enemyTag)) {
				//Debug.Log ("Encontrou objeto no local do movimento");
				objectToRemove = hit.collider.gameObject;
			}
		}
			
		GameController.currentTurn = GameController.Current.Movement;

	}

}
