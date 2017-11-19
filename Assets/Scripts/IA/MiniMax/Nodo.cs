using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Nodo {

	public enum MaxOrMin {
		max,
		min
	}
		
	private string nome;
	private float fUtility;
	private Nodo father;
	private ArrayList children = new ArrayList();
	private MaxOrMin maxMin;
	private Table table = new Table();
	private Movement movement;

	public Nodo (){
		fUtility = float.NaN;
		father = null;
		children.Clear ();
	}

	public string Nome {
		get {
			return this.nome;
		}
		set {
			nome = value;
		}
	}

	public float Value {
		get {
			return this.fUtility;
		}
		set {
			fUtility = value;
		}
	}

	public Nodo Father {
		get {
			return this.father;
		}
		set {
			father = value;
		}
	}

	public ArrayList Children {
		get {
			return this.children;
		}
		set {
			children = value;
		}
	}

	public MaxOrMin MaxMin {
		get {
			return this.maxMin;
		}
		set {
			maxMin = value;
		}
	}

	public Table Table {
		get {
			return this.table;
		}
		set {
			table = value;
		}
	}
	public Movement Movement {
		get {
			return this.movement;
		}
		set {
			movement = value;
		}
	}
}
