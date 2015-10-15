using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Card_Sorter : MonoBehaviour {

	public GameObject Grid;
	public GameObject SrtGrid;
	private string type;
	private List<string> rdColors = new List<string>();

	void Awake () {
		Fill ();
	}

	void SortCards(){
		int index = 0;

		for (int i = 0; i < rdColors.Count; i++) {
			string temp = rdColors[i];
			int randomIndex = Random.Range(i, rdColors.Count);
			rdColors[i] = rdColors[randomIndex];
			rdColors[randomIndex] = temp;
		}
		
		for(int i = 0; i < rdColors.Count; i++){

			if(Grid.GetComponentInChildren<Button>().tag == "Untagged"){
				Grid.GetComponentInChildren<Button>().GetComponentInChildren<Text>().text = rdColors[index];
				Grid.GetComponentInChildren<Button>().transform.parent = SrtGrid.transform;
			}

			index++;

		}

	}

	void Fill(){

		string dificulty = "easy";//PlayerPrefs.GetString ("dificulty"); 
		List<string> clrs = GetComponent<ColorLibrary> ().gameSort(dificulty);

		for (int i = 0; i < 9; i++) {
			
			string code = "#" + clrs[i];
			string color = "C" + clrs[i];

			rdColors.Add(code);
			rdColors.Add(color);

		}

		SortCards ();
	}

	void Update(){
		if (SrtGrid.GetComponentInChildren<Button> () == null) {
			Application.LoadLevel (0);
		}
	}

}
