using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Table {

	public const int LINE = 7;
	public const int COLUMN = 5;

	private int[,] tableMatrix;

	public Table (){
		tableMatrix = new int[LINE, COLUMN]{
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
		};
	}

	public Table (int[,] tableMatrix)
	{
		this.tableMatrix = tableMatrix;
	}
		
	public int[,] TableMatrix {
		get {
			return this.tableMatrix;
		}
		set {
			tableMatrix = value;
		}
	}

	public int utility(string tag){
		int[,] matrix = this.TableMatrix;

		ArrayList posEnemy = new ArrayList ();
		ArrayList posPlayer = new ArrayList ();
		Vector2 posEnemyTreasure = new Vector2(0f,0f);
		Vector2 posPlayerTreasure = new Vector2(0f,0f);;

		int enemyPlayer = 0;
		int player = 0;

		int playerEnemyManhattan = int.MaxValue;
		int enemyPlayerManhattan = int.MaxValue;
		int playerPlayerManhattan = int.MaxValue;
		int enemyEnemyManhattan = int.MaxValue;

		int countEnemy = 0;
		int countPlayer = 0;

		int resultado = 0;

		if (tag.Equals ("Red")) {
			enemyPlayer = GameController.playerBlue;
			player = GameController.playerRed;
			posEnemyTreasure = new Vector2 (6f, 2f);
			posPlayerTreasure = new Vector2 (0f, 2f);

		} else if (tag.Equals ("Blue")) {
			enemyPlayer = GameController.playerRed;
			player = GameController.playerBlue;
			posEnemyTreasure = new Vector2 (0f, 2f);
			posPlayerTreasure = new Vector2 (6f, 2f);

		} else {
			Debug.Log ("ERRO AO ENCONTRAR TAG NA FUNÇÃO UTILIDADE");
		}


		for (int i = 0; i < Table.LINE; i++){
			for (int j = 0; j < Table.COLUMN; j++){
				if (matrix[i,j] == player){
					posPlayer.Add (new Vector2(i,j));
				}else if (matrix[i,j] == enemyPlayer){
					posEnemy.Add (new Vector2(i,j));
				}
			}
		}

		foreach(Vector2 pos in posPlayer){
			int dist = (int) Mathf.Abs(pos.x - posEnemyTreasure.x) + (int) Mathf.Abs(pos.y - posEnemyTreasure.y);
			playerEnemyManhattan = Mathf.Min (playerEnemyManhattan, dist);
			dist = (int) Mathf.Abs(pos.x - posPlayerTreasure.x) + (int) Mathf.Abs(pos.y - posPlayerTreasure.y);
			playerPlayerManhattan = Mathf.Min (playerEnemyManhattan, dist);
		}

		foreach(Vector2 pos in posPlayer){
			int dist = (int) Mathf.Abs(pos.x - posPlayerTreasure.x) + (int) Mathf.Abs(pos.y - posPlayerTreasure.y);
			enemyPlayerManhattan = Mathf.Min (playerEnemyManhattan, dist);
			dist = (int) Mathf.Abs(pos.x - posEnemyTreasure.x) + (int) Mathf.Abs(pos.y - posEnemyTreasure.y);
			enemyEnemyManhattan = Mathf.Min (playerEnemyManhattan, dist);
		}

		countPlayer = posPlayer.Count;
		countEnemy = posEnemy.Count;

		if (countPlayer == 0)
			resultado = -1000;
		if (countEnemy == 0)
			resultado = 1000;

		if (countPlayer > countEnemy)
			resultado += 50;
		if (countPlayer < countEnemy)
			resultado -= 50;

		if (playerEnemyManhattan < enemyEnemyManhattan)
			resultado += 25;
		if (playerPlayerManhattan > enemyPlayerManhattan)
			resultado -= 25;
		

		return resultado - playerEnemyManhattan;
	}
		

	public Table clone(){
		Table table = new Table ();
		int[,] matrix = new int[LINE, COLUMN];

		for (int i = 0; i < LINE; i++) {
			for (int j = 0; j < COLUMN; j++) {
				matrix [i, j] = this.tableMatrix [i, j];
			}
		}

		table.tableMatrix = matrix;

		return table;

	}

}
