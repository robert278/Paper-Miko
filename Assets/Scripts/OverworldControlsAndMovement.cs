using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class OverworldControlsAndMovement : MonoBehaviour
{
	[SerializeField]
	private GameObject camera;
	[SerializeField]
	private GameObject battleCamera;

	[SerializeField]
	private GameObject ExtraBestiarySlotsHolder;

	[SerializeField]
	private GameObject sprite;
	[SerializeField]
	private GameObject flip;

	[SerializeField]
	private GameObject flipanim1;
	[SerializeField]
	private GameObject flipanim2;
	[SerializeField]
	private GameObject flipanim3;
	[SerializeField]
	private GameObject flipanim4;
	[SerializeField]
	private GameObject flipanim5;

	[SerializeField]
	private GameObject notflip;
	[SerializeField]
	private float _speed;
	[SerializeField]
	private GameObject respawnLocation;
	[SerializeField]
	private GameObject PauseMenu;

	//INVENTORY ITEMS
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
	private GameObject battleStartPositionPlayer;
	[SerializeField]
	private GameObject battleUI;
	[SerializeField]
	private GameObject battleMenuLower;

	[SerializeField]
	private GameObject battleMenuMalletOptionSelected;
	[SerializeField]
	private GameObject battleMenuBulletOptionSelected;
	[SerializeField]
	private GameObject battleMenuTacticsOptionSelected;
	[SerializeField]
	private GameObject battleMenuItemsOptionSelected;

	//REMEMBER TO REPLACE THE HORRIBLE CLIP ART
	[SerializeField]
	private GameObject battleMenuItemText;
	[SerializeField]
	private GameObject battleMenuItemIcon;
	[SerializeField]
	private GameObject battleMenuMalletText;
	[SerializeField]
	private GameObject battleMenuMalletIcon;
	[SerializeField]
	private GameObject battleMenuBulletText;
	[SerializeField]
	private GameObject battleMenuBulletIcon;
	[SerializeField]
	private GameObject battleMenuTacticsText;
	[SerializeField]
	private GameObject battleMenuTacticsIcon;

	[SerializeField]
	private GameObject attackMenuMallet;
	[SerializeField]
	private GameObject attackMenuItem;
	[SerializeField]
	private GameObject attackMenuTactics;
	[SerializeField]
	private GameObject attackMenuBullet;

	//just stores location and 'swaps out sprite' -- based on enemy name, certain parameters will be hardcoded in
	//Examples include: Enemy Health, Enemy Attack Pattern, [Time it takes for Jump Command to hit] if jump is implemented.

	[SerializeField]
	private GameObject enemySlot0; //add or subtract to the Y in the transform for Medium/Tall enemies
	[SerializeField]
	private GameObject enemySlot1;
	[SerializeField]
	private GameObject enemySlot2;
	[SerializeField]
	private GameObject enemySlot3;
	[SerializeField]
	private GameObject enemySlot4;

	[SerializeField]
	private GameObject demoSuika;
	[SerializeField]
	private GameObject demoCube;

	[SerializeField]
	private GameObject enemyPointer;

	[SerializeField]
	private GameObject crosshairBullet;

	[SerializeField]
	private GameObject fontNumber0e1;
	[SerializeField]
	private GameObject fontNumber1e1;
	[SerializeField]
	private GameObject fontNumber2e1;
	[SerializeField]
	private GameObject fontNumber3e1;
	[SerializeField]
	private GameObject fontNumber4e1;
	[SerializeField]
	private GameObject fontNumber5e1;
	[SerializeField]
	private GameObject fontNumber6e1;
	[SerializeField]
	private GameObject fontNumber7e1;
	[SerializeField]
	private GameObject fontNumber8e1;
	[SerializeField]
	private GameObject fontNumber9e1;

	[SerializeField]
	private GameObject fontNumber0e2;
	[SerializeField]
	private GameObject fontNumber1e2;
	[SerializeField]
	private GameObject fontNumber2e2;
	[SerializeField]
	private GameObject fontNumber3e2;
	[SerializeField]
	private GameObject fontNumber4e2;
	[SerializeField]
	private GameObject fontNumber5e2;
	[SerializeField]
	private GameObject fontNumber6e2;
	[SerializeField]
	private GameObject fontNumber7e2;
	[SerializeField]
	private GameObject fontNumber8e2;
	[SerializeField]
	private GameObject fontNumber9e2;

	[SerializeField]
	private GameObject fontNumber0e3;
	[SerializeField]
	private GameObject fontNumber1e3;
	[SerializeField]
	private GameObject fontNumber2e3;
	[SerializeField]
	private GameObject fontNumber3e3;
	[SerializeField]
	private GameObject fontNumber4e3;
	[SerializeField]
	private GameObject fontNumber5e3;
	[SerializeField]
	private GameObject fontNumber6e3;
	[SerializeField]
	private GameObject fontNumber7e3;
	[SerializeField]
	private GameObject fontNumber8e3;
	[SerializeField]
	private GameObject fontNumber9e3;

	[SerializeField]
	private GameObject fontNumber0e0;
	[SerializeField]
	private GameObject fontNumber1e0;
	[SerializeField]
	private GameObject fontNumber2e0;
	[SerializeField]
	private GameObject fontNumber3e0;
	[SerializeField]
	private GameObject fontNumber4e0;
	[SerializeField]
	private GameObject fontNumber5e0;
	[SerializeField]
	private GameObject fontNumber6e0;
	[SerializeField]
	private GameObject fontNumber7e0;
	[SerializeField]
	private GameObject fontNumber8e0;
	[SerializeField]
	private GameObject fontNumber9e0;

	[SerializeField]
	private AudioSource noice;
	[SerializeField]
	private AudioSource blockSFX; //airhorn?

	[SerializeField]
	private GameObject blockingText;
	[SerializeField]
	private GameObject noiceText;
	[SerializeField]
	private GameObject wowText;

	[SerializeField]
	private GameObject basicBulletText;

	private GameObject enemyClone0;
	private GameObject enemyClone1;
	private GameObject enemyClone2;
	private GameObject enemyClone3;
	private GameObject enemyClone4;

	private bool collisionWithWall = false;
	private bool flipped = false;
	private float waitTime = 1.5f; //THIS IS THE COOLDOWN FOR YOUR "FLIP" BUTTON
	private float timer = 0.0f;
	private Vector3 movement = Vector3.zero;
	private Rigidbody rb;
	private float jumpCooldown = 0.2f;
	private float startTime = 0.0f;
	private float GroundedTimer = 0.0f;
	private float anotherTimer = 0.0f;
	private float isNotSpammingTimer = 0.0f; //no spamming menu because rotation breaks
	private float secondNotSpammingTimer = 0.0f;

	private bool menuOpened = false;
	private bool PartnerOrPlayerAttacked = false;
	private bool HavePartner = false; //This becomes true when the story 'gives' you a partner
	private bool battleMenuOneOpen = false;

	private bool enemySelectItemsOpen = false;
	private bool enemySelectTacticsOpen = false;
	private bool enemySelectBulletOpen = false;
	private bool enemySelectMalletOpen = false;

	private bool buttonPressedAlready = false;
	private bool commandSuccess = false;
	private bool ActionCommandMinigameBulletFinished = true;
	private bool ActionCommandMinigameMalletFinished = true;

	private bool enemy0checked = false;
	private bool enemy1checked = false;
	private bool enemy2checked = false;
	private bool enemy3checked = false;
	private bool enemy4checked = false;

	private bool enemy0attacking = false;
	private bool enemy1attacking = false;
	private bool enemy2attacking = false;
	private bool enemy3attacking = false;
	private bool enemy4attacking = false;

	private bool blocking = false;
	private bool canBlockAgain = true;
	[SerializeField]
	private Sprite blockingSprite;

	private bool inBattle = false; //BATTLE CONTROLS EXIST HERE TOO
	private bool battleTransitionFinished = false;
	private bool NO_FLIPPING_Because_CutSCenE = false;
	private string whoIsAttacking = "Player";
		
	private string enemy0 = "empty";
	private string enemy1 = "empty";
	private string enemy2 = "empty";
	private string enemy3 = "empty";
	private string enemy4 = "empty";

	private Sprite originalSprite;

	private string optionSelected = "";
	private string enemySlotSelected = "0"; //This string can be "ALL" for attacking all enemies
	private string previousMenu = "";
	private string attackSelected = "";
	private string activeAttack = "";

	private int healthEnemy0 = 0; //**Remember to 'delete' the enemy sprite if it's health is 0
	private int healthEnemy1 = 0;
	private int healthEnemy2 = 0; 
	private int healthEnemy3 = 0;
	private int healthEnemy4 = 0;

	[SerializeField]
	private GameObject drunkIcon0;
	[SerializeField]
	private GameObject drunkIcon1;
	[SerializeField]
	private GameObject drunkIcon2;
	[SerializeField]
	private GameObject drunkIcon3;

	private Vector3 beforeBattlePosition;

	private GameObject bulletImageInstantiated1;
	private GameObject bulletImageInstantiated2;

	[SerializeField]
	private GameObject bulletImage;
		
	[SerializeField]
	private GameObject XP_text;

	[SerializeField]
	private Text hpText;
	[SerializeField]
	private Text spText;
	[SerializeField]
	private Text expText;

	[SerializeField]
	private GameObject battleTransition1;

	[SerializeField]
	private GameObject allyDamage1;
	[SerializeField]
	private GameObject allyDamage2;
	[SerializeField]
	private GameObject allyDamage3;
	[SerializeField]
	private GameObject allyDamage4;
	[SerializeField]
	private GameObject allyDamage5;
	[SerializeField]
	private GameObject allyDamage6;
	[SerializeField]
	private GameObject allyDamage7;
	[SerializeField]
	private GameObject allyDamage8;
	[SerializeField]
	private GameObject allyDamage9;
	[SerializeField]
	private GameObject allyDamage10;

	[SerializeField]
	private GameObject enemyDamage1;
	[SerializeField]
	private GameObject enemyDamage2;
	[SerializeField]
	private GameObject enemyDamage3;
	[SerializeField]
	private GameObject enemyDamage4;
	[SerializeField]
	private GameObject enemyDamage5;
	[SerializeField]
	private GameObject enemyDamage6;
	[SerializeField]
	private GameObject enemyDamage7;
	[SerializeField]
	private GameObject enemyDamage8;
	[SerializeField]
	private GameObject enemyDamage9;
	[SerializeField]
	private GameObject enemyDamage10;

	private int playerHealth = 10; //game starts with player having 10 health, or on void Start, opening a file and replacing this with the file hp amount
	private int playerSP = 5; //start with 5 base SP
	private int playerEXP = 0; //start with 0 EXP
	private int maxHP = 10; //this can go up on level up
	private int maxSP = 5; //this can go up on level up

	void DeactivateFont0(){
		fontNumber0e0.SetActive(false);
		fontNumber1e0.SetActive(false);
		fontNumber2e0.SetActive(false);
		fontNumber3e0.SetActive(false);
		fontNumber4e0.SetActive(false);
		fontNumber5e0.SetActive(false);
		fontNumber6e0.SetActive(false);
		fontNumber7e0.SetActive(false);
		fontNumber8e0.SetActive(false);
		fontNumber9e0.SetActive(false);
	}

	void DeactivateFont1(){
		fontNumber0e1.SetActive(false);
		fontNumber1e1.SetActive(false);
		fontNumber2e1.SetActive(false);
		fontNumber3e1.SetActive(false);
		fontNumber4e1.SetActive(false);
		fontNumber5e1.SetActive(false);
		fontNumber6e1.SetActive(false);
		fontNumber7e1.SetActive(false);
		fontNumber8e1.SetActive(false);
		fontNumber9e1.SetActive(false);
	}

	void DeactivateFont2(){
		fontNumber0e2.SetActive(false);
		fontNumber1e2.SetActive(false);
		fontNumber2e2.SetActive(false);
		fontNumber3e2.SetActive(false);
		fontNumber4e2.SetActive(false);
		fontNumber5e2.SetActive(false);
		fontNumber6e2.SetActive(false);
		fontNumber7e2.SetActive(false);
		fontNumber8e2.SetActive(false);
		fontNumber9e2.SetActive(false);
	}

	void DeactivateFont3(){
		fontNumber0e3.SetActive(false);
		fontNumber1e3.SetActive(false);
		fontNumber2e3.SetActive(false);
		fontNumber3e3.SetActive(false);
		fontNumber4e3.SetActive(false);
		fontNumber5e3.SetActive(false);
		fontNumber6e3.SetActive(false);
		fontNumber7e3.SetActive(false);
		fontNumber8e3.SetActive(false);
		fontNumber9e3.SetActive(false);
	}



	void UpdateHealth(){
		if(healthEnemy0 == 9){
			DeactivateFont0();
			fontNumber9e0.SetActive(true);
		} else if(healthEnemy0 == 8){
			DeactivateFont0();
			fontNumber8e0.SetActive(true);
		} else if(healthEnemy0 == 7){
			DeactivateFont0();
			fontNumber7e0.SetActive(true);
		} else if(healthEnemy0 == 6){
			DeactivateFont0();
			fontNumber6e0.SetActive(true);
		} else if(healthEnemy0 == 5){
			DeactivateFont0();
			fontNumber5e0.SetActive(true);
		} else if(healthEnemy0 == 4){
			DeactivateFont0();
			fontNumber4e0.SetActive(true);
		} else if(healthEnemy0 == 3){
			DeactivateFont0();
			fontNumber3e0.SetActive(true);
		} else if(healthEnemy0 == 2){ 
			DeactivateFont0();
			fontNumber2e0.SetActive(true);
		} else if(healthEnemy0 == 1){ 
			DeactivateFont0();
			fontNumber1e0.SetActive(true);
		} else if(healthEnemy0 <= 0){ 
			DeactivateFont0();
			//fontNumber0e0.SetActive(true);
		}  

		if(healthEnemy1 == 9){
			DeactivateFont1();
			fontNumber9e1.SetActive(true);
		} else if(healthEnemy1 == 8){
			DeactivateFont1();
			fontNumber8e1.SetActive(true);
		} else if(healthEnemy1 == 7){
			DeactivateFont1();
			fontNumber7e1.SetActive(true);
		} else if(healthEnemy1 == 6){
			DeactivateFont1();
			fontNumber6e1.SetActive(true);
		} else if(healthEnemy1 == 5){
			DeactivateFont1();
			fontNumber5e1.SetActive(true);
		} else if(healthEnemy1 == 4){
			DeactivateFont1();
			fontNumber4e1.SetActive(true);
		} else if(healthEnemy1 == 3){
			DeactivateFont1();
			fontNumber3e1.SetActive(true);
		} else if(healthEnemy1 == 2){ 
			DeactivateFont1();
			fontNumber2e1.SetActive(true);
		} else if(healthEnemy1 == 1){ 
			DeactivateFont1();
			fontNumber1e1.SetActive(true);
		} else if(healthEnemy1 <= 0){ 
			DeactivateFont1();
			//fontNumber0e1.SetActive(true);
		}  
		 
		if(healthEnemy2 == 9){
			DeactivateFont2();
			fontNumber9e2.SetActive(true);
		} else if(healthEnemy2 == 8){
			DeactivateFont2();
			fontNumber8e2.SetActive(true);
		} else if(healthEnemy2 == 7){
			DeactivateFont2();
			fontNumber7e2.SetActive(true);
		} else if(healthEnemy2 == 6){
			DeactivateFont2();
			fontNumber6e2.SetActive(true);
		} else if(healthEnemy2 == 5){
			DeactivateFont2();
			fontNumber5e2.SetActive(true);
		} else if(healthEnemy2 == 4){
			DeactivateFont2();
			fontNumber4e2.SetActive(true);
		} else if(healthEnemy2 == 3){
			DeactivateFont2();
			fontNumber3e2.SetActive(true);
		} else if(healthEnemy2 == 2){ 
			DeactivateFont2();
			fontNumber2e2.SetActive(true);
		} else if(healthEnemy2 == 1){ 
			DeactivateFont2();
			fontNumber1e2.SetActive(true);
		} else if(healthEnemy2 <= 0){ 
			DeactivateFont2();
			//fontNumber0e2.SetActive(true);
		}  

		if(healthEnemy3 == 9){
			DeactivateFont3();
			fontNumber9e3.SetActive(true);
		} else if(healthEnemy3 == 8){
			DeactivateFont3();
			fontNumber8e3.SetActive(true);
		} else if(healthEnemy3 == 7){
			DeactivateFont3();
			fontNumber7e3.SetActive(true);
		} else if(healthEnemy3 == 6){
			DeactivateFont3();
			fontNumber6e3.SetActive(true);
		} else if(healthEnemy3 == 5){
			DeactivateFont3();
			fontNumber5e3.SetActive(true);
		} else if(healthEnemy3 == 4){
			DeactivateFont3();
			fontNumber4e3.SetActive(true);
		} else if(healthEnemy3 == 3){
			DeactivateFont3();
			fontNumber3e3.SetActive(true);
		} else if(healthEnemy3 == 2){ 
			DeactivateFont3();
			fontNumber2e3.SetActive(true);
		} else if(healthEnemy3 == 1){ 
			DeactivateFont3();
			fontNumber1e3.SetActive(true);
		} else if(healthEnemy3 <= 0){ 
			DeactivateFont3();
			//fontNumber0e3.SetActive(true);
		}  
	}
		
	IEnumerator blockingFctn(){
		print("Blocking");

		int frameCount;
		blocking = true;
		canBlockAgain = false;
		sprite.GetComponent<SpriteRenderer>().sprite = blockingSprite;
		frameCount = 8;
		while(frameCount > 0){
			frameCount--;
			yield return null;
		}
		yield return new WaitForSeconds(0);
		blocking = false;
		sprite.GetComponent<SpriteRenderer>().sprite = originalSprite;
		frameCount = 25;
		while(frameCount > 0){
			frameCount--;
			yield return null;
		}
		yield return new WaitForSeconds(0);
		canBlockAgain = true;
	}

	IEnumerator BattleTransition(){
		battleTransition1.SetActive(true);
		yield return new WaitForSeconds(1.0f);
		battleTransition1.SetActive(false);
		battleTransitionFinished = true;
	}

	IEnumerator StartBattle(string enemyType){ //enemyType will have a number next to it to represent what type of fight it was 
		//print("Start Battle");
		NO_FLIPPING_Because_CutSCenE = true;
		//Before Anything Happens, wait 0.5 seconds for a 'battle transition', here it is a four point star shrinking onto the player
						//-- for example "demoSuika1" might be vs a red and a green Suika while "demoSuika2" is vs a red blue and purple one.
		gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		sprite.transform.rotation = battleCamera.transform.rotation; //make player face camera if flipped
		gameObject.GetComponent<Rigidbody>().useGravity = false;

		StartCoroutine(BattleTransition());

		while(battleTransitionFinished == false){
			yield return new WaitForSeconds(0.1f);
		}

		battleTransitionFinished = false;
		inBattle = true;
		NO_FLIPPING_Because_CutSCenE = false;

		camera.SetActive(false);
		battleCamera.SetActive(true);
		beforeBattlePosition = gameObject.transform.position;
		gameObject.transform.position = battleStartPositionPlayer.transform.position;
		//activePartner.transform.position = battleStartPositionPartner
		battleUI.SetActive(true);

		//Using enemyType, spawn corresponding enemy
		if(enemyType == "demoSuika2"){
			//Enemy Spawn 2xSuika

			enemyClone1 = (GameObject)Instantiate(demoSuika, enemySlot1.transform.position, Quaternion.identity);
			enemyClone2 = (GameObject)Instantiate(demoSuika, enemySlot2.transform.position, Quaternion.identity);
			enemyClone1.name = "Suika";
			enemyClone2.name = "Suika";
			enemy1 = "Suika";//DemoSuika's always start off 3 turns drunk.
			enemy2 = "Suika";
			drunkIcon1.SetActive(true);
			drunkIcon2.SetActive(true);


			healthEnemy1 = 4;
			healthEnemy2 = 4;

		} else if (enemyType == "demoSuika2Crumpled") {
			//special case where the hammer collided with demoSuika1 then you get a first strike bonus on collision for battle
			Debug.Log("Enemy Suika Battle -- You Struck First");

		} else if (enemyType == "demoSuika2Attacking"){
			//Special case where you collided with demoSuika1's attacking collider. This case, a collider would be drawn around demoSuika1's fist.
			Debug.Log("Enemy Suika Battle -- Your Opponent Struck First");
				
		} else if (enemyType == "demoSuika3"){
			//Enemy Spawn 3xSuika

		} else if (enemyType == "demoSuika3Crumpled"){
		} else if (enemyType == "demoSuika3Attacking"){
		} else if (enemyType == "demoSuika4"){
			//Enemy Spawn 4xSuika

			enemyClone0 = (GameObject)Instantiate(demoSuika, enemySlot0.transform.position, Quaternion.identity);
			enemyClone1 = (GameObject)Instantiate(demoSuika, enemySlot1.transform.position, Quaternion.identity);
			enemyClone2 = (GameObject)Instantiate(demoSuika, enemySlot2.transform.position, Quaternion.identity);
			enemyClone3 = (GameObject)Instantiate(demoSuika, enemySlot3.transform.position, Quaternion.identity);
			enemyClone0.name = "Suika";
			enemyClone1.name = "Suika";
			enemyClone2.name = "Suika";
			enemyClone3.name = "Suika";
			enemy0 = "Suika";
			enemy1 = "Suika";
			enemy2 = "Suika";
			enemy3 = "Suika";
			drunkIcon1.SetActive(true);
			drunkIcon2.SetActive(true);
			drunkIcon0.SetActive(true);
			drunkIcon3.SetActive(true);

			healthEnemy0 = 4;
			healthEnemy1 = 4;
			healthEnemy2 = 4;
			healthEnemy3 = 4;

		} else if (enemyType == "demoSuika4Crumpled"){
		} else if (enemyType == "demoSuika4Attacking"){
		} else if (enemyType == "demoCube3"){
			enemyClone1 = (GameObject)Instantiate(demoCube, enemySlot1.transform.position, Quaternion.identity);
			enemyClone2 = (GameObject)Instantiate(demoCube, enemySlot2.transform.position, Quaternion.identity);
			enemyClone3 = (GameObject)Instantiate(demoCube, enemySlot3.transform.position, Quaternion.identity);
			enemyClone1.name = "Cube";
			enemyClone2.name = "Cube";
			enemyClone3.name = "Cube";

			enemy1 = "demoCube"; //there is no information about enemy "demoCube"
			enemy2 = "demoCube"; //demoCube WILL ACTUALLY ATTACK THE PLAYER!!!
			enemy3 = "demoCube";

			healthEnemy1 = 4;
			healthEnemy2 = 4;
			healthEnemy3 = 4;
		} else if (enemyType == "demoCube3Crumpled"){ //Enemy cube 3 has no field attack or first strike attack
		} 

		yield return null;
	}

	IEnumerator EndBattle(){
		if(inBattle == true){
			inBattle = false; //apparently, if this was placed in the commented line, the game does not work.

			XP_text.SetActive(true);
			battleUI.SetActive(false);
			yield return new WaitForSeconds(2.5f);
			XP_text.SetActive(false);
			battleUI.SetActive(true);

			gameObject.transform.position = beforeBattlePosition;
				
			battleCamera.SetActive(false);
			camera.SetActive(true);

			//unflip out of battle
			camera.GetComponent<Camera>().transform.position = notflip.transform.position;
			camera.GetComponent<Camera>().transform.rotation = notflip.transform.rotation;
			camera.GetComponent<Camera>().orthographic = true;
			sprite.transform.rotation = notflip.transform.rotation;
			flipped = false;

			gameObject.GetComponent<Rigidbody>().useGravity = true;
			gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY;
			gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
			gameObject.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;

			//movement = new Vector3(0,0,0);
			whoIsAttacking = "Player";
			print("Battle has ended!");
			enemy0checked = false; //Without this, the game thinks that certain enemies already attacked and multithreads bad!
			enemy1checked = false;
			enemy2checked = false;
			enemy3checked = false;
			enemy4checked = false;
			//inBattle = false;
		}
	}

	//THINGS WITHOUT COLLISIONS "is trigger" gameObjects
	void OnTriggerEnter(Collider other){
		if(other.tag == "Respawn"){
			rb.velocity = Vector3.zero;
			transform.position = respawnLocation.transform.position;
		}

		if(other.tag == "CutsceneTrigger"){
			//Do stuff
		}

		if(other.tag == "CameraTrigger"){
			//Do stuff	
		}
	}
		
	IEnumerator blockingTextUp(){
		blockingText.SetActive(true);
		blockSFX.Play();
		yield return new WaitForSeconds(0.5f);
		blockingText.SetActive(false);
	}

	void OnCollisionExit(Collision col)
	{
		Collider other = col.collider;
		if(other.tag == "wall"){
			collisionWithWall = false;
		}
	}

	//THINGS WITH TRIGGERS LIKE ENEMIES AND ITEMS
	void OnCollisionEnter(Collision col){
		Collider other = col.collider;

		if(other.tag == "Enemy"){
			if(inBattle == false){
				//initiate battle!!!
				StartCoroutine(StartBattle(other.name));
				Destroy(other.gameObject); 
				//Reminder: When game is "loaded from a Save" the only data recorded is SaveBlockID (Stores position of save), Level, xp to next level, money, inventory stuff, Progression Checkpoint 
			} else {
				int damage = 0;
				//This means the enemy collided with the player in Battle -- meaning this is the time player should block
				print("Player hit by attack in battle");
				if(blocking == true){ 
					damage -= 1;//Certain badges increase this value further.
					StartCoroutine(blockingTextUp());
					//play Audio?
				}

				if(other.name == "Suika"){
					damage += 2;
				}
				if(other.name == "Cube"){
					damage += 1;
				}

				if(damage < 0){
					damage = 0;
				}
				playerHealth -= damage;
				StartCoroutine(displayDamagePlayerText(damage));

				if(playerHealth < 10){
					hpText.text = "HP:  0" + playerHealth + "/" + maxHP; 
				} else {
					hpText.text = "HP:  " + playerHealth + "/" + maxHP;
				}


				enemy0attacking = false;
				enemy1attacking = false;
				enemy2attacking = false;
				enemy3attacking = false;
				enemy4attacking = false;
			}
		} else if(other.tag == "Item"){
			//Collect the item

			if(item1.tag == "no item"){
				item1.name = other.name;
				item1.tag = other.tag;
				item1.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item2.tag == "no item"){
				item2.name = other.name;
				item2.tag = other.tag;
				item2.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item3.tag == "no item"){
				item3.name = other.name;
				item3.tag = other.tag;
				item3.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item4.tag == "no item"){
				item4.name = other.name;
				item4.tag = other.tag;
				item4.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item5.tag == "no item"){
				item5.name = other.name;
				item5.tag = other.tag;
				item5.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item6.tag == "no item"){
				item6.name = other.name;
				item6.tag = other.tag;
				item6.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item7.tag == "no item"){
				item7.name = other.name;
				item7.tag = other.tag;
				item7.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item8.tag == "no item"){
				item8.name = other.name;
				item8.tag = other.tag;
				item8.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item9.tag == "no item"){
				item9.name = other.name;
				item9.tag = other.tag;
				item9.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else if (item10.tag == "no item"){
				item10.name = other.name;
				item10.tag = other.tag;
				item10.GetComponent<SpriteRenderer>().sprite = other.GetComponentInChildren<SpriteRenderer>().sprite;
			} else {
				//PRINT INVENTORY FULL
			}
		} else if (other.tag == "wall"){
			collisionWithWall = true;
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody>();
		originalSprite = sprite.GetComponent<SpriteRenderer>().sprite;
	}

	//Some Stolen Code for a LERP  from: http://wiki.unity3d.com/index.php?title=MoveObject&_ga=2.119919105.843972680.1589818211-1928500282.1589818211
	IEnumerator Rotation(Transform thisTransform, Vector3 degrees, float time)
	{
		Quaternion startRotation = thisTransform.rotation;
		Quaternion endRotation = thisTransform.rotation * Quaternion.Euler(degrees);
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f)
		{
			t += Time.deltaTime * rate;
			thisTransform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
			yield return null;
		}
	}
		
	IEnumerator RotationAndDeactivation(GameObject thisTransform, Vector3 degrees, float time)
	{
		Quaternion startRotation = thisTransform.transform.rotation;
		Quaternion endRotation = thisTransform.transform.rotation * Quaternion.Euler(degrees);
		float rate = 1.0f / time;
		float t = 0.0f;
		while (t < 1.0f)
		{
			t += Time.deltaTime * rate;
			thisTransform.transform.rotation = Quaternion.Slerp(startRotation, endRotation, t);
			yield return null;
		}
		thisTransform.SetActive(false);
	}

	IEnumerator Spawn2Bullets(){
		bulletImageInstantiated1 = (GameObject)Instantiate(bulletImage, bulletImage.transform.position, bulletImage.transform.rotation);
		yield return new WaitForSeconds(0.2f);
		bulletImageInstantiated2 = (GameObject)Instantiate(bulletImage, bulletImage.transform.position, bulletImage.transform.rotation);

		//bulletImage has a script on it causing it to move in a line on Y axis.
		yield return new WaitForSeconds(0.5f);
		Destroy(bulletImageInstantiated1);
		yield return new WaitForSeconds(0.2f);
		Destroy(bulletImageInstantiated2);
	}

	IEnumerator Spawn1Bullet(){
		bulletImageInstantiated1 = (GameObject)Instantiate(bulletImage, bulletImage.transform.position, bulletImage.transform.rotation);

		//bulletImage has a script on it causing it to move in a line on Y axis.
		yield return new WaitForSeconds(0.5f);
		Destroy(bulletImageInstantiated1);

	}

	//Attacks in Paper Tenko appear to work like this: 
	//When Z is pressed and "enemies" are attacking, the player sprite switches from 'idle' to 'blocking' for about ~15 frames. 
	//collision when the 'blocking' sprite is up deal less damage. 

	IEnumerator enemy0attack(){
		enemy0attacking = true;

		yield return new WaitForSeconds(0.0f);

	}

	IEnumerator enemy1attack(){
		enemy1attacking = true;

		yield return new WaitForSeconds(0.0f);
	}

	IEnumerator enemy2attack(){
		enemy2attacking = true;

		yield return new WaitForSeconds(0.0f);
	}

	IEnumerator enemy3attack(){
		enemy3attacking = true;

		yield return new WaitForSeconds(0.0f);
	}

	IEnumerator enemy4attack(){
		enemy4attacking = true;

		yield return new WaitForSeconds(0.0f);
	}

	//	ActionCommandMinigameFinished is the bool to do things here
	IEnumerator ActionCommandBullet(){ //Action Command is simple "press when crosshair appears" [it is random between 1-3 seconds]
		ActionCommandMinigameBulletFinished = false;
		commandSuccess = false; //Reset the action command so that if previous turn's command succeeded there is no freebie for the next turn's
		//ActionCommand detects player input at a certain time -- action commands NEVER halt for player inputs -- they all have set lengths of time 
		yield return new WaitForSeconds(UnityEngine.Random.Range(1.0f,3.0f));
		//if(buttonPressedAlready == false){
		if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
			crosshairBullet.transform.position = new Vector3(enemySlot0.transform.position.x, enemySlot0.transform.position.y, crosshairBullet.transform.position.z);
		} else if (enemyPointer.transform.position.x == enemySlot1.transform.position.x){
			crosshairBullet.transform.position = new Vector3(enemySlot1.transform.position.x, enemySlot1.transform.position.y, crosshairBullet.transform.position.z);
		} else if (enemyPointer.transform.position.x == enemySlot2.transform.position.x){
			crosshairBullet.transform.position = new Vector3(enemySlot2.transform.position.x, enemySlot2.transform.position.y, crosshairBullet.transform.position.z);
		} else if (enemyPointer.transform.position.x == enemySlot3.transform.position.x){
			crosshairBullet.transform.position = new Vector3(enemySlot3.transform.position.x, enemySlot3.transform.position.y, crosshairBullet.transform.position.z);
		} else if (enemyPointer.transform.position.x == enemySlot4.transform.position.x){
			crosshairBullet.transform.position = new Vector3(enemySlot4.transform.position.x, enemySlot4.transform.position.y, crosshairBullet.transform.position.z);
		}
		crosshairBullet.SetActive(true);
		//}
		yield return new WaitForSeconds(0.5f);
		crosshairBullet.SetActive(false);
		//in Update it checks if "ActionCommandMinigameFinished" is true or false then takes input based on that. 
		if(ActionCommandMinigameBulletFinished == false && commandSuccess == false && buttonPressedAlready == false){ //have a gameObject appear in scene check instead of boolean triggering this
			print("Failure!");
			commandSuccess = false;
		}
		ActionCommandMinigameBulletFinished = true;
	}

	IEnumerator ActionCommandMallet(){ //This will be o o O O O where the three big "O"s will have one light up a four point star, release LeftArrow when it lights
		ActionCommandMinigameMalletFinished = false;
		//ActionCommand detects player input at a certain time -- action commands NEVER halt for player inputs -- they all have set lengths of time 
		yield return new WaitForSeconds(2.0f);
		ActionCommandMinigameMalletFinished = true;
	}
		
	IEnumerator SwitchTurnToEnemiesButFirstPauseForASecond(){
		yield return new WaitForSeconds(1.0f);
		whoIsAttacking = "Enemies";
	}

	IEnumerator displayDamagePlayerText(int damage){
		if(damage == 1) enemyDamage1.SetActive(true);
		if(damage == 2) enemyDamage2.SetActive(true);
		if(damage == 3) enemyDamage3.SetActive(true);
		if(damage == 4) enemyDamage4.SetActive(true);
		if(damage == 5) enemyDamage5.SetActive(true);
		if(damage == 6) enemyDamage6.SetActive(true);
		if(damage == 7) enemyDamage7.SetActive(true);
		if(damage == 8) enemyDamage8.SetActive(true);
		if(damage == 9) enemyDamage9.SetActive(true);
		if(damage == 10) enemyDamage10.SetActive(true);

		yield return new WaitForSeconds(0.7f);

		//remove damage UI text
		enemyDamage1.SetActive(false);
		enemyDamage2.SetActive(false);
		enemyDamage3.SetActive(false);
		enemyDamage4.SetActive(false);
		enemyDamage5.SetActive(false);
		enemyDamage6.SetActive(false);
		enemyDamage7.SetActive(false);
		enemyDamage8.SetActive(false);
		enemyDamage9.SetActive(false);
		enemyDamage10.SetActive(false);
	}

	IEnumerator DisplayDamage(string text, int damage){
		if(text == "Noice"){
			noiceText.SetActive(true);
			if(damage == 1) allyDamage1.SetActive(true);
			if(damage == 2) allyDamage2.SetActive(true);
			if(damage == 3) allyDamage3.SetActive(true);
			if(damage == 4) allyDamage4.SetActive(true);
			if(damage == 5) allyDamage5.SetActive(true);
			if(damage == 6) allyDamage6.SetActive(true);
			if(damage == 7) allyDamage7.SetActive(true);
			if(damage == 8) allyDamage8.SetActive(true);
			if(damage == 9) allyDamage9.SetActive(true);
			if(damage == 10) allyDamage10.SetActive(true);

			yield return new WaitForSeconds(0.7f);
			noiceText.SetActive(false);

			//remove damage UI text
			allyDamage1.SetActive(false);
			allyDamage2.SetActive(false);
			allyDamage3.SetActive(false);
			allyDamage4.SetActive(false);
			allyDamage5.SetActive(false);
			allyDamage6.SetActive(false);
			allyDamage7.SetActive(false);
			allyDamage8.SetActive(false);
			allyDamage9.SetActive(false);
			allyDamage10.SetActive(false);
		} else if(text == "Fail"){
			if(damage == 1) allyDamage1.SetActive(true);
			if(damage == 2) allyDamage2.SetActive(true);
			if(damage == 3) allyDamage3.SetActive(true);
			if(damage == 4) allyDamage4.SetActive(true);
			if(damage == 5) allyDamage5.SetActive(true);
			if(damage == 6) allyDamage6.SetActive(true);
			if(damage == 7) allyDamage7.SetActive(true);
			if(damage == 8) allyDamage8.SetActive(true);
			if(damage == 9) allyDamage9.SetActive(true);
			if(damage == 10) allyDamage10.SetActive(true);

			yield return new WaitForSeconds(0.7f);

			//remove damage UI text
			allyDamage1.SetActive(false);
			allyDamage2.SetActive(false);
			allyDamage3.SetActive(false);
			allyDamage4.SetActive(false);
			allyDamage5.SetActive(false);
			allyDamage6.SetActive(false);
			allyDamage7.SetActive(false);
			allyDamage8.SetActive(false);
			allyDamage9.SetActive(false);
			allyDamage10.SetActive(false);
		}
	}

	//ActionCommand is another IEnumerator, when called, this IEnumerator waits until the other one is done...
	IEnumerator MainBattleProgression(){
		if(inBattle == true && HavePartner == true) {
			//UI AND STUFF FOR BATTLE -- A = Use card, V = Swap Player & Partner location for  attack order
			if(whoIsAttacking == "Player"){
				//DISPLAY AND CONTROL PLAYER UI -- more if statements until a selection occurs

			} else if (whoIsAttacking == "Partner"){
				//DISPLAY AND CONTROL PARTNER UI

			} else if (whoIsAttacking == "Enemies"){
				//HIDE BOTH UI

				//FOR EACH ENEMY, CHECK WHICH TYPE OF ENEMY IS IN THAT SLOT
				/*if(enemySlot0 == null){
				 //Enemy1 attacks!
				} else if(enemySlot1 == ){
					//Enemy2 attacks!
				}else if(enemySlot2 == ){
				}else if(enemySlot3 == ){
				}else if(enemySlot4 == ){
				}*/
			}

			if(Input.GetKeyDown(KeyCode.V) && PartnerOrPlayerAttacked == false){
				if(whoIsAttacking == "Player"){
					whoIsAttacking = "Partner";
					Debug.Log("Partner Attacking"); 
				} else if(whoIsAttacking == "Partner"){
					whoIsAttacking = "Player";
				}
			}

			if(/*enemySlot0 == && enemySlot1 == && enemySlot2 == && enemySlot3 == && enemySlot4 ==*/ false ){
				//DO STUFF HERE LIKE RESET CERTAIN VARIABLES BEFORE ENDING THE BATTLE
				StartCoroutine(EndBattle()); 
			}

		} else if(inBattle == true && HavePartner == false) {
			//UI AND STUFF FOR BATTLE -- A = Use card, V = Swap Player & Partner location for  attack order
			if(whoIsAttacking == "Player"){
				//isNotSpammingTimer so players can't spam one button to break menus; there are five frames in which the menu can be broken though if spammed (0.1f cs vs 0.2f for rotation Lerp for second menu)
				//Solution to this would be having two separate if statements for each menu since they have different lerp times

				//DISPLAY AND CONTROL PLAYER UI -- more if statements until a selection occurs

				//tactics items specials projectile mallet [These are your 5 menu options, Projectile = Jump -- perhaps special projectile pierces first enemy striking second]
				//Basic Projectile attacks are similar to Parakarry's ShellShot attack -- basic projectile attack is talisman throw -- your basic projectile "FP" move is "Spear Shot"
				//Talisman throw is like 2 ShellShots in succession -- still treated like the damage scaling of Mario's jump with collider for damage calculation
				//Projectile is always the first attack recommended
				if(Input.GetKeyDown(KeyCode.LeftArrow) && isNotSpammingTimer > 10f && battleMenuOneOpen == false && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){//the timer is so that spamming the menu doesn't break it
					isNotSpammingTimer = 0.0f;
					StartCoroutine(Rotation(battleUI.transform, new Vector3(0,0,90), 0.1f));
					if(battleMenuMalletText.activeSelf == true){
						battleMenuMalletText.SetActive(false);
						battleMenuMalletIcon.SetActive(true);
						battleMenuBulletText.SetActive(true);
						battleMenuBulletIcon.SetActive(false);
					} else if (battleMenuBulletText.activeSelf == true){
						battleMenuBulletText.SetActive(false);
						battleMenuBulletIcon.SetActive(true);
						battleMenuItemText.SetActive(true);
						battleMenuItemIcon.SetActive(false);
					} else if (battleMenuItemText.activeSelf == true){
						battleMenuItemText.SetActive(false);
						battleMenuItemIcon.SetActive(true);
						battleMenuTacticsText.SetActive(true);
						battleMenuTacticsIcon.SetActive(false);
					} else if (battleMenuTacticsText.activeSelf == true){
						battleMenuMalletText.SetActive(true);
						battleMenuMalletIcon.SetActive(false);
						battleMenuTacticsText.SetActive(false);
						battleMenuTacticsIcon.SetActive(true);
					}
				} else if (Input.GetKeyDown(KeyCode.RightArrow) && isNotSpammingTimer > 10f && battleMenuOneOpen == false && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					isNotSpammingTimer = 0.0f;
					StartCoroutine(Rotation(battleUI.transform, new Vector3(0,0,-90), 0.1f));
					if(battleMenuMalletText.activeSelf == true){
						battleMenuMalletText.SetActive(false);
						battleMenuMalletIcon.SetActive(true);
						battleMenuTacticsText.SetActive(true);
						battleMenuTacticsIcon.SetActive(false);
					} else if (battleMenuBulletText.activeSelf == true){
						battleMenuBulletText.SetActive(false);
						battleMenuBulletIcon.SetActive(true);
						battleMenuMalletText.SetActive(true);
						battleMenuMalletIcon.SetActive(false);
					} else if (battleMenuItemText.activeSelf == true){
						battleMenuBulletText.SetActive(true);
						battleMenuBulletIcon.SetActive(false);
						battleMenuItemText.SetActive(false);
						battleMenuItemIcon.SetActive(true);
					} else if (battleMenuTacticsText.activeSelf == true){
						battleMenuTacticsText.SetActive(false);
						battleMenuTacticsIcon.SetActive(true);
						battleMenuItemText.SetActive(true);
						battleMenuItemIcon.SetActive(false);
					}
				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.Z) && secondNotSpammingTimer > 20.0f && battleMenuOneOpen == false && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					secondNotSpammingTimer = 0.0f;

					battleMenuOneOpen = true;
					//open menu
					battleMenuLower.SetActive(true);
					StartCoroutine(Rotation(battleMenuLower.transform, new Vector3 (-180, 0, 0), 0.2f)); //This activates the menu for ability/item select
					//MENU SCROLLING HERE?
					if(battleMenuMalletText.activeSelf == true){ //NEED 4 IF STATEMENTS TO FIGURE OUT WHICH OPTION WAS SELECTED AND WHAT TO DO AFTER
						attackMenuMallet.SetActive(true);
					} else if(battleMenuItemText.activeSelf == true){
						attackMenuItem.SetActive(true); 
						if(item1.name == "Lightning"){
							//do something
						}
						/*
						 * NEED TO PUT A SCROLLABLE UI THAT USES THE ITEMS ATTACHED TO THIS SCRIPT HERE.
						 */
					}else if(battleMenuBulletText.activeSelf == true){
						attackMenuBullet.SetActive(true);//Shot = 1 + 1 damage, Power Shot = 3 + 1 damage (add 2 to the first attack). (at level 1)
					}else if(battleMenuTacticsText.activeSelf == true){
						attackMenuTactics.SetActive(true);
					}

					activeAttack = "0"; //defaults the menu to the first option as selected
					//PUT OTHER OPTIONS IN HERE, DO NOT BE AFRAID TO DELETE CODE THAT IS HASTILY PUT TOGETHER -- STEP BY STEP THROUGH THE MENU DESCISIONS FOR "IFS"


					//--END FIRST MENU TO SELECT OPTION TO USE FOR THE TURN--

					//NEXT 4 IF STATEMENTS CONTROL HAVING THE ENEMY TARGET SELECTION MENU OPEN AFTER CHOOSING AN OPTION
				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.Z) && secondNotSpammingTimer > 20f && battleMenuItemText.activeSelf == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){ //WHICH MENU?
					secondNotSpammingTimer = 0.0f;
					enemySelectItemsOpen = true;
					//OPEN ENEMY TARGETING MENU HERE! Then another "Z" press needed for "Confirm which enemies to attack"
					enemyPointer.SetActive(true); //Either Defaults to FIRST ENEMY, OR PLAYER CHARACTER
					//HERE WOULD BE WHERE AN ORIGAMI ARROW [that bobs up and down] APPEARS OVER ALL ENEMIES REPRESENTING THE TARGET OF THE LIGHTNING BOLT

					battleUI.SetActive(false);

					battleMenuOneOpen = false;
					//closes battle menu, lets spinning selection occur again, closes menu options

					previousMenu = "Item";
					attackSelected = "Item" + activeAttack;	//For example, "bullet0" is normal bullet attack while bullet1 is whatever is in the second slot of the menu
					print(attackSelected);

					attackMenuMallet.SetActive(false);
					attackMenuItem.SetActive(false);
					attackMenuBullet.SetActive(false);
					attackMenuTactics.SetActive(false);

					StartCoroutine(RotationAndDeactivation(battleMenuLower, new Vector3 (-180, 0, 0), 0.2f));

				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.Z) && secondNotSpammingTimer > 20f && battleMenuTacticsText.activeSelf == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){ //WHICH MENU?
					secondNotSpammingTimer = 0.0f;

					enemySelectTacticsOpen = true;
					//OPEN ENEMY TARGETING MENU HERE! Then another "Z" press needed for "Confirm which enemies to attack"
					enemyPointer.SetActive(true); //Either Defaults to FIRST ENEMY, OR PLAYER CHARACTER

					battleUI.SetActive(false);

					battleMenuOneOpen = false;

					previousMenu = "Tactics";
					attackSelected = "Tactics" + activeAttack;	//For example, "bullet0" is normal bullet attack while bullet1 is whatever is in the second slot of the menu
					print(attackSelected);

					attackMenuMallet.SetActive(false);
					attackMenuItem.SetActive(false);
					attackMenuBullet.SetActive(false);
					attackMenuTactics.SetActive(false);

					StartCoroutine(RotationAndDeactivation(battleMenuLower, new Vector3 (-180, 0, 0), 0.2f));
				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.Z) && secondNotSpammingTimer > 20.0f && battleMenuMalletText.activeSelf == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){ //WHICH MENU?
					secondNotSpammingTimer = 0.0f;	

					enemySelectMalletOpen = true;
					//OPEN ENEMY TARGETING MENU HERE! Then another "Z" press needed for "Confirm which enemies to attack"
					enemyPointer.SetActive(true); //Either Defaults to FIRST ENEMY, OR PLAYER CHARACTER
					if(enemy0 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy1 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy2 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy3 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} //Enemy4 is ALWAYS flying and the only thing unreachable from Mallet

					previousMenu = "Mallet";
					attackSelected = "Mallet" + activeAttack;	//For example, "bullet0" is normal bullet attack while bullet1 is whatever is in the second slot of the menu
					print(attackSelected);

					battleUI.SetActive(false);

					battleMenuOneOpen = false;

					attackMenuMallet.SetActive(false);
					attackMenuItem.SetActive(false);
					attackMenuBullet.SetActive(false);
					attackMenuTactics.SetActive(false);

					StartCoroutine(RotationAndDeactivation(battleMenuLower, new Vector3 (-180, 0, 0), 0.2f));
				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.Z) && secondNotSpammingTimer > 20f && battleMenuBulletText.activeSelf == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){ //WHICH BULLET ATTACK WAS SELECTED?
					secondNotSpammingTimer = 0.0f;	

					enemySelectBulletOpen = true;
					//OPEN ENEMY TARGETING MENU HERE! Then another "Z" press needed for "Confirm which enemies to attack"
					enemyPointer.SetActive(true); //Either Defaults to FIRST ENEMY, OR PLAYER CHARACTER
					if(enemy0 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy1 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy2 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} else if(enemy3 != "empty"){
						enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
					} //Enemy4 is ALWAYS flying and the only thing unreachable from Mallet

					previousMenu = "Bullet";
					attackSelected = "Bullet" + activeAttack;	//For example, "bullet0" is normal bullet attack while bullet1 is whatever is in the second slot of the menu

					//Text box for each ability
					if(attackSelected == "Bullet0"){
						basicBulletText.SetActive(true);
					} else if(attackSelected == "Bullet1"){
						//do something
					}

					print(attackSelected);

					battleUI.SetActive(false);

					battleMenuOneOpen = false;

					attackMenuMallet.SetActive(false);
					attackMenuItem.SetActive(false);
					attackMenuBullet.SetActive(false);
					attackMenuTactics.SetActive(false);

					StartCoroutine(RotationAndDeactivation(battleMenuLower, new Vector3 (-180, 0, 0), 0.2f));
				} else if (battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.DownArrow) && battleMenuOneOpen == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){ 
					//REMEMBER TO DEFAULT ALL MENUS AS FIRST SELECTING THE FIRST OPTION
					activeAttack = (Convert.ToInt32(activeAttack) + 1).ToString(); //Player can scroll past possible menu options!

					if(battleMenuMalletText.activeSelf == true){
						battleMenuMalletOptionSelected.transform.position += new Vector3(0.19212543f, -0.388f, 0);
						//if(optionSelected == "Hammer"){
						//	optionSelected = "Power Hammer";
						//} else if (optionSelected == "Power Hammer" /*&& Power Hammer Unlocked == true*/){
						//}
					} else if (battleMenuBulletText.activeSelf == true){
						battleMenuBulletOptionSelected.transform.position += new Vector3(0.19212543f, -0.388f, 0);
					} else if (battleMenuTacticsText.activeSelf == true){
					} else if (battleMenuItemText.activeSelf == true){
						battleMenuItemsOptionSelected.transform.position += new Vector3(0.19212543f, -0.388f, 0);
					}
					//Arrow points to background of menu selection one downwards
				} else if (battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.UpArrow) && battleMenuOneOpen == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					//Arrow points to background of menu selection one downwards
					if(activeAttack != "0"){ //NOTE, the player can scroll past the possible menu options!
						activeAttack = (Convert.ToInt32(activeAttack) - 1).ToString();


						if(battleMenuMalletText.activeSelf == true){
							battleMenuMalletOptionSelected.transform.position -= new Vector3(0.19212543f, -0.388f, 0);
						} else if (battleMenuBulletText.activeSelf == true){
							battleMenuBulletOptionSelected.transform.position -= new Vector3(0.19212543f, -0.388f, 0);
						} else if (battleMenuTacticsText.activeSelf == true){
						} else if (battleMenuItemText.activeSelf == true){
							battleMenuItemsOptionSelected.transform.position -= new Vector3(0.19212543f, -0.388f, 0);
						}
					}

				} else if(battleUI.activeSelf == true && Input.GetKeyDown(KeyCode.X) && secondNotSpammingTimer > 20f && battleMenuOneOpen == true && !(enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					secondNotSpammingTimer = 0.0f;	

					battleMenuOneOpen = false;
					//closes battle menu, lets spinning selection occur again, closes menu options

					battleMenuBulletOptionSelected.transform.position = new Vector3(-4.076583f, 7.520277f, -30.14929f);
					battleMenuItemsOptionSelected.transform.position = new Vector3(-4.076583f, 7.520277f, -30.14929f);
					battleMenuMalletOptionSelected.transform.position = new Vector3(-4.076583f, 7.520277f, -30.14929f);
					battleMenuTacticsOptionSelected.transform.position = new Vector3(-4.076583f, 7.520277f, -30.14929f);


					attackMenuMallet.SetActive(false);
					attackMenuItem.SetActive(false);
					attackMenuBullet.SetActive(false);
					attackMenuTactics.SetActive(false);

					StartCoroutine(RotationAndDeactivation(battleMenuLower, new Vector3 (-180, 0, 0), 0.2f));

				} else if(Input.GetKeyDown(KeyCode.X) && secondNotSpammingTimer > 20f && (enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen) && battleMenuOneOpen == false){
					secondNotSpammingTimer = 0.0f;	

					enemySelectItemsOpen = false;
					enemySelectTacticsOpen = false;
					enemySelectMalletOpen = false;
					enemySelectBulletOpen = false;

					battleMenuOneOpen = true;

					enemyPointer.SetActive(false);
					//ALL attack descriptions also become false
					basicBulletText.SetActive(false);

					battleUI.SetActive(true);
					battleMenuLower.SetActive(true);
					StartCoroutine(Rotation(battleMenuLower.transform, new Vector3 (-180, 0, 0), 0.2f));
					if(previousMenu == "Mallet"){
						attackMenuMallet.SetActive(true);
					}else if(previousMenu == "Bullet"){
						attackMenuBullet.SetActive(true);
					}else if(previousMenu == "Tactics"){
						attackMenuTactics.SetActive(true);
					}else if(previousMenu == "Item"){
						attackMenuItem.SetActive(true);
					}

				} else if(Input.GetKeyDown(KeyCode.LeftArrow) && (enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					//Move enemy selection Ying-Yang to the spot left of current using enemyPointer.transform.position, also update which enemy being selected
					if(previousMenu == "Bullet"){

						#region LeftArrowEnemySelection

						/*if(enemyPointer.transform.position.x == enemySlot1.transform.position.x && enemySlot0 != "empty"){
							enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
						} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x && enemySlot1 != "empty"){
							enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
						} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x && enemySlot2 != "empty"){
							enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
						} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x && enemySlot3 != "empty"){
							enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
						} //Enemy4 is ALWAYS flying and the only thing unreachable from Mallet*/


						//TIME TO HARDCODE PERMUTATIONS -- if statements for all scenarios [The 32 if statements below are just these patterns 1 = "!=" 0 = "=="
						// 1 1 1 1 1
						// 1 1 1 1 0 [This is a standard 4 enemy battle start]
						// 1 1 1 0 1
						// 1 1 1 0 0 
						// 1 1 0 1 1
						// 1 1 0 1 0
						// 1 1 0 0 1
						// 1 1 0 0 0
						// 1 0 1 1 1
						// 1 0 1 1 0
						// 1 0 1 0 1
						// 1 0 1 0 0
						// 1 0 0 1 1
						// 1 0 0 1 0 
						// 1 0 0 0 1
						// 1 0 0 0 0
						// 0 1 1 1 1
						// 0 1 1 1 0 [I think this is a standard 3 enemy battle start]
						// 0 1 1 0 1
						// 0 1 1 0 0 [I think this is a standard 2 enemy battle start]
						// 0 1 0 1 1
						// 0 1 0 1 0
						// 0 1 0 0 1
						// 0 1 0 0 0
						// 0 0 1 1 1
						// 0 0 1 1 0 
						// 0 0 1 0 1
						// 0 0 1 0 0
						// 0 0 0 1 1
						// 0 0 0 1 0
						// 0 0 0 0 1
						// 0 0 0 0 0 [battle is over if this were true]


						//Yeah, there will be 32 of these.
						if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){ //base 5 enemy

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){ //base 4 enemy
							//make this #region cover the entirity of this If block so this does not look like a mess

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						}else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						}else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? There's only one enemy left, you have to select that one

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){//base 3 enemy

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						}else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//Umm, this this were true, wouldn't the battle be over... 
						}

						#endregion LeftArrowEnemySelection

					} else if(previousMenu == "Item"){ //ITEMS EITHER: Target Player, or Target ALL ENEMIES [partner is untargetable, TTYD and RPGs generally see no use to single target items]
						//conditionals for what each item does
						//if(attackSelected == [item name]){
						//do something
						//}
					}
				} else if(Input.GetKeyDown(KeyCode.RightArrow) && (enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen)){
					if(previousMenu == "Bullet"){

						#region RightArrowEnemySelection

						if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){ //base 5 enemy

							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){ //base 4 enemy
							//make this #region cover the entirity of this If block so this does not look like a mess

							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						}else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						}else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot0.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}
						} else if(enemy0 != "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? There's only one enemy left, you have to select that one

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){
							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){//base 3 enemy

							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot1.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						} else if(enemy0 == "empty" && enemy1 != "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						}else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 != "empty" && enemy4 == "empty"){

							if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot2.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							}

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 != "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 != "empty"){

							if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot3.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								enemyPointer.transform.position = new Vector3(enemySlot4.transform.position.x, enemyPointer.transform.position.y, enemyPointer.transform.position.z);
							} 

						}else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 != "empty" && enemy4 == "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 != "empty"){
							//nothing happens? Only one enemy, you have to target that one.

						} else if(enemy0 == "empty" && enemy1 == "empty" && enemy2 == "empty" && enemy3 == "empty" && enemy4 == "empty"){
							//Umm, this this were true, wouldn't the battle be over... 
						}

						#endregion RightArrowEnemySelection

					} else if(previousMenu == "Item"){ //ITEMS EITHER: Target Player, or Target ALL ENEMIES [partner is untargetable, TTYD and RPGs generally see no use to single target items]

						//conditionals for what each item does
						//if(attackSelected == [item name]){
						//do something
						//}
					}

				} else if(Input.GetKeyDown(KeyCode.Z) && (enemySelectItemsOpen || enemySelectTacticsOpen || enemySelectMalletOpen || enemySelectBulletOpen) && (ActionCommandMinigameBulletFinished != false) && (ActionCommandMinigameMalletFinished != false)/*()()*/){
					//Remove enemySelect icons
					enemySelectItemsOpen = false;
					enemySelectTacticsOpen = false;
					enemySelectMalletOpen = false;
					enemySelectBulletOpen = false;

					enemyPointer.SetActive(false);
					//ALL attack descriptions become SetActive(false)
					basicBulletText.SetActive(false);

					//Do the attack
					if(previousMenu == "Bullet"){ //Power bounce is broken so it is not in the game
						StartCoroutine(ActionCommandBullet());
						while(ActionCommandMinigameBulletFinished == false){
							yield return new WaitForSeconds(0.1f);
						}
						print("do bullet attack");
						if(attackSelected == "Bullet0" && commandSuccess == true /*&& Gohei == normal*/){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								//deal the damage to enemy in Slot 1
								print("2 damage dealt to enemy 1");
								healthEnemy1 -= 2;
								noice.Play();
								noiceText.transform.position = new Vector3(enemySlot1.transform.position.x, noiceText.transform.position.y, noiceText.transform.position.z);
								allyDamage2.transform.position = new Vector3(enemySlot1.transform.position.x, allyDamage2.transform.position.y, allyDamage2.transform.position.z);

								StartCoroutine(DisplayDamage("Noice",2));

								//ON SUCCESS, TWO BULLETS TRAVEL FROM PLAYER POSITION TO ENEMYSLOT POSITION (just distance formula or increment X on the bullet)
								//CODE FOR ANIMATION SHOULD BE WRITTEN HERE.
								StartCoroutine(Spawn2Bullets());
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								//deal the damage to enemy in Slot 2
								print("2 damage dealt to enemy 2");
								healthEnemy2 -= 2;
								noice.Play();
								noiceText.transform.position = new Vector3(enemySlot2.transform.position.x, noiceText.transform.position.y, noiceText.transform.position.z);
								allyDamage2.transform.position = new Vector3(enemySlot2.transform.position.x, allyDamage2.transform.position.y, allyDamage2.transform.position.z);

								StartCoroutine(DisplayDamage("Noice",2));

								StartCoroutine(Spawn2Bullets());
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								//deal the damage to enemy in Slot 3
								print("2 damage dealt to enemy 3");
								healthEnemy3 -= 2;
								noice.Play();
								noiceText.transform.position = new Vector3(enemySlot3.transform.position.x, noiceText.transform.position.y, noiceText.transform.position.z);
								allyDamage2.transform.position = new Vector3(enemySlot3.transform.position.x, allyDamage2.transform.position.y, allyDamage2.transform.position.z);

								StartCoroutine(DisplayDamage("Noice",2));

								StartCoroutine(Spawn2Bullets());
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								//HUH ENEMY SLOT 4 WILL CRASH THE GAME -- REMEMBER NO BATTLES with 5 enemies
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								print("2 damage dealt to enemy 0");
								healthEnemy0 -= 2;
								noice.Play();
								noiceText.transform.position = new Vector3(enemySlot0.transform.position.x, noiceText.transform.position.y, noiceText.transform.position.z);
								allyDamage2.transform.position = new Vector3(enemySlot0.transform.position.x, allyDamage2.transform.position.y, allyDamage2.transform.position.z);

								StartCoroutine(DisplayDamage("Noice",2));

								StartCoroutine(Spawn2Bullets());
							}
						} else if(attackSelected == "Bullet0" && commandSuccess == false){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								//deal the damage to enemy in Slot 1
								print("1 damage dealt to enemy 1");
								healthEnemy1 -= 1;
								allyDamage1.transform.position = new Vector3(enemySlot1.transform.position.x, allyDamage1.transform.position.y, allyDamage1.transform.position.z);

								StartCoroutine(DisplayDamage("Fail",1));

								StartCoroutine(Spawn1Bullet());

							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								//deal the damage to enemy in Slot 2
								print("1 damage dealt to enemy 2");
								healthEnemy2 -= 1;
								allyDamage1.transform.position = new Vector3(enemySlot2.transform.position.x, allyDamage1.transform.position.y, allyDamage1.transform.position.z);

								StartCoroutine(DisplayDamage("Fail",1));

								StartCoroutine(Spawn1Bullet());

							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								//deal the damage to enemy in Slot 3
								print("1 damage dealt to enemy 3");
								healthEnemy3 -= 1;
								allyDamage1.transform.position = new Vector3(enemySlot3.transform.position.x, allyDamage1.transform.position.y, allyDamage1.transform.position.z);

								StartCoroutine(DisplayDamage("Fail",1));

								StartCoroutine(Spawn1Bullet());

							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
								//HUH ENEMY SLOT 4 WILL CRASH THE GAME -- REMEMBER NO BATTLES with 5 enemies
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
								print("1 damage dealt to enemy 0");
								healthEnemy0 -= 1;
								allyDamage1.transform.position = new Vector3(enemySlot0.transform.position.x, allyDamage1.transform.position.y, allyDamage1.transform.position.z);

								StartCoroutine(DisplayDamage("Fail",1));

								StartCoroutine(Spawn1Bullet());

							}
						} 

						if(healthEnemy0 <= 0){
							//Destroy enemy in slot 0 (health number is already destroyed once it hits 0)
							Destroy(enemyClone0);
							enemy0 = "empty";
							drunkIcon0.SetActive(false);
						}
						if(healthEnemy1 <= 0){
							//Destroy enemy in slot 1 (health number is already destroyed once it hits 0)
							Destroy(enemyClone1);
							enemy1 = "empty";
							drunkIcon1.SetActive(false);
						}
						if(healthEnemy2 <= 0){
							//Destroy enemy in slot 2 (health number is already destroyed once it hits 0)
							Destroy(enemyClone2);
							enemy2 = "empty";
							drunkIcon2.SetActive(false);
						}
						if(healthEnemy3 <= 0){
							//Destroy enemy in slot 3 (health number is already destroyed once it hits 0)
							Destroy(enemyClone3);
							enemy3 = "empty";
							drunkIcon3.SetActive(false);
						}
						if(healthEnemy4 <= 0){
							//Destroy enemy in slot 4 (health number is already destroyed once it hits 0)
							Destroy(enemyClone4);
							enemy4 = "empty";
							//drunkIcon4.SetActive(false);
						}

						StartCoroutine(SwitchTurnToEnemiesButFirstPauseForASecond()); //This causes whoIsAttacking to become "Enemies"
						//whoIsAttacking = "Enemies";

						buttonPressedAlready = false;
					}else if(previousMenu == "Mallet"){
						StartCoroutine(ActionCommandMallet());
						while(ActionCommandMinigameMalletFinished == false){
							yield return new WaitForSeconds(0.1f);
						}
						print("Do mallet attack");
						//ACTION COMMAND IS:
						// o o O O O
						//where O O O has one light up a four point star the others light up universal not symbol randomly
						commandSuccess = true;
						if(attackSelected == "Mallet0" && commandSuccess == true /* && hammer == normal*/){
							if(enemyPointer.transform.position.x == enemySlot1.transform.position.x){
								//deal the damage to enemy in Slot 1
								print("2 damage dealt to enemy 1");
							} else if(enemyPointer.transform.position.x == enemySlot2.transform.position.x){
								//deal the damage to enemy in Slot 2
							} else if(enemyPointer.transform.position.x == enemySlot3.transform.position.x){
								//deal the damage to enemy in Slot 3
							} else if(enemyPointer.transform.position.x == enemySlot4.transform.position.x){
							} else if(enemyPointer.transform.position.x == enemySlot0.transform.position.x){
							}

						} else if(attackSelected == "Mallet0" && commandSuccess == false){
						}

						StartCoroutine(SwitchTurnToEnemiesButFirstPauseForASecond());
						//whoIsAttacking = "Enemies";
						buttonPressedAlready = false;
					}else if(previousMenu == "Item"){
					}else if(previousMenu == "Tactics"){
					}
				}

				//-Main Battle Menu, select one of five options with "if statements cycling"... 
				//-After selecting one of the options, another menu appears -- this should also be if statement heavy... 
				//-After selecting an option on the next menu, there should be another set of if statements for which enemy.
				//THIS MENU's INPUT SHOULD BE SAVED -- 

				//	[Then Enemy Turn]

			} else if (whoIsAttacking == "Enemies"){
				enemySelectItemsOpen = false;
				enemySelectMalletOpen = false;
				enemySelectBulletOpen = false;
				enemySelectTacticsOpen = false;

				battleMenuOneOpen = false;
				//HIDE BOTH UI

				//FOR EACH ENEMY, CHECK WHICH TYPE OF ENEMY IS IN THAT SLOT
				//EACH ENEMY ATTACKS BY CALLING AN ENEMY ATTACK FUNCTION. THE FUNCTION THEN CALCULATES WHEN THE 'BLOCK' SHOULD BE BY "ENEMY NAME" passed to function
				if(enemy0 != "empty" && healthEnemy0 > 0 && enemy0checked == false){//**Enemies shall have at most 3 different timing for one attack -- think how Yukari has 2 angles of doing the melee
				 //Enemy0 attacks!
					print("Enemy 0 attacks");
					StartCoroutine(enemy0attack());

					enemy0checked = true;
				} else { //the else case is to set that the enemy has been checked and enemy does not attack since the enemy is not present
					enemy0checked = true;
				}

				while(enemy0attacking){
					yield return new WaitForSeconds(0.1f);
				}

				if(enemy0 != "empty" && healthEnemy0 > 0){
					enemyClone0.transform.position = enemySlot0.transform.position;
				}

				//Need to wait for enemy1's attack to finish before enemy2 goes.
				if(enemy1 != "empty" && healthEnemy1 > 0 && enemy1checked == false){
					//Enemy1 attacks!
					print("Enemy 1 attacks");
					StartCoroutine(enemy1attack());

					enemy1checked = true;
				} else {
					enemy1checked = true;
				}

				while(enemy1attacking){
					yield return new WaitForSeconds(0.1f);
				}

				if(enemy1 != "empty" && healthEnemy1 > 0){
					enemyClone1.transform.position = enemySlot1.transform.position;
				}

				//PUT A DELAY HERE -- actually, COMPLETELY DELAY PROGRESSION UP TO HERE UNTIL ENEMY1's ATTACK FINISHES
				if(enemy2 != "empty" && healthEnemy2 > 0 && enemy2checked == false){
					//Enemy2 attacks
					print("Enemy 2 attacks");
					StartCoroutine(enemy2attack());

					enemy2checked = true;
				} else {
					enemy2checked = true;
				}

				while(enemy2attacking){
					yield return new WaitForSeconds(0.1f);
				}

				if(enemy2 != "empty" && healthEnemy2 > 0){
					enemyClone2.transform.position = enemySlot2.transform.position;
				}

				if(enemy3 != "empty" && healthEnemy3 > 0 && enemy3checked == false){
					print("Enemy 3 attacks");
					StartCoroutine(enemy3attack());

					enemy3checked = true;
				} else {
					enemy3checked = true;
				}

				while(enemy3attacking){
					yield return new WaitForSeconds(0.1f);
				}

				if(enemy3 != "empty" && healthEnemy3 > 0){
					enemyClone3.transform.position = enemySlot3.transform.position;
				}

				if(enemy4 != "empty" && healthEnemy4 > 0 && enemy4checked == false){
					print("Enemy 4 attacks");
					StartCoroutine(enemy4attack());

					enemy4checked = true;
				} else {
					enemy4checked = true;
				}

				while(enemy4attacking){
					yield return new WaitForSeconds(0.1f);
				}

				if(enemy4 != "empty" && healthEnemy4 > 0){
					enemyClone4.transform.position = enemySlot4.transform.position;
				}

				if(enemy0checked && enemy1checked && enemy2checked && enemy3checked && enemy4checked){
					enemy0checked = false;
					enemy1checked = false;
					enemy2checked = false;
					enemy3checked = false;
					enemy4checked = false;

					print("Enemy turn over!");
					whoIsAttacking = "Player"; //enemy turn over
					battleUI.SetActive(true);
				}

				//Set a boolean after all enemies are done attacking.

			}

			if(healthEnemy0 <= 0 && healthEnemy1 <= 0 && healthEnemy2 <= 0 && healthEnemy3 <= 0 && healthEnemy4 <= 0 && inBattle == true){
				//DO STUFF HERE LIKE RESET CERTAIN VARIABLES BEFORE ENDING THE BATTLE
				StartCoroutine(EndBattle()); 
			}
		} 
		yield return null; //exits out of this branch of code "yield return 0" means wait a frame [0] counts as 1 frame
	}

	// Update is called once per frame
	private void Update()
	{
		if(inBattle){
			UpdateHealth();
		}

		//print(ExtraBestiarySlotsHolder.GetComponent<ExtraBestiarySlots>().demoCube1.name);

		if(Input.GetKeyDown(KeyCode.P)){//THIS IS FOR DEBUGGING, REMOVE THIS IN FINAL BUILD!
			Application.Quit();
		}

		isNotSpammingTimer += 1.0f;//This timer increments once a frame
		secondNotSpammingTimer += 1.0f;

		if(ActionCommandMinigameBulletFinished == false && Input.GetKeyDown(KeyCode.Z) && crosshairBullet.activeSelf == true && buttonPressedAlready == false){
			print("Success!");
			commandSuccess = true;
			ActionCommandMinigameBulletFinished = true;
			buttonPressedAlready = true;
		} else if(ActionCommandMinigameBulletFinished == false && Input.GetKeyDown(KeyCode.Z) && crosshairBullet.activeSelf == false && buttonPressedAlready == false){
			print("Failure!");
			commandSuccess = false;
			ActionCommandMinigameMalletFinished = true;
			buttonPressedAlready = true;
		}

		if(ActionCommandMinigameMalletFinished == false){

		}

		StartCoroutine(MainBattleProgression()); //This is supposed to trigger once a frame, it is continuously checking for inputs
//		print("Here");

		//Triggered by enemy1attack function
		if(enemy1attacking == true){
			enemyClone1.transform.position -= new Vector3(0.1f,0,0);
		}
		if(enemy2attacking == true){
			enemyClone2.transform.position -= new Vector3(0.1f,0,0);
		}
		if(enemy3attacking == true){
			enemyClone3.transform.position -= new Vector3(0.1f,0,0);
		}
		if(enemy4attacking == true){
			enemyClone4.transform.position -= new Vector3(0.1f,0,0);
		}
		if(enemy0attacking == true){
			enemyClone0.transform.position -= new Vector3(0.1f,0,0);
		}

		if(Input.GetKeyDown(KeyCode.Z) && inBattle && whoIsAttacking == "Enemies" && canBlockAgain == true){ //8 frame guard window, can mash guard every 25 frames
			StartCoroutine(blockingFctn()); //                                                                 Might actually be 9 frames for guard and 26 for cooldown

		}

		if(inBattle == false){
			//ESCAPE brings the menu up
			if(Input.GetKeyDown(KeyCode.Escape) && Time.timeScale != 0f && flipped == false){
				Time.timeScale = 0f;
				PauseMenu.SetActive(true);
				menuOpened = true;
			}

			if (Input.GetKeyDown(KeyCode.Escape) && anotherTimer > 0.25f){
				Time.timeScale = 1f;
				PauseMenu.SetActive(false);
				menuOpened = false;
				anotherTimer = 0.0f;
			}

			if(menuOpened == true){
				anotherTimer += 0.125f;
			}

			timer += Time.deltaTime;
			if(flipped == false){
				camera.transform.position = new Vector3(transform.position.x, camera.transform.position.y, camera.transform.position.z);
				notflip.transform.position = new Vector3(transform.position.x, notflip.transform.position.y, notflip.transform.position.z);
			}
			//ONLY CERTAIN LOCATIONS ALLOW THE CAMERA TO FOLLOW THE PLAYER UP BASED ON COLLIDER TRIGGERS	

			if(flipped == true){
				camera.transform.position = new Vector3(flip.transform.position.x, transform.position.y+3, transform.position.z);
			}

			if (Input.GetKeyDown (KeyCode.Space) && flipped == false && (timer > waitTime) && NO_FLIPPING_Because_CutSCenE == false) {
				camera.GetComponent<Camera>().transform.position = flip.transform.position;
				camera.GetComponent<Camera>().transform.rotation = flip.transform.rotation;
				//StartCoroutine(LerpCamera());

				camera.GetComponent<Camera>().orthographic = false;
				sprite.transform.rotation = flip.transform.rotation;
				flipped = true;
				timer = 0;
			}

			//UNFLIPPING ALWAYS PLACES YOU IN THE 2D PLANE AT Z = 0 -- remember this when designing levels. Some boxes have no thickness
			//NOTHING CAN BE AT Z = 0 in the 3D WORLD AS THAT CAN CAUSE THE PLAYER TO BOUNCE OUT OF THE DEFAULT AXIS
			if (Input.GetKeyDown (KeyCode.Space) && flipped == true && (timer > waitTime) && NO_FLIPPING_Because_CutSCenE == false) {
				camera.GetComponent<Camera>().transform.position = notflip.transform.position;
				camera.GetComponent<Camera>().transform.rotation = notflip.transform.rotation;
				camera.GetComponent<Camera>().orthographic = true;
				sprite.transform.rotation = notflip.transform.rotation;
				gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0.0f);
				flipped = false;
				timer = 0;
			}

			if(flipped == false){
				movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
			} else if(flipped == true){
				movement = new Vector3(Input.GetAxis("Vertical"), 0, -1 * Input.GetAxis("Horizontal"));
			}

			float DisstanceToTheGround = GetComponent<Collider>().bounds.extents.y;

			bool IsGrounded = Physics.Raycast(transform.position, Vector3.down, DisstanceToTheGround + 0.1f);

			jumpCooldown -= Time.deltaTime;
			GroundedTimer -= Time.deltaTime;
			if(IsGrounded){
				//set a timer for 0.2 seconds, gives player some hangtime for jump inputs
				GroundedTimer = 0.19f;
			}

			if(Input.GetKey(KeyCode.Z) && (GroundedTimer > 0) && jumpCooldown < 0 && collisionWithWall == false){
				jumpCooldown = 0.2f;
				rb.AddForce(new Vector3(0, 400, 0));
			}

			if(Input.GetKeyUp(KeyCode.Z) || rb.velocity.y < -2.5f){
				rb.AddForce(Physics.gravity * 20);
			}
		}
	}


	private void FixedUpdate(){
		rb.MovePosition(transform.position + movement * _speed * Time.fixedDeltaTime);
	}
}
