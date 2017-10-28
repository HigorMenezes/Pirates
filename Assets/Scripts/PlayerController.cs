using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public int enemy;
	public int enemyTesouro;
	public int myValue;

	public GameObject prefabMove;
	public GameObject prefabAttack;
	public GameObject prefabWin;

	private GameObject objToMove;
	private GameObject moveAt;

	private RaycastHit hit;
	private ArrayList objDiscart = new ArrayList();

	private bool flag = true;

	void Start () {
		
	}
		
	void Update () {
		if (GameController.currentTurn.Equals (this.tag)) {
			if (Input.GetKeyDown (KeyCode.Mouse0) && flag) {
				destroiObj ();
				flag = false;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit)) {
					if (hit.collider.tag.Equals (this.tag)) {
						objToMove = hit.transform.gameObject;
						calculaMovimentos ();
					} else if (hit.collider.tag.Equals("Move")){
						GameController.tagAttack = this.tag;
						moveAt = hit.transform.gameObject;
						moverObj ();
					} 
				}
			}
			if (Input.GetKeyUp (KeyCode.Mouse0)) {
				flag = true;
			}
		}
	}

	public void calculaMovimentos (){
		Vector2 pos = new Vector2 (hit.transform.position.x, hit.transform.position.y);
		ArrayList moviments = MovimentCalculater.calculaMovimento (TabuleiroController.tabuleiro.matrizTabuleiro, pos, enemy, enemyTesouro);
		foreach (Moviment moviment in moviments) {
			if (moviment.moveType == Moviment.MoveType.move) {
				Vector3 pos2 = new Vector3 (moviment.pos.x, moviment.pos.y, -0.41f);
				objDiscart.Add (Instantiate (prefabMove, pos2, Quaternion.Euler (0f, 0f, 0f)));
			} else if (moviment.moveType == Moviment.MoveType.attack) {
				Vector3 pos2 = new Vector3 (moviment.pos.x, moviment.pos.y, -1.41f);
				objDiscart.Add (Instantiate (prefabAttack, pos2, Quaternion.Euler (0f, 0f, 0f)));
			}	else if (moviment.moveType == Moviment.MoveType.win) {
				Vector3 pos2 = new Vector3 (moviment.pos.x, moviment.pos.y, -1f);
				objDiscart.Add (Instantiate (prefabWin, pos2, Quaternion.Euler (0f, 0f, 0f)));
			}
		}

	}

	public void moverObj(){
		atualizaMatriz (objToMove, moveAt);
		objToMove.transform.position = new Vector3 (moveAt.transform.position.x,
													moveAt.transform.position.y,
													objToMove.transform.position.z);
		
		GameController.changeTurn ();
	}

	private void atualizaMatriz(GameObject from, GameObject to){
		Vector2 pos = new Vector2 (from.transform.position.x, from.transform.position.y);
		TabuleiroController.tabuleiro.matrizTabuleiro[(int)pos.x, (int)pos.y] = 0;
		pos = new Vector2 (to.transform.position.x, to.transform.position.y);
		TabuleiroController.tabuleiro.matrizTabuleiro[(int)pos.x, (int)pos.y] = myValue;
	}

	public void destroiObj(){
		foreach (GameObject gameObject in objDiscart) {
			Destroy (gameObject);
		}
	}
}
