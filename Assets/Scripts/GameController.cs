using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public static string turn1 = "Player";
	public static string turn2 = "Com";
	public static string currentTurn;
	public static string tagAttack;


	void Start () {
		if (Random.Range (0, 2) % 2 == 0) 
			currentTurn = turn1;
		else
			currentTurn = turn2;
	}


	public static void changeTurn () {
		if (currentTurn.Equals (turn1) && countPlayers(9) > 0) {
			currentTurn = turn2;
		} else if (currentTurn.Equals (turn2) && countPlayers(1) > 0) {
			currentTurn = turn1;
		}
	}

	public static int countPlayers(int player){
		int[,] m = TabuleiroController.tabuleiro.matrizTabuleiro;
		int l = Tabuleiro.LINHA;
		int c = Tabuleiro.COLUNA;
		int cont = 0;

		for (int i = 0; i < l; i++){
			for (int j = 0; j < c; j++) {
				if (m[i,j] == player)
					cont++;
			}
		}

		return cont;
	}

}
