using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Table {

	public const int LINE = 7;
	public const int COLUMN = 5;

	private int[,] table { get; set; }

	public Table (){
		table = new int[LINE, COLUMN]{
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
			{ 0, 0, 0, 0, 0 },
		};
	}

	public int[,] getTable(){
		return this.table;
	}
	public void setTable(int[,] table){
		this.table = table;
	}
		
}
