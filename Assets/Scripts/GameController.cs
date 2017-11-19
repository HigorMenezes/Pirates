using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public enum Current{
		Red,
		Blue,
		Movement
	}

	public Text text;

	public static int playerRed = 9;
	public static int treasureRed = 8;
	public static int playerBlue = 1;
	public static int treasureBlue = 2;

	public static Current currentTurn;
	public static Current previousCurrent;
	public static Table table = null;


	void Start () {
		switch (Random.Range (0, 2)) {
		case 0:
			currentTurn = Current.Blue;
			break;
		case 1:
			currentTurn = Current.Red;
			break;
		}

		previousCurrent = currentTurn;
			
		table = new Table(defaultTable());

	}


	void Update () {
		debugMatrix ();
	}

	public static void changeCurrent (){
		if (previousCurrent.Equals (Current.Blue)) {
			currentTurn = Current.Red;
		}else if (previousCurrent.Equals (Current.Red)) {
			currentTurn = Current.Blue;
		}

		previousCurrent = currentTurn;
	}

	public int[,] defaultTable (){
		return new int[,] {
			{ 0, 0, 			treasureRed, 	0, 			0 },
			{ 0, playerRed, 	0, 			playerRed, 	0 },
			{ 0, 0, 			0, 			0, 			0 },
			{ 0, 0, 			0, 			0, 			0 },
			{ 0, 0, 			0, 			0, 			0 },
			{ 0, playerBlue, 	0, 			playerBlue, 0 },
			{ 0, 0, 			treasureBlue, 0, 			0 },
		};
	}

	public void debugMatrix (){
		string textMatrix = "";
		int[,] matrix = table.TableMatrix;
		for (int i = 0; i < Table.LINE; i++) {
			for (int j = 0; j < Table.COLUMN; j++) {
				textMatrix += "   " + matrix [i, j];
			}
			textMatrix += "\n";
		}
		text.text = textMatrix;
	}

}
