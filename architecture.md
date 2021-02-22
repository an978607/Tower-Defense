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
![UIOutline](https://user-images.githubusercontent.com/78228038/108651579-1288cd00-7490-11eb-9d83-77796cf2e690.png)
- The start screen is the opening screen that provides the user with the name of game. There is a play button and a settings button.
- When the user presses play, the level selection map will be viewed. The level selection map allows the user to assess their current status in terms of their current level, remaining lives, and available currency. 
- When the user selects an unlocked level, the game will begin. Before the first wave of enemies enter, the user will be able to view and purchase available towers. Their current currency amount will be easily viewable in the corner of the screen. When a tower is selected, the user will be able to see the range of the tower. The user can use the exit button to view the base in full view. When the user has completed setting up their base, they will press the start button to begin. When they start, the wave counter will be shown.
- When the current game ends, a win or lose screen, with avaliable scores/stats, will be shown and the user will exit to return to the level selection map.
- In the store, users can purchase additional currency for the game.
- In the settings, the user can adjust the game music and audio levels to their preference. The exit button allows them to return to the start page.

| Component | User Story | Explanation |
| ------------- | ------------- | ------------- |
| Start screen | As a player, I want to be able to see the world map. (001) | The start button takes the user directly to the world level selection map. |
| Level map (levels) | As a player, I want to be able to see the world map. (001) | The user is able to see all the levels and recognize thier current level. |
| Level map (levels) | As a player, I want to be able to begin a tower defense game. (010) | When an unlocked level is selected, the user will begin the game. |
| Level map (currency) | As a player, I want to see how much currency I have. (008) | The user is able to see an accurate reading of their current avaliable currency. |
| Level map (lives) | As a player, I want to be able to begin a tower defense game. (010) | If the life meter is not empty, the user will be able to begin a game. |
| Game screen (currency) | As a player, I want to see how much currency I have. (008) | The user is able to see how much avaliable currency they have while purchasing towers. |
| Game screen (start button) | As a player, I want to be able to begin a tower defense game. (010) | When the button is selected, the game will officially begin. |
| Game screen (tower menu) | As a player, I want to be able to place my towers on the base. (003) | When a tower is selected, the user can move the tower to their desired position. |
| Game screen (tower menu) | As a player, I want to be able to see the reach of my tower. (008) | When a tower is selected, the user can see a red outlining of the tower's range. |
| Game screen (tower menu) | As a player, I want to be able to use different types of towers. (007) | The user is able to view an array of towers avaliable for purchase. |


# Resource Management 
We will limit the number of unique enemys we have in the game. Instead of introducing a stronger type each level we will change up the combinations of enemies to increase difficulty. This lessens the number of assets we need for each enemy.

# Performance
We want to check that our game runs at the standard 60 fps and make sure our models are behaving in the enviroment, such as no clipping or gitching out.

# Scalability
Once the program has a solid foundation, we should be able to add in a new weapon, enemy, or tower fairly easily. We shoulf be able to add in new levels or difficulty without having to start all over again.

# Internationalization 
As on now we have no desire to focus on having the code be able to easily be transcribed to any other language. We will have our code be organized visually enough that it may be possible to understand it without knowing English.

# Input/Output
Since all of our classes do interact with each other, We need to make sure that we are consistently updating their current whereabouts to see if they should still be able to run. Meaning we may want to have multiple ways to see if the tower is still standing or the enemy has been defeated.

# Error Processing
Unity has its own Error Processor built in, for example it will inform a user if they are missing a file needed to run the program. For the most part we will use this. 

# Fault Tolerance
Making sure to test each object in their respective class. There is plenty of faults we could run into, but as an example the user could have enough money for an upgraded tower but our price checker says otherwise. We could have alternate code to run in case the first function returns the wrong answer.

# OverEngineering 
Clearly we want our program to run as smoothly as possible with no errors. Realistically with so much user input we may run into complications. For this we will try to keep are code as simple as possible to avoid restricting the user. We want are program to continue running even if there is an error in another aspect. 

# Build-vs-Buy Decisions
We are building off of a free version of the Unity editor, so we avoid having to create the application entirely from scratch. We also have access to many free assets from the internet so we won't have to worry about making any 3D models from scratch as well. 

# Reuse
Our enemies, towers, and weapons will all branch from the same corresponding class, this is seen in the Code Design diagram. They will have a separate mechanic added to differentiate them and add to the play style. 

# Change Strategy
As we finalize the design of each weapon and enemy, we may see them evolve from the early conception. We plan to finish the initial concept first and then implement what we can in the time we have left. While we encourage change we want to focus on having a complete product first.
