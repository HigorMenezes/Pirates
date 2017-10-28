using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Moviment {

	public enum MoveType {
		attack,
		move
	};

	public Vector2 pos { get; set;}
	public MoveType moveType { get; set;}

	public Moviment(Vector2 pos, MoveType moveType){
		this.pos = pos;
		this.moveType = moveType;
	}
}
