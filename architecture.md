# Program Organization
  ## Context Diagram 
  
 ![System_Context_diagram](https://user-images.githubusercontent.com/54637213/107887604-3c148800-6ed5-11eb-8f1b-ba1d79692017.png)
 
 The context diagram is a very simple look at how our program acts. The user runs our application, 3D Tower Defense, and then our program uses the Unity Library to give them a complete experience. 
 
 ## Container Diagram
 
 ![Container_Diagram](https://user-images.githubusercontent.com/54637213/107887888-46378600-6ed7-11eb-929b-297a75875a82.png)
 
  This breaks down what our program encases. Stored in our program is a library which houses all of our 3D assets and scenes. These are run in a Unity application, but the user has a interface that limits their control in the enviroment as to the rules of our game. 
 
 ## Component Diagram
 
 ![Components](https://user-images.githubusercontent.com/54637213/107887900-5f403700-6ed7-11eb-9d6b-6f6d1d2b28b1.png)
 
 Inside our Unity Application we have a look at the different items we want it to have for our player. These are catered more towards our user stories, having the ability to make adjustments to settings as well as getting to interact with the enviroment to win the game.
 
 
| Block       | User Stories |
| ----------- | ----------- |
| Start Screen| As a player, I want to be able to begin a tower defense game (010)|
| Settings    | As a player, I want to be able to make adjustments to my play style (011)|
| Pause Contol| As a player, I want to be able to pause and continue where I left off (012)|
| Preparation | As a player, I want to be able to place my towers on the base (003)|
| Attack      | As a player, I want to be able to fire at the enemy (004)|

# Code Design 
  
  ## UML Class
  ![UMI_Class](https://user-images.githubusercontent.com/54637213/107887973-d4ac0780-6ed7-11eb-9092-b274b0707559.png)
  
  With this diagram we can see how each class in our program works in relation to each other and the methods and attributes that are assigned to them. I've left empty slots in this chart for now. such as enemy 1 and weapon 1, because the Enemy and Weapon classes will have many instances of each we just haven't solidified what they will be exactly. 
  
  | Class       | User Stories |
| ----------- | ----------- |
| Player | As a player, I want to see how much currency I have (008), As a player I want to see my score/stats (002)|
| Tower    | As a player, I want to be able to see the current status of my Tower (013)|
| Weapon | As a player, I want to be able to fire at the enemy (004)|
| Enemy | As a player, I want face an increasing challenge over time (009)|
  
  ## UML Activity
  ![UML_Activity](https://user-images.githubusercontent.com/54637213/107888180-d1654b80-6ed8-11eb-9633-9065397cbb74.png)
   
   This is a flow chart of the activities that occur in our program. We can see that most or our activities have multiple outcomes, and our game is initially a loop that increases difficultly the further the player gets. The user starts the game, they then get to set up their arsenal, but they are limited by how much money they have. They then start the attack phase and depending on the outcome of that they either progress, start again, or exit our game.
  
  ## UML Sequence
  ![UMI_Sequence](https://user-images.githubusercontent.com/54637213/107888286-581a2880-6ed9-11eb-82a7-cda5140ab450.png)
  
  This shows a sequence of events that happens when using our program. Since our application does not connect to any other networks it is active the entire time the user is interacting with it. Its a back and forth relationship. These connections greatly mirror our UML activity chart since they both walk through a play by play.
# Data Design
![ER (1)](https://user-images.githubusercontent.com/54637213/107888329-8e57a800-6ed9-11eb-984a-d92c3ca4cf51.png)
Our program doesn't use a large data base, like for example bank records. But it is crucial that we store Towers, Weapons, and Enemy types as they control the flow of the entire game. Each entity interects with the other in a specific way to create the scenario of our application.  

# User Interface Design
![Start Screen](https://user-images.githubusercontent.com/78228038/107892582-1480e800-6ef4-11eb-98ef-7bd10aac4804.png)
![World Map](https://user-images.githubusercontent.com/78228038/107892584-16e34200-6ef4-11eb-906a-88e3625d223e.png)
![LEVEL 1 Setup](https://user-images.githubusercontent.com/78228038/107892168-63794e00-6ef1-11eb-86b5-9464f4add086.png)
![Start Screen - Copy](https://user-images.githubusercontent.com/78228038/108027103-9c034f80-6ff7-11eb-8e4d-2b45d0cd9d58.png)
![World Map - Copy](https://user-images.githubusercontent.com/78228038/108027114-a1f93080-6ff7-11eb-9337-faf59851cc6f.png)
![LEVEL 1 Items - Copy](https://user-images.githubusercontent.com/78228038/108027123-a4f42100-6ff7-11eb-95de-0db57dd1077c.png)
- The start screen is the opening screen that provides the user with the name of game. When the user presses start, the world map will be viewed. 
- The world map allows the user to assess their current status in terms of their current level, remaining lives, and available currency. 
- When the user selects an unlocked level, the game will begin. Before the first wave of enemies enter, the user will be able to view and purchase available towers. Their current currency amount will be easily viewable in the corner of the screen. When a tower is selected, the user will be able to see the range of the tower. The user can use the exit button to view the base in full view. When the user has completed setting up their base, they will press the start button to begin. 

| Component | ID | User Story | Explanation |
| ------------- | ------------- | ------------- | ------------- |
| Start screen | 001 | As a player, I want to be able to see the world map. | The start button takes the user directly to the world map. |
| World map (outline) | 001 | As a player, I want to be able to see the world map. | The user is able to see all the levels and recognize current level. |
| World map (outline) | 010 | As a player, I want to be able to begin a tower defense game. | When an unlocked level is selected, the user will begin the game. |
| World map (currency) | 008 | As a player, I want to see how much currency I have. | The user is able to see how much avaliable currency they have and be able to purchase more currency. |
| World map (lives) | 010 | As a player, I want to be able to begin a tower defense game. | If the life meter is not empty, the user will be able to begin a game. |
| Game screen (currency) | 008 | As a player, I want to see how much currency I have. | The user is able to see how much avaliable currency they have while purchasing towers. |
| Game screen (play button) | 010 | As a player, I want to be able to begin a tower defense game. | When the button is selected, the game will officially begin. |
| Game screen (tower) | 003 | As a player, I want to be able to place my towers on the base. | When a tower is selected, the user can move the tower to their desired position. |
| Game screen (tower) | 008 | As a player, I want to be able to see the reach of my tower. | When a tower is selected, the user can see a red outlining of the tower's range. |
| Game screen (menu) | 007 | As a player, I want to be able to use different types of towers. | The user is able to view an array of towers avaliable for purchase. |


# Resource Management 
We will limit the number of unique enemys we have in the game. Instead of introducing a stronger type each level we will change up the combinations of enemies to increase difficulty. This lessens the number of assets we need for each enemy.
# Performance
We want to check that our game runs at the standard 60 fps and make sure our models are behaving in the enviroment, such as no clipping or gitching out.

# Error Processing
Unity has its own Error Processor built in, for example it will inform a user if they are missing a file needed to run the program. For the most part we will use this. 

# Build-vs-Buy Decisions
We are building off of a free version of the Unity editor, so we avoid having to create the application entirely from scratch. We also have access to many free assets from the internet so we won't have to worry about making any 3D models from scratch as well. 

# Change Strategy
As we finalize the design of each weapon and enemy, we may see them evolve from the early conception. We plan to finish the initial concept first and then implement what we can in the time we have left. While we encourage change we want to focus on having a complete product first.
