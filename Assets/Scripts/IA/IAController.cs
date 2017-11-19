using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour {

	private TreeGenerate treeGenerate;


	void Start () {
		
	}

	void Update () {
		if (GameController.currentTurn.ToString ().Equals (this.tag) && GameController.table != null) {
			ArrayList moviments = new ArrayList ();

			treeGenerate = new TreeGenerate (this.tag);
			treeGenerate.treeGenerate ();


			MiniMax.seach(treeGenerate.Raiz);

			foreach(Nodo nodo in treeGenerate.Raiz.Children){
				if (nodo.Value == treeGenerate.Raiz.Value){
					moviments.Add (nodo.Movement);
				}
			}

			int rand = Random.Range (0, moviments.Count);

			object[] movimentsArray = moviments.ToArray();

			MakeMovement.makeMovement ((Movement)movimentsArray[rand], this.tag);
				
			foreach(Nodo nodo in treeGenerate.Raiz.Children){
			//	Debug.Log (nodo.Value);
			}

			Debug.Log ("Escolha: " + treeGenerate.Raiz.Value);
		}
	}

	public void debugTree(){
		string textMatrix = "";

		int index = 4;
		int indexArray = 0;
		int[,] matrix = new int[7,5];

		//Debug.Log (treeGenerate.Raiz.Value);



		foreach (Nodo nodo in treeGenerate.Raiz.Children) {
			if (indexArray == index) {
				matrix = nodo.Table.TableMatrix;
				Debug.Log (nodo.Movement.toString());
			}
			indexArray++;
		}



		textMatrix = "";
		for (int i = 0; i < Table.LINE; i++) {
			for (int j = 0; j < Table.COLUMN; j++) {
				textMatrix += "   " + matrix [i, j];
			}
			textMatrix += "     ";
		}
		//Debug.Log (textMatrix);

	}



}
