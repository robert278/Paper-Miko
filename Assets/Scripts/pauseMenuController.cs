using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenuController : MonoBehaviour
{
	//HOW THIS WORKS, EACH TAB IS HIGHLIGHTED BY A BACKGROUND GAMEOBJECT, BASED ON BUTTONS PRESSED IT WILL EITHER SetActive(true) or SetActive(false)
	//USE ITEM AND ACQUIRE ITEM NEED TO BE CREATED

	[SerializeField]
	private GameObject PlayerTab; //ALSO keeps track of partner rankings

	//You can swap partners with Q -- no partner info tab

	[SerializeField]
	private GameObject ItemTab;
	[SerializeField]
	private GameObject ButtonsTab; //Buttons = Badges
	[SerializeField]
	private GameObject DeckTab;
	[SerializeField]
	private GameObject LogbookTab; //Enemy Bestiary, MacGuffins Collected, Map, etc. 

	[SerializeField]
	private GameObject cursor1;
	//[SerializeField]
	private GameObject cursor2;
	[SerializeField]
	private GameObject cursor3;
	[SerializeField]
	private GameObject cursor4;
	[SerializeField]
	private GameObject cursor5;

	//The thing you collided with becomes what replaces empty item slot. Then checks for if statements on the item name for what effect it has
	[SerializeField]
	private GameObject item1;
	[SerializeField]
	private GameObject item2;
	[SerializeField]
	private GameObject item3;
	[SerializeField]
	private GameObject item4;
	[SerializeField]
	private GameObject item5;
	[SerializeField]
	private GameObject item6;
	[SerializeField]
	private GameObject item7;
	[SerializeField]
	private GameObject item8;
	[SerializeField]
	private GameObject item9;
	[SerializeField]
	private GameObject item10;

	[SerializeField]
	private GameObject itemDescriptionBox;
	[SerializeField]
	private GameObject itemSelectedHighlighter;

	[SerializeField]
	private Sprite Sushi5Desc;
	[SerializeField]
	private Sprite LightningDesc;
	[SerializeField]
	private Sprite defaultNoItemSprite;

	private bool isAnyTabOpen = false;
	private bool selectingInItemMenu = false;
	private Sprite defaultSprite;

	private int currentItemSelected = 1; //Always starts at 1
	private float waitingTimeAgain = 0.0f;

	void Start(){
		defaultSprite = itemDescriptionBox.GetComponent<SpriteRenderer>().sprite;
	}

    // Update is called once per frame
    void Update()
    {
		waitingTimeAgain += 0.125f;
		if(Time.timeScale == 0f){
			if(Input.GetKeyDown(KeyCode.RightArrow) && isAnyTabOpen == false){
				
				//Swap Tab Right
				if(PlayerTab.activeSelf == true){
					PlayerTab.SetActive(false);
					ItemTab.SetActive(true);
				} else if (ItemTab.activeSelf == true){
					ItemTab.SetActive(false);
					ButtonsTab.SetActive(true);
				} else if (ButtonsTab.activeSelf == true){
					ButtonsTab.SetActive(false);
					DeckTab.SetActive(true);
				} else if (DeckTab.activeSelf == true){
					DeckTab.SetActive(false);
					LogbookTab.SetActive(true);
				} else if (LogbookTab.activeSelf == true){
					LogbookTab.SetActive(false);
					PlayerTab.SetActive(true);
				}

			}
			if(Input.GetKeyDown(KeyCode.LeftArrow) && isAnyTabOpen == false){
				//Swap Tab Left

				if(PlayerTab.activeSelf == true){
					PlayerTab.SetActive(false);
					LogbookTab.SetActive(true);
				} else if (ItemTab.activeSelf == true){
					ItemTab.SetActive(false);
					PlayerTab.SetActive(true);
				} else if (ButtonsTab.activeSelf == true){
					ButtonsTab.SetActive(false);
					ItemTab.SetActive(true);
				} else if (DeckTab.activeSelf == true){
					DeckTab.SetActive(false);
					ButtonsTab.SetActive(true);
				} else if (LogbookTab.activeSelf == true){
					LogbookTab.SetActive(false);
					DeckTab.SetActive(true);
				}

			}
			if(Input.GetKeyDown(KeyCode.Z) && isAnyTabOpen == false){
				waitingTimeAgain = 0.0f;

				isAnyTabOpen = true;
				//Go into that menu

				if(PlayerTab.activeSelf == true){
					cursor1.SetActive(true);
				} else if (ItemTab.activeSelf == true){
					
					itemSelectedHighlighter.SetActive(true);
					selectingInItemMenu = true;

				} else if (ButtonsTab.activeSelf == true){
					cursor3.SetActive(true);
				} else if (DeckTab.activeSelf == true){
					cursor4.SetActive(true);
				} else if (LogbookTab.activeSelf == true){
					cursor5.SetActive(true);
				}

			}
			if(Input.GetKeyDown(KeyCode.X) && isAnyTabOpen == true){
				//Go back to 'swap tab' mode
				isAnyTabOpen = false;


				if(PlayerTab.activeSelf == true){
					cursor1.SetActive(false);
				} else if (ItemTab.activeSelf == true){

					itemSelectedHighlighter.SetActive(false);
					selectingInItemMenu = false;

				} else if (ButtonsTab.activeSelf == true){
					cursor3.SetActive(false);
				} else if (DeckTab.activeSelf == true){
					cursor4.SetActive(false);
				} else if (LogbookTab.activeSelf == true){
					cursor5.SetActive(false);
				}

			}

			//ITEM MENU CONTROLS
			if(selectingInItemMenu == true){

				//PRESSING THE RIGHT ARROW OR LEFT ARROW IN THE MENU
				if((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 1){
					itemSelectedHighlighter.transform.position += new Vector3(3.65f + 1.97f, 0.0f, 0.0f);
					currentItemSelected = 2;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 2){
					itemSelectedHighlighter.transform.position += new Vector3(-3.65f - 1.97f, 0.0f, 0.0f);
					currentItemSelected = 1;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 3){
					itemSelectedHighlighter.transform.position += new Vector3(3.65f + 1.97f, 0.0f, 0.0f);
					currentItemSelected = 4;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 4){
					itemSelectedHighlighter.transform.position += new Vector3(-3.65f - 1.97f, 0.0f, 0.0f);
					currentItemSelected = 3;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 5){
					itemSelectedHighlighter.transform.position += new Vector3(3.65f + 1.97f, 0.0f, 0.0f);
					currentItemSelected = 6;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 6){
					itemSelectedHighlighter.transform.position += new Vector3(-3.65f + -1.97f, 0.0f, 0.0f);
					currentItemSelected = 5;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 7){
					itemSelectedHighlighter.transform.position += new Vector3(3.65f + 1.97f, 0.0f, 0.0f);
					currentItemSelected = 8;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 8){
					itemSelectedHighlighter.transform.position += new Vector3(-3.65f + -1.97f, 0.0f, 0.0f);
					currentItemSelected = 7;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 9){
					itemSelectedHighlighter.transform.position += new Vector3(3.65f + 1.97f, 0.0f, 0.0f);
					currentItemSelected = 10;
				} else if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)) && currentItemSelected == 10){
					itemSelectedHighlighter.transform.position += new Vector3(-3.65f + -1.97f, 0.0f, 0.0f);
					currentItemSelected = 9;
				}

				//PRESSING THE DOWN ARROW IN THE MENU
				if(Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 1){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 3;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 2){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 4;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 3){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 5;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 4){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 6;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 5){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 7;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 6){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 8;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 7){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 9;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 8){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, -0.84867f - 0.2f, 0.0f);
					currentItemSelected = 10;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 9){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 4.0f * (0.84867f + 0.2f), 0.0f);
					currentItemSelected = 1;
				} else if (Input.GetKeyDown(KeyCode.DownArrow) && currentItemSelected == 10){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 4.0f * (0.84867f + 0.2f), 0.0f);
					currentItemSelected = 2;
				}

				//PRESSING THE UP ARROW IN THE MENU
				if(Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 1){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 4 * (-0.84867f - 0.2f), 0.0f);
					currentItemSelected = 9;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 2){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 4 * (-0.84867f - 0.2f), 0.0f);
					currentItemSelected = 10;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 3){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 1;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 4){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 2;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 5){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 3;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 6){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 4;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 7){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 5;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 8){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 6;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 9){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 7;
				} else if (Input.GetKeyDown(KeyCode.UpArrow) && currentItemSelected == 10){
					itemSelectedHighlighter.transform.position += new Vector3(0.0f, 0.84867f + 0.2f, 0.0f);
					currentItemSelected = 8;
				}




				//ITEM DESCRIPTIONS
				if(currentItemSelected == 1){
					//cause description box for 1 to appear
					if(item1.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item1.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}

				} else if (currentItemSelected == 2){
					if(item2.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item2.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 3){
					if(item3.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item3.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 4){
					if(item4.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item4.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 5){
					if(item5.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item5.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 6){
					if(item6.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item6.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 7){
					if(item7.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item7.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 8){
					if(item8.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item8.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 9){
					if(item9.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item9.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				} else if (currentItemSelected == 10){
					if(item10.name == "Sushi5"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = Sushi5Desc;
					} else if (item10.name == "Lightning"){
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = LightningDesc;
					} else {
						itemDescriptionBox.GetComponent<SpriteRenderer>().sprite = defaultSprite;
					}
				}






				//USE ITEM [There are no Partners, so all items instant target -- unless specifics in battle
					//REMEMBER "AFTER AN ITEM IS USED, REMOVE IT FROM INVENTORY AND SHIFT ALL ITEMS "DOWN" A SLOT ABOVE IT
				if(Input.GetKeyDown(KeyCode.Z) && waitingTimeAgain > 0.25f){
					waitingTimeAgain = 0.0f;
					if (currentItemSelected == 1){
						if(item1.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item1.name == "Sushi5"){
							//heal 5 damage to yourself
						}
						item1.GetComponent<SpriteRenderer>().sprite = item2.GetComponent<SpriteRenderer>().sprite;
						item1.name = item2.name;
						item1.tag = item2.tag;
						item2.GetComponent<SpriteRenderer>().sprite = item3.GetComponent<SpriteRenderer>().sprite;
						item2.name = item3.name;
						item2.tag = item3.tag;
						item3.GetComponent<SpriteRenderer>().sprite = item4.GetComponent<SpriteRenderer>().sprite;
						item3.name = item4.name;
						item3.tag = item4.tag;
						item4.GetComponent<SpriteRenderer>().sprite = item5.GetComponent<SpriteRenderer>().sprite;
						item4.name = item5.name;
						item4.tag = item5.tag;
						item5.GetComponent<SpriteRenderer>().sprite = item6.GetComponent<SpriteRenderer>().sprite;
						item5.name = item6.name;
						item5.tag = item6.tag;
						item6.GetComponent<SpriteRenderer>().sprite = item7.GetComponent<SpriteRenderer>().sprite;
						item6.name = item7.name;
						item6.tag = item7.tag;
						item7.GetComponent<SpriteRenderer>().sprite = item8.GetComponent<SpriteRenderer>().sprite;
						item7.name = item8.name;
						item7.tag = item8.tag;
						item8.GetComponent<SpriteRenderer>().sprite = item9.GetComponent<SpriteRenderer>().sprite;
						item8.name = item9.name;
						item8.tag = item9.tag;
						item9.GetComponent<SpriteRenderer>().sprite = item10.GetComponent<SpriteRenderer>().sprite;
						item9.name = item10.name;
						item9.tag = item10.tag;
						item10.GetComponent<SpriteRenderer>().sprite = defaultNoItemSprite;
						item10.name = "item slot 10";
						item10.tag = "no item";

					} else if (currentItemSelected == 2){
						if(item2.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item2.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 3){
						if(item3.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item3.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 4){
						if(item4.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item4.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 5){
						if(item5.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item5.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 6){
						if(item6.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item6.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 7){
						if(item7.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item7.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 8){
						if(item8.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item8.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 9){
						if(item9.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item9.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					} else if (currentItemSelected == 10){
						if(item10.name == "Lightning"){
							//deal 5 damage to all enemies
						} else if (item10.name == "Sushi5"){
							//heal 5 damage to yourself
						}
					}
				}

			}
		}
    }
}
