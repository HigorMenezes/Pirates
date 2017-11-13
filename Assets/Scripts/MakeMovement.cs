using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMovement : MonoBehaviour {

	public float time = 0f;
	public float maxTime = 0.5f;
	public float lerp = 0.2f;

	private static RaycastHit hit;

	private static GameObject objectToMove;

	private static Vector3 from;
	private static Vector3 to;

	void Start () {
		objectToMove = null;
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
			
			if (time > maxTime){
				objectToMove.transform.position = new Vector3 (to.x, to.y, objectToMove.transform.position.z);
				time = 0;
				GameController.changeCurrent ();
			}
		}
	}

	public static void makeMovement (Movement movement, string tag) {

		MovementCalculator.MatrixCalculator (GameController.table.getTable(), movement, tag);

		from = new Vector3 ( movement.From.x, movement.From.y, -2f );
		to = new Vector3 ( movement.To.x, movement.To.y, -2f );

		Physics.Raycast (from, Vector3.forward, out hit);

		if (hit.collider.tag.Equals (tag)) {
			objectToMove = hit.collider.gameObject;
		}
			
		GameController.currentTurn = GameController.Current.Movement;

	}

}
