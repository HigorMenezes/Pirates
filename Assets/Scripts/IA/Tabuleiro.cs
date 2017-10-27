using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Tabuleiro{

	public const int LINHA = 7; 
	public const int COLUNA = 5;

	public int[,] matrizTabuleiro { get; set;}

	public Tabuleiro(){
		matrizTabuleiro = new int[LINHA, COLUNA] {
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
		};
	}
}
