using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour {

	void OnTriggerEnter(Collider collider) {
		if (GameController.tagAttack.Equals (this.tag)) {
			Destroy (collider.gameObject);
			if (collider.tag.Equals("Tesouro")){
				Debug.Log ("WIN");
			}
		}
	}

}
