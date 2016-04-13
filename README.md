# Gestures-Project

##Zombie Myo Game

###John Lavin

##Purpose of the Application

The purpose of this project was to explore Gesture-Based UI. 
The technology I chose to use was the Myo Armband, designed by Thalmic Labs. 
I designed a game where zombies are spawned on screen and you have to shoot them 
before they attack you or get past you and attack the village. 
The Myo armband is used to control your aim and to fire shoots as well. 

##Gestures Identified

The Myo armband responds to a variety of gestures you make with your hand. Gestures include: Fingers spread, wave right, wave left, fist, rotate, double tap.


![alt tag](https://camo.githubusercontent.com/588008914020ff115d0fae331a16005ca6aa9e77/68747470733a2f2f612e706f6d662e6361742f62616b69736c2e6a7067)

The aiming in the game is controlled by the Myo’s panning gesture. 
When the game starts you press the r-key on the keyboard. This centres the screen and allows you to get your arm in the correct position. You can re-centre the screen as often as you like throughout the game. This allows you to rest your arm inbetween waves of zombies. I thought about changing this function to a Myo gesture but I found it too tiring for your arm.

To take aim at an enemy zombie you simply move your arm in the direction of the zombie.

To shoot at the zombie you have three options:

1.	Make a fist.

2.	Wave left.

3.	Wave right.


At first I only had the make fist option but I found that option very tiring. So I decided to incorporate the wave-left and wave-right gestures. I found that when you were aiming to the left of the screen ( pointing your arm to the left of the screen) the most natural/easiest gesture to create was the wave-left gesture. The same applied to aiming to the right of the screen.   


##Hardware Used

The Myo armband designed by Thalmic Labs was the main hardware used for this project. The armband allows for hands-free control of a wide range of technology. It enables the user to control technology wirelessly using various wrist and forearm motions. It uses a set of electromyographic sensors that sense electrical activity in the forearm, combined with a gyroscope, accelerometer and magnetometer to recognize gestures.

I found the Myo armband problematic at times. The gestures weren’t always picked up straight away meaning I had to recreate them twice or even three times. The double tap gesture was my least favourite and for this reason it is not in my game. The make a fist gesture is unresponsive at times.

##Architecture

![alt tag](https://raw.githubusercontent.com/JnLvn/Zombies-Myo-Game/master/ClassDiagram1.png)

Main scripts for project:

•	ThalmicMyo & ThalmicHub - These two scripts comes as standard with the Myo SDK and are what connects to the actual armband itself.

•	GameController – This is the heart of the game. Controls the spawning of enemy game objects (zombies), score, health, game over and restart game methods.

•	PlayerController – Controls how the player shoots in the game. Myo gestures to shoot.

•	JointOrientation – Controls how the player aims. 

•	DestroyByContact – Determines when a zombie is hit by shot. Then destroys them. If zombie hits player, gameOver method called. Also if zombie passes player on screen, minus 25 from health (the idea that the zombie has reached the village and the game is over).

•	Mover – Moves zombies in game.

•	ShotMover – Moves shot when fired.

•	StartGame – Main menu for game.

•	ZombieAnimator – Animator to create zombie walk effect.





