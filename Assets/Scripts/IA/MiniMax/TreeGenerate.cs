using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TreeGenerate {

	public int maxDepth = 2;
	private Nodo raiz = new Nodo();
	string playerTag = "";
	string enemyTag = "";
	int player;
	int enemy;

	public TreeGenerate (string tag){
		raiz.MaxMin = Nodo.MaxOrMin.max;
		raiz.Nome = "Raiz";
		raiz.Table = GameController.table.clone ();
		playerTag = tag;
		if (tag.Equals ("Blue")) {
			enemyTag = "Red";
			player = GameController.playerBlue;
			enemy = GameController.playerRed;
		} else if (tag.Equals ("Red")) {
			enemyTag = "Blue";
			player = GameController.playerRed;
			enemy = GameController.playerBlue;
		} else {
			Debug.Log ("TAG PARA CRIAÇÃO DA ÁRVORE NÃO ENCONTRADA");
		}
	}

	public void treeGenerate (){
		ArrayList father = new ArrayList ();
		ArrayList children = new ArrayList ();

		father.Add (raiz);

		for (int i = 0; i < maxDepth; i++){

			foreach (Nodo nodo in father){

				nodo.Children = calculateChildren (nodo);

				children.AddRange (nodo.Children);
			}
			father.Clear ();
			father.AddRange(children);
			children.Clear ();
		}
		foreach (Nodo nodo in father) {
			if (nodo.MaxMin.Equals (Nodo.MaxOrMin.max)) {
				nodo.Value = nodo.Table.utility (this.playerTag);
			} else {
				nodo.Value = nodo.Table.utility (this.enemyTag);
			}
			Debug.Log (nodo.Nome + " VALOR: " + nodo.Value);
		}
	}

	public ArrayList calculateChildren (Nodo nodo){
		ArrayList children = new ArrayList ();
		ArrayList movements = new ArrayList ();

		int[,] matrix = nodo.Table.clone ().TableMatrix;

		for (int i = 0; i < Table.LINE; i++) {
			for (int j = 0; j < Table.COLUMN; j++) {
				if (nodo.MaxMin.Equals(Nodo.MaxOrMin.max) && matrix[i,j] == player){
					movements.AddRange (MovementCalculator.movementCalculate(matrix, new Vector2(i,j), this.playerTag));
					//NÃO PRECISA PERCORRER A MATRIZ TODA
				}else if (nodo.MaxMin.Equals(Nodo.MaxOrMin.min) && matrix[i,j] == enemy){
					movements.AddRange (MovementCalculator.movementCalculate(matrix, new Vector2(i,j), this.enemyTag));
					//NÃO PRECISA PERCORRER A MATRIZ TODA
				}
			}

		}

		foreach (Movement movement in movements){

			Nodo nodoChildren = new Nodo();

			nodoChildren.Father = nodo;
			if (nodo.MaxMin == Nodo.MaxOrMin.max) {
				nodoChildren.MaxMin = Nodo.MaxOrMin.min;
				nodoChildren.Table = new Table ( MovementCalculator.MatrixCalculator (matrix, movement, this.playerTag));
			} else {
				nodoChildren.MaxMin = Nodo.MaxOrMin.max;
				nodoChildren.Table = new Table ( MovementCalculator.MatrixCalculator (matrix, movement, this.enemyTag));
			}

			nodoChildren.Nome = movement.To.ToString ();
			nodoChildren.Movement = movement.clone();

			children.Add (nodoChildren);

		}

		return children;
	}

	public Nodo Raiz {
		get {
			return this.raiz;
		}
		set {
			raiz = value;
		}
	}
		
}
