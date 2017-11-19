using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MiniMax {

	public static float seach(Nodo raiz){

		Stack stack = new Stack ();

		Nodo currentNode = raiz;

		do {

			if (currentNode.Value.Equals(float.NaN)){
				foreach(Nodo nodo in currentNode.Children){
					nodo.Father = currentNode;
					stack.Push(nodo);
				}
			}else{
				float value = currentNode.Value;
				Nodo father = currentNode.Father;
				Nodo ancestral;

				if (father != null){
					if (father.Value.Equals(float.NaN)){
						father.Value = value;
					}else if (father.MaxMin.Equals(Nodo.MaxOrMin.max)){
						if (value > father.Value){
							father.Value = value;
						}
					}else if (father.MaxMin.Equals(Nodo.MaxOrMin.min)){
						if (value < father.Value){
							father.Value = value;
						}
					}


					ancestral = father.Father;

					while (ancestral != null){

						if (father.MaxMin.Equals(Nodo.MaxOrMin.max)){
						
							if (ancestral.MaxMin.Equals(Nodo.MaxOrMin.min)
								&& ancestral.Value <= father.Value){

								while(stack.Pop() != father){
								}
								stack.Push(father);

							}

						}else {

							if (ancestral.MaxMin.Equals(Nodo.MaxOrMin.max)
								&& ancestral.Value >= father.Value){

								while(stack.Pop() != father){
								}
								stack.Push(father);

							}

						}

						ancestral = ancestral.Father;

					}

				}

			}

			if (stack.Count > 0){
				Nodo last = (Nodo) stack.Pop();
				stack.Push(last);
				if (last.Value.Equals(float.NaN)){
					currentNode = last;
				}else{
					currentNode = (Nodo) stack.Pop();
				}
			}else{
				currentNode = null;
			}


		}while(currentNode != null);

		return raiz.Value;

	}

}
