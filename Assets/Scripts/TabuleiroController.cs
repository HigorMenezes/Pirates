using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabuleiroController : MonoBehaviour {

	public static Tabuleiro tabuleiro = new Tabuleiro();
	public Text texto;

	void Start () {
		tabuleiro.matrizTabuleiro = defaultTabuleiro();
	}


	void Update () {
		imprimeMatriz();
	}

	public int[,] defaultTabuleiro (){
		return new int[Tabuleiro.LINHA, Tabuleiro.COLUNA] {
			{ 0, 0, 8, 0, 0 },
			{ 0, 9, 0, 9, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 1, 0, 1, 0 },
			{ 0, 0, 2, 0, 0 },
		};
	}

	public void imprimeMatriz (){
		string matriz = "";
		for (int i = 0; i < Tabuleiro.LINHA; i++) {
			for (int j = 0; j < Tabuleiro.COLUNA; j++) {
				matriz += "   " + tabuleiro.matrizTabuleiro [i, j];
			}
			matriz += "\n";
		}
		texto.text = matriz;
	}

}
