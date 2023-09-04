# Alp
***
# V0.4.0
* ımproved music mechanics
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
