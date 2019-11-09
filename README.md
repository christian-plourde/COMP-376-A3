<!DOCTYPE markdown>
COMP 376 Assignment 3
-------------------------------------

Author: Christian Plourde
Student ID: 26572499

Game developed for COMP 376 in Fall 2019.

Game Play
--------------------------------------
This game can be played on a computer with Unity installed, or by running the built version in the Build folder. 

The game begins with the player tossed into a cube that is filled with water. 

The objective of the game is to collect as many gold bars as possible. This is accomplished by swimming up to them. Once passed over, the gold bars will be added to the player's inventory. The more gold bars the player is carrying the more slowly he/she will move. The gold bars can be added to the player's score by moving them to the boat (which is at the water's surface). These bars will automatically be added to the player's score when the player is close to the boat. The number of gold bars that the player is carrying is indicated by the yellow meter in the bottom right corner of the screen.

The player can die if he runs out of lives, or oxygen. If he is hit by a shark, the player will lose one life. The current number of lives remaining is shown in the upper right corner of the UI. A player can also run out of oxygen. The current oxygen is indicated by the green meter in the bottom right of the UI. When oxygen becomes low, the corners of the screen will become bloody, as well as when a player has lost a life. The oxygen meter may be refilled by returning to the surface. When the crab is present, he will throw screwdrivers at the player. If the player is hit by one of these he will lose one life.

Over time, the level will change, and the sharks' speed will increase. The sharks may be distracted temporarily by the player by throwing coins. If the coins pass close to the sharks, the sharks will be distracted by them and change trajectory for a time.

Once in a while (as of level 2), a crab will appear and follow the player with his gaze as well as match his depth while trying to throw screwdrivers at the player to kill him. The crab may not be hurt and will disappear after a while.

Control Scheme:
--------------------------------------
W - Move Forward
S - Move Backward
A - Strafe Left
D - Strafe Right
Space - Boost Upward
Q - Drop All Gold
Left Mouse Click - Shoot Coins
Escape - Return to Main Menu