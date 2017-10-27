using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MovimentCalculater {

	public static ArrayList calculaMovimento(int[,] matriz, Vector2 pos, int enemy){
		ArrayList moviments = new ArrayList();
		int x = (int) pos.x;
		int y = (int) pos.y;

		if ((y + 1) >= 0 && (y + 1) < Tabuleiro.COLUNA 
			&& (x) >= 0 && (x) < Tabuleiro.LINHA
			&& matriz[x, y + 1] == 0) { // DIREITA
			moviments.Add(new Moviment(new Vector2(x, y + 1), Moviment.MoveType.move));
		}
		if ((y - 1) >= 0 && (y - 1) < Tabuleiro.COLUNA 
			&& (x) >= 0 && (x) < Tabuleiro.LINHA
			&& matriz[x, y - 1] == 0) { // ESQUERDA
			moviments.Add(new Moviment(new Vector2(x, y - 1), Moviment.MoveType.move));
		}
		if ((y) >= 0 && (y) < Tabuleiro.COLUNA 
			&& (x + 1) >= 0 && (x + 1) < Tabuleiro.LINHA
			&& matriz[x + 1, y] == 0) { // BAIXO
			moviments.Add(new Moviment(new Vector2(x + 1, y), Moviment.MoveType.move));
		}
		if ((y) >= 0 && (y) < Tabuleiro.COLUNA 
			&& (x - 1) >= 0 && (x - 1) < Tabuleiro.LINHA
			&& matriz[x - 1, y] == 0) { // CIMA
			moviments.Add(new Moviment(new Vector2(x - 1, y), Moviment.MoveType.move));
		}
			
		return moviments;
	}
}
