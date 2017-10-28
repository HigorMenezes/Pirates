using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovimentCalculater {

	public static ArrayList calculaMovimento(int[,] matriz, Vector2 pos, int enemy, int enemyTesouro){
		ArrayList moviments = new ArrayList();
		int x = (int) pos.x;
		int y = (int) pos.y;

		if ((y + 1) >= 0 && (y + 1) < Tabuleiro.COLUNA 
			&& (x) >= 0 && (x) < Tabuleiro.LINHA){
			if (matriz [x, y + 1] == 0) { // DIREITA
				moviments.Add (new Moviment (new Vector2 (x, y + 1), Moviment.MoveType.move));
			}else if (matriz [x, y + 1] == enemyTesouro){
				moviments.Add (new Moviment (new Vector2 (x, y + 1), Moviment.MoveType.win));
			}
		}
		if ((y - 1) >= 0 && (y - 1) < Tabuleiro.COLUNA 
			&& (x) >= 0 && (x) < Tabuleiro.LINHA){
			if (matriz [x, y - 1] == 0) { // ESQUERDA
				moviments.Add (new Moviment (new Vector2 (x, y - 1), Moviment.MoveType.move));
			}else if (matriz [x, y - 1] == enemyTesouro) { // ESQUERDA
				moviments.Add (new Moviment (new Vector2 (x, y - 1), Moviment.MoveType.win));
			}
		}
		if ((y) >= 0 && (y) < Tabuleiro.COLUNA 
			&& (x + 1) >= 0 && (x + 1) < Tabuleiro.LINHA){
			if (matriz [x + 1, y] == 0) { // BAIXO
				moviments.Add (new Moviment (new Vector2 (x + 1, y), Moviment.MoveType.move));
			}else if (matriz [x + 1, y] == enemyTesouro) { // BAIXO
				moviments.Add (new Moviment (new Vector2 (x + 1, y), Moviment.MoveType.win));
			}
		}
		if ((y) >= 0 && (y) < Tabuleiro.COLUNA 
			&& (x - 1) >= 0 && (x - 1) < Tabuleiro.LINHA){
			if (matriz [x - 1, y] == 0) { // CIMA
				moviments.Add (new Moviment (new Vector2 (x - 1, y), Moviment.MoveType.move));
			}else if (matriz [x - 1, y] == 0) { // CIMA
				moviments.Add (new Moviment (new Vector2 (x - 1, y), Moviment.MoveType.win));
			}
		}
			
		if ((y + 1) >= 0 && (y + 1) < Tabuleiro.COLUNA 
			&& (x - 1) >= 0 && (x - 1) < Tabuleiro.LINHA
			&& matriz[x - 1, y + 1] == enemy){ // DIREITA CIMA
			moviments.Add(new Moviment(new Vector2(x - 1, y + 1), Moviment.MoveType.attack));
		}
		if ((y + 1) >= 0 && (y + 1) < Tabuleiro.COLUNA 
			&& (x + 1) >= 0 && (x + 1) < Tabuleiro.LINHA
			&& matriz[x + 1, y + 1] == enemy){ // DIREITA BAIXO
			moviments.Add(new Moviment(new Vector2(x + 1, y + 1), Moviment.MoveType.attack));
		}
		if ((y - 1) >= 0 && (y - 1) < Tabuleiro.COLUNA 
			&& (x - 1) >= 0 && (x - 1) < Tabuleiro.LINHA
			&& matriz[x - 1, y - 1] == enemy){ // ESQUERDA CIMA
			moviments.Add(new Moviment(new Vector2(x - 1, y - 1), Moviment.MoveType.attack));
		}
		if ((y - 1) >= 0 && (y - 1) < Tabuleiro.COLUNA 
			&& (x + 1) >= 0 && (x + 1) < Tabuleiro.LINHA
			&& matriz[x + 1, y - 1] == enemy){ // ESQUERDA BAIXO
			moviments.Add(new Moviment(new Vector2(x + 1, y - 1), Moviment.MoveType.attack));
		}

		return moviments;
	}
}
