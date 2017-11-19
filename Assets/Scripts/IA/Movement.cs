using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Movement {

	public enum Move {
		attack,
		move,
		win
	}
		
	private Vector2 from;
	private Vector2 to;
	private Move moveType;

	public Movement (Vector2 from, Vector2 to, Move moveType){
		this.from = from;
		this.to = to;
		this.moveType = moveType;
	}

	public Vector2 From {
		get {
			return this.from;
		}
		set {
			from = value;
		}
	}

	public Vector2 To {
		get {
			return this.to;
		}
		set {
			to = value;
		}
	}

	public Move MoveType {
		get {
			return this.moveType;
		}
		set {
			moveType = value;
		}
	}

	public Movement clone(){

		Movement movement = new Movement (from, to, moveType);

		return movement;

	}

	public string toString(){
		return "From: " + from + " To: " + to + " MOVE: " + moveType;
	}

}
