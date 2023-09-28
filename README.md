# Alp
***
# V0.9.0
* Added entity 'Hortlak'
* Created animations: 
	- Hortlak Idle
	- Hortlak Walk
	- Hortlak Attack
	- Hortlak Hurt
	- Hortlak Spawn
***
# V0.8.5
* Added adventurer-bow-run sprites
* Created player -> Run Bow animation
***
# V0.8.4
* Improved camera following mechanics
* Changed Loading Screen image
***
# V0.8.3
* Improved jump mechanics
* Imporved GameCamera's following manchanic
	- Added methods:
		+ MoveDown
		+ MoveUp
***
# V0.8.2
* Some forest map designs
***
# V0.8.1
* Fixed knockback bugs on Tepegöz's attack
***
# V0.8.0
* Made transitions between attack combos
***
# V0.7.13
* Added player animations:
	- Attack 2 
	- Attack 3
* Attemp to make combo between 3 attack animation
* ***
# V0.7.12
* New assets added
* Bow mechanics fixed
* New areas added
***
# V0.7.11
* Improved 'Player Attack Collider' damage system
***
# V0.7.10
* Added get Rigidbody func. to Entity
* Added KnightAttackCollider to Knight
* Added KnightAttackTrigger to Knight
* Improved direction mechanics in arrow etc. AddForce
* Fixed knight die animation 9
***
# V0.7.9
* Added knight mechanics
* Added knight animations:
	- Die
	- Walk
	- Idle
# V0.7.8.1
* Added musics:
	- It Can't Last (Sunset)
	- Collateral
***
# V0.7.8
* Added Kngiht sprites
* Created animations:
	- Knight attack
	- Knight walk
	- Knight idle
	* *Made transitions among them
***
# V0.7.6
* Some map improvements
***
# V0.7.6
* Fixed throwing arrow to left
***
# V0.7.5
* Arrow disappears when collides an object
***
# V0.7.4
* (Some missing attributes)
* Addded archery mechanics
***
# V0.6.8
* Added death animation to Tepegöz
* Added damage animation to Tepegöz
* Player cannot push Tepegöz anymore
* Added 'LoadingScreen'
***
# V0.6.4
* Added combat mechanics to Tepegöz:
	+ Hits after 0.5 seconds
	+ Throws back player
	+ Damage = 40
	+ Health = 200
***
# V0.6.3
* Added boss 'Tepegöz'
	+ Run sprites (animated)
	+ Idle sprites (animated)
	+ Attack sprites
	+ Die sprites
* Added music for boss fight (They're Still Out Here -> BossFight)
* Added boss controls:
	+ Tepegöz moves to player when player is in the -15 - 15 area
* Added boss fight trigger
* Added boss fight scene manager
***
# V0.6.2
* Some spiretes resized and improved:
	+ Player idle resized and improved
	+ Player run resized and improved
	+ Player attack resized and improved
	+ Öcü resized
***
# V0.6.0
* Designed 'Pause Menu'
* Designed 'Death Menu'
* Resized 'Player'
* Added low health effect:
	+ Heart beat effect if healt < 25
	+ Screen effect if healt < 25
***
# V0.5.3
* Edited combat1-infected-out
* Changed some level design parts
* Resized ormandüzzemin (128 x 128 to 49 x 49)
***
# V0.5.2
* New assets added
***
# V0.5.1
* Changed death sound to 'death1'
***
# V0.5.0
* Added 'MainMenu' scene
	+ Canvas contains 2 components:
		+ Main (Panel):
			+ Play button
			+ Options button
			+ Quit button
		+ Options (Panel):
			+ Tittle (Text Mesh Pro)
			+ Back button
			+ Volume Slider
			+ Text -> Volume
* Musics added to Main Menu
	+ All Gone (The Ultmatum)
	+ Reclaimed Memories
	+ The Aqurium (Beginnings)
***
# V0.4.1
* Some terrain changements
***
# V0.4.0
* Improved music mechanics
* Created 'Music Session' object
	+ Contains clips for the session
* Improved pause menu mechanics
* Added death menu (Appears after player died)
* Added death mechanics:
	+ Time scale decreases by Time.deltaTime * 0.8f
	+ Visual effects (post processing profile -> Death)
	+ Sound effects (death, death1)
* Added 'IsDead' variable to player
* In first combat scene, music enters main clip when cutCam animation is over
***
# V0.3.3
* Added pause menu mechanics:
	- On click ESC button:
		+ give blur background
		+ stop game
		+ stop music
***
# V0.3.2.1
* Fixed camera oriantation
***
# V0.3.2
* Öcü takes damage when player attaks on it now (OnTriggerEnter2D method in Öcü class)
* Prepared music engine disgn for 'First combat scene' 
	- music-in (plays on combat start)
	- music-main (plays in loop after music-in)
	- music-out (plays on end combat)
***
# V0.3.1.1
* Added combat trigger with öcü
***
# V0.3.1
* Added die animation to player
* Added GameController.Menu partial class to control game menu
* Entity class make abstract
* Added OnDeath virtual method to Entity class
* Death animation applied to player
* TODO:
	- Create game menu
***
# V0.3.0
* Added health bar and mechanics
***
# V0.2.0
* Added Visual Novel mechanic
* Added Atomic Boolean script (One time usable boolean)
***
# V0.1.0
* Improved player control mechanic
* Extended Forest map
***
# V0.0.1
* Added 'sword animation':
	- Idle
	- Run
	- Attack
***
# Initial Commit
* Added 'player idle sprites'
* Added 'player idle weapon sprites'
* Added 'player run sprites'
* Added 'player run weapon sprites'
* Created animations:
	- Player idle
	- Player idle weapon
	- Player run
	- Player run weapon
* Added 'Smooth follow player code' to 'Camera' 
