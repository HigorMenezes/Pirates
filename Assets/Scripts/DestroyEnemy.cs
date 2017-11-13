using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {

		if (GameController.previousCurrent.ToString().Equals (this.tag)) {
			Destroy (collider.gameObject);
		}

	}


}
