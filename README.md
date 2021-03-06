# Design Patterns and Software Development Process
## Exercise 1 – Monopoly by PELET Quentin & PUJOL Corentin

### 1. Introduction 

Objective of the project is to simulate a simplified version of the Monopoly™ game. Indeed, the players will only have to make turns on the board without the system of buying properties and monopolies that can be found in the complete version. The only constraints will be the "Jail" box, the "Go to jail" box, replay if you make a double and finally players will also go to jail when they make three doubles in a row. In addition, if a player is in jail and makes a double, then he/she goes out, moves on and his/her turn ends.

### 2. Design Hypotheses (specification and explanation of details not explicitly indicated in the project assignments, but required for the solution’s design and implementation) 

Monopoly™ is a game played by 2 to 8 players, on a board with dices and pieces moving from square to square in a clockwise direction. So, to design our game, we decided to create the following set of objects:

•	The dices

•	The board

•	The game squares

•	The players

•	The players' pieces

•	The game

#### a)	Singleton pattern

Let's recall the definition of a Singleton pattern: it is a design pattern that guarantees that the instance of a class exists in only one copy, while providing a global access point to this instance. However, the game is played on a single board with two dice and these are unique. It is therefore wise to use the Singleton pattern when designing these objects that are unique during a game of Monopoly™.

Board design and development:


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/1.JPG)


The tray is made up of the list of Monopoly squares, as well as an instance of the Board instance class, which allows us to check in the GetInstance function whether the tray object has already been created, in which case we return the previously created tray. Its character is therefore unique in our application.

Dices design and development:
Likewise for Monopoly dices, there are only two in a game of Monopoly:


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/2.JPG)


In the same way, the dice are instantiated once and only once with the same reasoning.


#### b)	State pattern

In this version of Monopoly, players move from square to square and change state only when they fall on the "Go to jail" square, or when they make three doubles in a row. In order to model the changes in player states, we have chosen to use the State pattern to simplify and make the management of the different states more efficient and simple.
The state pattern proposes to create new classes for all possible states of an object and to extract the state-related behaviours in these classes. This allows the behaviour of an object to be modified when its internal state changes.
Rather than implementing all the behaviours of itself, the original object stores a reference to one of the state objects that represents its current state. It delegates all state manipulation to this object.

So, this is how we wanted to model and develop the Player class:


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/3.JPG)


We have created a State interface, which allows us to define the functions that handle state changes:
 
 
![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/7.JPG)


Here, we only have the go and get out of jail options, but if we had wanted to implement a Monopoly with all these rules, we could have put in the other states such as: On start box, On property box, On community or lucky box, On taxes box, etc...

This interface is implemented in the player class which stores its current state, as well as in the state classes "Jail" which defines the state of a player in jail and "OutJail" when the player is not in jail.


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/4.JPG)


### 3. UML diagrams

#### a)	Class diagram of the solution 


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/5.JPG)


#### b)	Sequence diagrams (at least, one sequence diagram of one solution’s use case) 


![alt text](https://github.com/corentin-pujol/Monopoly/blob/main/6.png)

### 5. Additional / Final remarks (optional)

We had thought of using two other patterns, but Monopoly being simplified, it was difficult to implement them. However, as an opener, we will list the things we would have thought of doing if the project was a full Monopoly:

Factory pattern
First of all, we thought of using a Factory pattern to design the different types of boxes that exist in Monopoly. Indeed, the Factory pattern is a design pattern that defines an interface to create objects in a parent class, but delegates the choice of the types of objects to be created to the subclasses. 
This choice seems judicious because by creating a parent class Case, we can specify all the details of the other cases in different subclasses such as: the stations, the distribution companies, or the various other monopolies present in the game.

Strategy patterns
In addition, we also thought of the strategy pattern to model the different choices that a player has to make when they land on a square: buy the square, pay the rent if it is already owned, draw a card if it is a luck or community square, etc...
The strategy pattern is particularly suitable because it allows to manage more simply the behaviour of the player and the choices he can make when he arrives on a square, by modelling the different choices in subclasses to the player's one which stores an action to be performed as an attribute. This pattern is very similar to the state pattern we used above.
