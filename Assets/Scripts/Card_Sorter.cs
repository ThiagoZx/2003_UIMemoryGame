using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Sorter : MonoBehaviour {

	public GameObject Grid;
	public GameObject SrtGrid;
	private string type;
	//private string[] rdColors = new string[18];
	private List<string> rdColors = new List<string>();

	void Awake () {
		Fill ();
	}

	void SortCards(){
		int index = 0;
		rdColors.Sort ();

		for(int i = 0; i < rdColors.Count; i++){

			if(Grid.GetComponentInChildren<Button>().tag == "Untagged"){
				Grid.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = rdColors[index];
				Grid.GetComponentInChildren<Button>().transform.parent = SrtGrid.transform;
			}

			index++;

		}

	}

	void Fill(){

		for (int i = 0; i < 9; i++) {
			Color rdColor = new Color(Random.value, Random.value, Random.value, 1.0f);

			string a = "Cod" + rdColor.ToString();
			string b = "Col" + rdColor.ToString();

			rdColors.Add(a);
			rdColors.Add(b);
		}

		SortCards ();
	}

}