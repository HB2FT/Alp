# Mir
***
# V0.10.7
* Created `Input Manager`, ``VisualEffectsManager`, `AudioManager` objects and scripts
***
# V0.10.6
* Started integration audio system with FMOD
***
# V0.10.5
* Changed Pause Menu bakcground and button sytyles
***
# V0.10.4
* Added tilesets:
	- Bozkır
	- Dağ
	- Yeraltı
	- Orman
* Created new scene `Oba` 
***
# V0.10.3
* Fixed bug on player movement
* Integrated gamepad for item changing 
* Removed `playerInput.Player.Jump.performed` from `PlayerMovement`
* Changed Main Menu background
***
# V0.10.2
* Fixed bug on attack animation system
* Created custom button with focus effect
* Added new font `alaard.ttf`
* Created scene `Debug` for testing components
***
# V0.10.1
* Changed scene loading type from `SceneManager.LoadSceneSync()` to `SceneManager.LoadScene()`
> Scene loading brought to main thread. This changes up to MainMenu and SampleScene.
* Fixed bug on MainMenu Stucked animations
***
# V0.10
* Integrated new Input System
	- WASD controls
	- Arrow controls
	- Running (Shift) control
	- Jump (Space, W, Upper Arrow) controls
* Fixed warnings
***
# V0.9.8
* Fixed arrow animation mechanics
***
# V0.9.7
* Added arrow animation system to new animation controlling strucutre
***
# V0.9.6
* Fixed bugs o player attack combo system
* Changed animation controlling structure
***
# V0.9.5
* Changed player attack combo system (has bugs)
***
# V 0.9.4
* Product name changed to 'Mir'
* Loading screen sprite changed to 'Mir'
* Fixed bug on knights death
***
# V Alpha
* Changed slide key from 'K' to 'Left Shift'
* Set Boss Fight Cut Scene 
* Fixed bugs on Tepegöz's animation
* Changed Health Bar
* Changed Boss Fight Music
* Added healing mechanic:
	- Elixir icon and remaining elixir count on UI
	- Press 'E' to use elixir
* Changed Main Menu background animation
* Added ambient sound mechanic
* Added a mini tutorial
***
# V0.9.3
* Added sprites:
	- Hortlak -> Die
	- Player -> Slide
	- Player -> Stand
* Created animations:
	- Hortlak -> Die
	- Player -> Slide
	- Player -> Stand
* Öcü gives damage to player (damage = 15)
* Fixed bug on transition to Player Die animation
* Thorns kill player at once
* Improved Hortlak's movement mechanic
* Improved Knight's movement mechanic
* Added slide mechanic to Player:
	- Run and press 'K'
***
# V0.9.2.1
* Missing changes
***
# V0.9.2
* Added walk with prepared bow animation (speed = speed / 4)
***
# V0.9.1
* Hortlak mechanics improved
* Bug in Tepegöz's attack mechanic fixed
* Player's attack mechanic fized
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
