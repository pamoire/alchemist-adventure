﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CraftingScript : MonoBehaviour {
	public 	List<StatClass> items;
	public float cauldronCD;
	//playerinventory need to be changed based on quest selection
	string[] PlayerInv = {"Water", "Oil", "Wine", "Herb", "Mushroom","Venom"};
	int[] invcount = {5,5,5,5,5,5} ;
	StatClass PlayerPTN;
	bool haspotion = false;
	bool cancraft = true;
	
	//For Potion instance
	private GameObject _instance;
	public GameObject POTIONprefab;
	public Transform cauldron;
	public Sprite HP;
	public Sprite ATK;
	public Sprite CURE;

	//For selecting Ingredient
	public TMP_Text[] itemText = new TMP_Text[3];
	public Image[] itemImage = new Image[3];
	string[] Item = new string[3];
	public GameObject[] Box = new GameObject[3];
	
	// Use this for initialization
	void Start () {
        items = new List<StatClass>();

        items.Add(new StatClass("Water", 0, 0, "BASE", 0, 2));
        items.Add(new StatClass("Oil", 0, 1, "BASE", 0, 0));
        items.Add(new StatClass("Wine", 0, 2, "BASE", 0, 7));
        items.Add(new StatClass("Herb", 2, 0, "HP", 10, 5));
        items.Add(new StatClass("Venom", 0, 0, "PSN", 15, 7));
        items.Add(new StatClass("Mushroom", 0, 1, "ATK", 15, 0));
		items.Add(new StatClass("WTRhrb", 2, 0, "POTION", 10, 0));
		items.Add(new StatClass("OILhrb", 2, 0, "POTION", 10, 0));
		items.Add(new StatClass("WINhrb", 4, 0, "POTION", 10, 0));
		items.Add(new StatClass("WTRpow", 0, 2, "POTION", 15, 0));
		items.Add(new StatClass("OILpow", 0, 2, "POTION", 15, 0));
		items.Add(new StatClass("WINpow", 0, 3, "POTION", 15, 0));
		items.Add(new StatClass("WTRVen", 0, 0, "PSN", 15, 0));
		items.Add(new StatClass("WINVen", 0, 0, "PSNRES", 15, 0));
		items.Add(new StatClass("OILVen", 0, 0, "PSN", 15, 0));
		
		//ingredient class needed
		/*for (int x = 0; x < 6;x ++);
		{
			for (int y = 0; y < ingredient.Count; y++)
			{
				if(ingredient[y].Name? == PlayerInv[x])
				{				
					invcount[x] = ingredient[y].amount?;
				}
			}
		}*/
			
	}
	
	void Update () {
			/*player inventory
		for(int x = 0; x < 5; x++)
		{
			Debug.Log(PlayerInv[x]);
			Debug.Log(invcount[x]);
		}*/
		
			//need visual indicator of timer
		
		cauldronCD -= Time.deltaTime;
		
	}
	//which potion is it
	StatClass getitembyID(string Name)
	{
		foreach (StatClass item in items)
		{
			//Debug.Log(item.NAME + Name);
			if(item.NAME == Name)
			{
				//Debug.Log(item.NAME);
				return item;
			}
		}
		return null;
	}
	
	//asign potion
    public void Craft(string BASE, string frsting,string scnding)
    {
		StatClass potion = null;
      if(BASE == "Water")
		{
			if(frsting == "Herb")
			{
			potion = getitembyID("WTRhrb");
			POTIONprefab.GetComponent<Image>().sprite = HP;
			invcount[3] -=1;
			}
			else if(frsting == "Mushroom")
			{
			potion = getitembyID("WTRpow");
			POTIONprefab.GetComponent<Image>().sprite = ATK;
			invcount[4] -=1;
			}
			else if(frsting == "Venom" && scnding != "")
			{
			potion = getitembyID("WTRVen");
			POTIONprefab.GetComponent<Image>().sprite = CURE;
			invcount[5] -=1;
			for(int x = 0; x < 6;x++)
				{

					if(scnding == PlayerInv[x])
					{
						invcount[x] -=1;
					}
				}
			}
		invcount[0] -=1;
		}
		else if(BASE == "Wine")
		{
			if(frsting == "Herb")
			{
				potion = getitembyID("WINhrb");
				POTIONprefab.GetComponent<Image>().sprite = HP;
				invcount[3] -=1;
			}
			else if(frsting == "Mushroom")
			{
				potion = getitembyID("WINpow");
				POTIONprefab.GetComponent<Image>().sprite = ATK;
				invcount[4] -=1;
			}
			else if(frsting == "Venom")
			{
				potion = getitembyID("WINVen");
				POTIONprefab.GetComponent<Image>().sprite = CURE;
				invcount[5] -=1;
				for(int x = 0; x < 6;x++)
				{

					if(scnding == PlayerInv[x])
					{
						invcount[x] -=1;
					}
				}
			}
		invcount[2] -=1;  
		}
		else if(BASE == "Oil")
		{
			//oil need visual indicator to inform player if he got a bad or good result
			int oilRDM;
			oilRDM = Random.Range(0,2);
		  
		  
		
		if(frsting == "Herb")
		{
			potion = getitembyID("OILhrb");
			
			if(oilRDM == 0)
			{
			potion.HP = 0;
			}
			else if(oilRDM == 1)
			{
			potion.HP = 2;
			}
			else if(oilRDM == 2)
			{
			potion.HP = 3;
			}
			POTIONprefab.GetComponent<Image>().sprite = HP;
			invcount[3] -=1;
		}
		else if(frsting == "Mushroom")
		{
			potion = getitembyID("OILpow");
			if(oilRDM == 0)
			{
			potion.PWR = 1;
			}
			else if(oilRDM == 1)
			{
			potion.PWR = 2;
			}
			else if(oilRDM == 2)
			{
			potion.PWR = 3;
			}
			POTIONprefab.GetComponent<Image>().sprite = ATK;
			invcount[4] -=1;
		}
		else if(frsting == "Venom" && scnding != "")
		{
			potion = getitembyID("OILVen");
			if(oilRDM == 0)
			{
			potion.STATUS = "NA";
			}
			else if(oilRDM == 1)
			{
			potion.STATUS = "PSN";
			}
			else if(oilRDM == 2)
			{
			potion.STATUS = "PSNRES";
			}
			POTIONprefab.GetComponent<Image>().sprite = CURE;
			invcount[5] -=1;
			for(int x = 0; x < 6;x++)
			{

				if(scnding == PlayerInv[x])
				{
					invcount[x] -=1;
				}
			}
			
		
		}
		invcount[1] -=1;
		}
		//need function to give hero script the potion
		PlayerPTN = potion;		
		//cauldron cooldown
		cauldronCD = potion.SPD;

		

		//Debug.Log("Success " + BASE + frsting + scnding + PlayerPTN.NAME);
	}
		
	
		//temporarily disabled until merge; must be triggered in Hero list
		/*
		public void giveHero()
		{
			string buttonname = EventSystem.current.currentSelectedGameObject.name;
			StatClass Hero;
			for(int x = 0; x < items.Count;x++)
			{
				if(Heroes[x].NAME == buttonname)
				{
					Hero = items[x];
				}
			}	
			UsePotion(Hero, PlayerPTN);
			
		}
		*/
		//temp use potion
		public void tempUse()
		{
			Destroy(_instance);
			haspotion = false;
		}
		
		
	
		public void UsePotion(StatClass Hero, StatClass Potion)
		{
			if(Potion.STATUS == "POTION")
			{
				Hero.HP += Potion.HP;
				Destroy (POTIONprefab);
				haspotion = false;
				//need limiter to not exceed maxHP
			}
			else if(Potion.STATUS == "PSN")
			{
				Hero.STATUS = "NA";
				Destroy (POTIONprefab);
				haspotion = false;
			}
			else if(Potion.STATUS == "PSNRES")
			{
				Hero.STATUS = "PSNRES";
				//resistance only lasts 1 turn
			}				
			else if(Potion.STATUS == "ATK")
			{
				Hero.PWR += Potion.PWR;
				Destroy (POTIONprefab);
				haspotion = false;
				//need variable to reset PWR to normal after next attack
			}
		}
		
		
		
		//selectin item.
	
		public void SelectBase()
		{
			for (int x = 0; x < 3; x++)
			{

			Item[x] = itemText[x].text;
			Box[x].GetComponent<Image>().sprite = itemImage[x].sprite;
			//Debug.Log(Item[x]);

			}
		}
		public void OnMix()
		{
			for (int x = 0; x < 3; x++)
			{

			Item[x] = itemText[x].text;
			Box[x].GetComponent<Image>().sprite = itemImage[x].sprite;
			//Debug.Log(Item[x]);

			}
			for (int y = 0; y < 3; y++)
			{
				for(int x = 0; x < 6; x++)
				{
					if(PlayerInv[x] == Item[y])
					{
						if(invcount[x] > 0)
						{
							cancraft = true;
							Debug.Log(PlayerInv[x] + invcount[x]);
						}
						else
						{
							cancraft = false;
							Debug.Log("Not Enough " + Item[y]);
							return;
						}
					}
				}
			}
			if(haspotion == false && cancraft == true && cauldronCD <= 0 )
			{
			Craft(Item[0],Item[1],Item[2]);
			
			
			_instance = Instantiate(POTIONprefab);
			_instance.transform.SetParent(cauldron);
			_instance.transform.localPosition = new Vector2(1f,1f);
			haspotion = true;
			//need visual indication for how much ingredients was used. (Eg, "-1" floating over used items or images of used items moving into the cauldron)
			}
			else if(haspotion == true)
			{
				//need to be replace with visual indicators
				Debug.Log("Plz use potion");
			}
			else if(cauldronCD > 0)
			{
				//need to be replace with visual indicators
				Debug.Log("Please wait " + cauldronCD + " before crafting a new potion");
			}
			else
			{
				Debug.Log("sumthing wrong?" + haspotion + cauldronCD + cancraft);
			}
		}
}