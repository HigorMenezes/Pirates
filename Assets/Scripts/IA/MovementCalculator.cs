using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovementCalculator {

	public static ArrayList movementCalculate(int[,] matrix, Vector2 from, string tag){
		ArrayList Movements = new ArrayList();
		int x = (int) from.x;
		int y = (int) from.y;

		int enemy = -1;
		int enemyTreasure = -1;

		if (tag.Equals ("Blue")) {
			enemy = GameController.playerRed;
			enemyTreasure = GameController.treasureRed;
		} else if (tag.Equals ("Red")){
			enemy = GameController.playerBlue;
			enemyTreasure = GameController.treasureBlue;
		} else {
			Debug.Log ("TAG NÃO ENCONTRADA");
		}

		if ((y + 1) >= 0 && (y + 1) < Table.COLUMN 
			&& (x) >= 0 && (x) < Table.LINE){
			if (matrix [x, y + 1] == 0) { // DIREITA
				Movements.Add (new Movement (from, new Vector2 (x, y + 1), Movement.Move.move));
			}else if (matrix [x, y + 1] == enemyTreasure){
				Movements.Add (new Movement (from, new Vector2 (x, y + 1), Movement.Move.win));
			}
		}
		if ((y - 1) >= 0 && (y - 1) < Table.COLUMN 
			&& (x) >= 0 && (x) < Table.LINE){
			if (matrix [x, y - 1] == 0) { // ESQUERDA
				Movements.Add (new Movement (from, new Vector2 (x, y - 1), Movement.Move.move));
			}else if (matrix [x, y - 1] == enemyTreasure) { // ESQUERDA
				Movements.Add (new Movement (from, new Vector2 (x, y - 1), Movement.Move.win));
			}
		}
		if ((y) >= 0 && (y) < Table.COLUMN 
			&& (x + 1) >= 0 && (x + 1) < Table.LINE){
			if (matrix [x + 1, y] == 0) { // BAIXO
				Movements.Add (new Movement (from, new Vector2 (x + 1, y), Movement.Move.move));
			}else if (matrix [x + 1, y] == enemyTreasure) { // BAIXO
				Movements.Add (new Movement (from, new Vector2 (x + 1, y), Movement.Move.win));
			}
		}
		if ((y) >= 0 && (y) < Table.COLUMN 
			&& (x - 1) >= 0 && (x - 1) < Table.LINE){
			if (matrix [x - 1, y] == 0) { // CIMA
				Movements.Add (new Movement (from, new Vector2 (x - 1, y), Movement.Move.move));
			}else if (matrix [x - 1, y] == enemyTreasure) { // CIMA
				Movements.Add (new Movement (from, new Vector2 (x - 1, y), Movement.Move.win));
			}
		}

		if ((y + 1) >= 0 && (y + 1) < Table.COLUMN 
			&& (x - 1) >= 0 && (x - 1) < Table.LINE
			&& matrix[x - 1, y + 1] == enemy){ // DIREITA CIMA
			Movements.Add(new Movement(from, new Vector2(x - 1, y + 1), Movement.Move.attack));
		}
		if ((y + 1) >= 0 && (y + 1) < Table.COLUMN 
			&& (x + 1) >= 0 && (x + 1) < Table.LINE
			&& matrix[x + 1, y + 1] == enemy){ // DIREITA BAIXO
			Movements.Add(new Movement(from, new Vector2(x + 1, y + 1), Movement.Move.attack));
		}
		if ((y - 1) >= 0 && (y - 1) < Table.COLUMN 
			&& (x - 1) >= 0 && (x - 1) < Table.LINE
			&& matrix[x - 1, y - 1] == enemy){ // ESQUERDA CIMA
			Movements.Add(new Movement(from, new Vector2(x - 1, y - 1), Movement.Move.attack));
		}
		if ((y - 1) >= 0 && (y - 1) < Table.COLUMN 
			&& (x + 1) >= 0 && (x + 1) < Table.LINE
			&& matrix[x + 1, y - 1] == enemy){ // ESQUERDA BAIXO
			Movements.Add(new Movement(from, new Vector2(x + 1, y - 1), Movement.Move.attack));
		}

		return Movements;
	}

	public static int[,] MatrixCalculator(int[,] matrix, Movement Movement, string tag){
		int[,] matrixResult = (int[,]) matrix.Clone();

		int player = -1;

		if (tag.Equals ("Blue")) {
			player = GameController.playerBlue;
		} else if (tag.Equals ("Red")) {
			player = GameController.playerRed;
		} else {
			Debug.Log ("TAG NÃO ENCONTRADA");
		}

		Vector2 from = Movement.From;
		Vector2 to = Movement.To;

		matrixResult [(int)from.x, (int)from.y] = 0;
		matrixResult [(int)to.x, (int)to.y] = player;

		return matrixResult;
	}

}

