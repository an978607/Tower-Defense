# Program Organization
  ## Context Diagram 
  
 ![System_Context_diagram](https://user-images.githubusercontent.com/54637213/107887604-3c148800-6ed5-11eb-8f1b-ba1d79692017.png)
 
 The context diagram is a very simple look at how our program acts. The user runs our application, 3D Tower Defense, and then our program uses the Unity Library to give them a complete experience. 
 
 ## Container Diagram
 
 ![Container_Diagram](https://user-images.githubusercontent.com/54637213/107887888-46378600-6ed7-11eb-929b-297a75875a82.png)
 
  This breaks down what our program encases. Stored in our program is a library which houses all of our 3D assets and scenes. These are ran in a Unity application, but the user has a interface that limits there control in the enviroment as to the rules of our game. 
 
 ## Component Diagram
 
 ![Components](https://user-images.githubusercontent.com/54637213/107887900-5f403700-6ed7-11eb-9d6b-6f6d1d2b28b1.png)
 
 Inside our Unity Application we have a look at the different items we want it to have for our player. These are catered more towards our user stories, having the ability to make adjustments to settings as well as getting to interact with the enviroment to win the game.
 
 
| Block       | User Stories |
| ----------- | ----------- |
| Start Screen| As a player, I want to be able to begin a tower defense game (010)|
| Settings    | As a player, I want to be able to make adjustements to my play style (011)|
| Pause Contol| As a player, I want to be able to pause and continue where I left off (012)|
| Preperation | As a player, I want to be able to place my towers on the base (003)|
| Attack      | As a player, I want to be able to fire at the enemy (004)|

# Code Design 
  
  ## UML Class
  ![UMI_Class](https://user-images.githubusercontent.com/54637213/107887973-d4ac0780-6ed7-11eb-9092-b274b0707559.png)
  
  With this diagram we can see how each class in our programs relation with each other and the methods and attributes that are assigned to them. I've left empty slots in this chart for now. such as enemy 1 and weapon 1, because the Enemy and Weapon classes will have many instences of each we just haven't solidified what they will be exactly. 
  
  | Class       | User Stories |
| ----------- | ----------- |
| Player | As a player, I want to see how much currency I have (008), As a player I want to see my score/stats (002)|
| Tower    | As a player, I want to be able to see the current status of my Tower (013)|
| Weapon | As a player, I want to be able to fire at the enemy (004)|
| Enemy | As a player, I want face an increasing challenge over time (009)|
  
  ## UML Activity
  ![UML_Activity](https://user-images.githubusercontent.com/54637213/107888180-d1654b80-6ed8-11eb-9633-9065397cbb74.png)
   
   This is a flow chart of the activities that occur in our program. We can see that most or our activities have multiple out comes, and our game is initially a loop that increases difficultly the further the player gets. The user starts the game, they then get to set up their arsenal, but they are limited by how much money they have. They then start the attack phase and depending on the outcome of that they either progress, start again, or exit our game.
  
  ## UML Sequence
  ![UMI_Sequence](https://user-images.githubusercontent.com/54637213/107888286-581a2880-6ed9-11eb-82a7-cda5140ab450.png)
  
  This shows a sequence of events that happens when using our program. Since our application does not connect to any other networks it is active the entire time the user is interacting with it. Its a back and forth relationship. These connections greatly mirror our UML activity chart since they both walk through a play by play.
# Data Design
![ER (1)](https://user-images.githubusercontent.com/54637213/107888329-8e57a800-6ed9-11eb-984a-d92c3ca4cf51.png)
Our program doesn't use a large data base, like for example bank records. But it is crucial that we store Towers, Weapons, and Enemy types as they control the flow of the entire game. Each entity interects with the other in a specific way to create the scenario of our application.  

# User Interface Design

# Business Rules

# User Interface

# Resource Management 

# Security 

# Performance

# Scalability

# Interoperability

# Internationalization/Localization

# Input/Output

# Error Processing

# Fault Tolerance

# Build-vs-Buy Decisions
We are building off of a free version of the Unity editor, so we avoid having to create the application entirely from scratch. We also have access to many free assets from the internet so we won't have to worry about making any 3D models from scratch as well. 

# Change Strategy

