using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (PlayerController.myTurn) {
			Destroy (collider.gameObject);
		}
	}

}
