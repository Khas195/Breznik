# Process Journal - Tung Cao

This is the process journal of Tung T. Cao the programmer in the group.

First thing first, I do unserstand that a journal should be written as things happened not after. So instead of trying to fabricate this journal as if I was written it that day, I will just be straight forward and say that it was written after all the events had happened. As such, this is not much of a journal but rather my own reflections and assetments looking back at them. __Well with all things, however, there is always an exception, an outliar if you will, and that would be the "Initial Thought" section because that was written at that time.__

This journal will be written from sprint to sprint. The reason for that is because we worked closely with each other during the project so by writing from meetings to meetings would be quite difficult. Of course, all the important events such as Playtest session, milestone presentation or break points in the process of making this game will be included as well.

As the programmer of the project, most of my sprints are revolved around programming tasks. At least, until after the milestone presentation where I am more involve with the Narrative design of the game. Also near the end, I started to redesigned the level so it makes sense gameplay-wise while coordinating with our environment artist for a more artistic view on the game. 

So in the end, I guess, I can say that I am Programmer, a Narrative Designer and a Level Designer.

---
### Before The final protype

For the final prototype for True story class, Me and Chris decided to work together on this one. One of the many reasons is that we had already decided before the semester even started that we were going to work together with Chris being at the helm. 

It was a logical decision since  Chris wanted to be the vision keeper for this semester and I, who was vision keeper for 2 previous semesters, was kind of worn out. I didn't understand the role of the vision keeper and most of the time, it seemed more like just project management. 

I wanted to focus more on game design and game programming on this semester and less on the managing people side of game development. 

Thus, me and Chris had a conversation about what the game should be and it was clear then that he wanted was an Open world Role playing game. Though we had a glimpse of the story we wanted to tell, The story about the grandma and Krstoslav. Said story would be combined with a simple combat gameplay (Sword fighting) to create the game.

![Early Visualization](./process-journal-TungCaoImages/EarlyVisualization.jpg "Early Visualization")

We also came up with the goal of the player in the game as well. The inital goal, was not a treasure hunt but rather trying to collect these memoirs of the grandma after she had passed away. Of course, we didn't want to show in directly but via sub-text in the game.

![Goals](./process-journal-TungCaoImages/GameGoal.jpg "Goals")

 I believed we lacked a unique game mechanic. It was weird at the time, how can our game be lacking of uniqueness ?. We had a very cool and unique story, not to say that a story about a child and his grandma had never been told before, but the context and the details are fairly our own.

I didn't understand. I felt that the game was lacking, boring if it didn't have its own unique gameplay but so is Zelda. Zelda has a unique story, sure, just like ours and its gameplay was pretty straight forward. It is basically you using your weapon to defeat some enemies in your path. So I didn't know why hitting enemies in Zelda felt different, as in a different experience, from hitting enemies in dark soul or the witcher. 

With that said, I did texted Chris and let him known, on the weekend, that the game was lacking said gameplay feature. Though, to be honest, I couldn't come up with any game mechanic or gameplay that is fun and unique to cope with our story and basic combat during that week, so I instinctually pushed the task of thinking of it to him, since he was the vision keeper afterall. It was one of those mistakes, as a game designer, that I really regret making.

---
### Initial Thoughts (Wednesday, 16th October 2019)
Just finished writing all readme files. It makes the bitbucket repository a better place to live in with all the readmes rather than the wasteland of code and resources. Though some of the readmes need to be look at by the whole team like Readme for the overview of the project, readme for the process, to do list, ...

Was trying to decide whether Hacknplan or Trello is a better choice. Trello can be linked with bitbucket rather easy. Cannot say the same for Hacknplan, however. At the end, I choosed Hacknplan cause it looks cooler.

Setting up the code documentation using doxy gen was rather easy. Though not all files are documented, I will do so as I have to touch them in the project. Rather dissapointing when I can't open the index.html file on bitbucket to view the code documentation. 

The project, overall, seem to be ambitious. The project has like 10 weeks left and I think atleast 3 weeks is needed for polishing. That leave us with around 7 weeks for production. The 3 big coding tasks, as I can imagine in my head, should be the combat system, the Quest system and the AI for the monster. I think the combat system, which should look somewhere like zelda, Breath of the wild or Pine, can be done in 2 weeks of time. The question system can be done in 1 week and the AI should be done in 2 weeks. Which leave me 2 weeks left to make all the other stuff like the Menus, in-game UIs stuffs, fixing bugs....

---
### First meeting (Thursday, 17th October 2019) 

As the name suggest, this was the very first meeting we had since the forming of the group on the previous True Story class which was on a tuesday. 
We basically decided on the things needed for the first playtest. 
They were mostly basic game mechanics and game animations that was gonna be there regardless of the project such as combat system and some fighting animations. 
We also did all the technical stuffs such as naming convention, management tools, What everyone's jobs and roles was in the project. More can be read in the [To-do](../to-do.md).

Good news is, I had written most of the thing we discussed in the to-do file inside the project. 
Bad news is that I had written the to-do for only that meeting. My thought process was that with hacknplan as out management task, the to-do will be obsoleted. Whether it is true or not, I guess, can be seen in this "Journal" because only the first meeting was written based on the to-do and the others based on hacknplan.

---
## Sprint #1 (October 16th to November 4th, 2019)

---
### First Half (October 16th to October 28th)

This sprint lasted quite long, since it was because it is a combination of the first meeting, the drafting week where we were concepting ideas for the game. And we were running late at the end, since the 2nd sprint was starting when this sprint was still going on.

For me though, the first haft of this sprint, I was working on the combat system in the game. I did create the task for the combat system and later realized that is was very ambiguous. I mean, the task was literally called "Combat system". What kind of combat system ?, How should it feels ?, can we dodge or roll ?, Is there attack animation cancel ?.  

Well, I did later on add a different task called the "Character an change combo and hit things". Which was a bit clearer than just "Combat System". Though, it sill sucked.

![RunAndHit](./process-journal-TungCaoImages/runandHit.gif "RunAndHit")
![RunAndHit](./process-journal-TungCaoImages/runandHit2.gif "RunAndHit")

#### A Better Setup
Though, it was not said in the previous semester but I had already developed a different setup than most people do for all of my Unity Project.
The setup aimed to reveal as much information as possible to the user (as in Unity editor, as in Me). 

One of my grudges with having a normal set up is this:

![Normal](./process-journal-TungCaoImages/normalSetup.png "NormalSetup")

This is so claustrophobic, it is hard to find information from this. You are either forced to add more code into one script or you can add more scripts into one object which would lead to the same problem. 

![Normal](./process-journal-TungCaoImages/NormalSetup2.png "NormalSetup")

And if you see the above on unity, what can u really tell about the game object. How many scripts are running in it ?.

As such, unless absolutely necessary, I would never add script straight to the object that it is affecting.

![](./process-journal-TungCaoImages/bettersetup.png)

So all of the scripts, affecting the host object, would be in the Behavior node and each script in one object. Each of them will have a  Host object reference back to the game object that it is affecting. Like the example above, One can tell how many scripts are running on KrstoslavScaledWRig_Model.

It is, by no mean, a perfect system and there are still many limitations that I am trying to work around it. One of these limitations are physic callbacks and finding the script in in the game object.

#### Miscellaneous 

Other than that, I also added this really cool thing. If there is a missing reference in a script in a gameobject then an angry emoticon will appear next to the game object in the hierarchy. 
![](./process-journal-TungCaoImages/iconInEditor.png)
To be honest, we didn't use it that much because it causes too many random errors and not work as intended.  Something to develop next semester I guess.



All these preparation was for the first playtest session which was going to happen on the 22nd of October, which was the week after that week. More on the review of that playtest can be see below.

#### Playtest session #1 (Tuesday, 22nd October 2019)
Thinking back about it, I think it was unnecessary because it kind of defeats the goal of a playtest session which is to test certain gameplay elements. What did testing the combat system and some attack animations helped us with the design of the game. We all had certain expectations of what the combat should be or ought to be. Unless we introduced something new about said combat system, which we did not, there was not really any purpose of playtesting it. 

It is a good learning experience for future projects, playtests should have a purpose of actually testing actual elements in the game. Either it is a completely new elements or a combination of old elements that we want to see if it actually works . 


---
#### Second Half (October 28th to November 4th)
For the second half, which started on the 28th of October, I worked on the Inventory System, Pickup items and I did fix the jittering of the camera movement.

##### Inventory System (Finished November 2nd) 
For the Inventory system, I design it with the MVC model in my mind at the time. I didn't draw the design for it, unfortunately, but the same design would later on be apply for the quest system in the game. 

It basically has a Inventory System class, Inventory UI Manager Class and Inventory class. Where the Inventory system class handles all the flow of data from Inventory itself to the UI manager and vice versa while the Inventory handles the process of the data and the Inventory UI manager handles all the showing of said data to the screen. 

And the result :

![Inventory](./process-journal-TungCaoImages/testInventoryView.gif "Inventory")

For the 3d cube in the inventory, I used a different camera viewing it from the distance. The camera does not render it to the screen but rather to a render texture. To which having an image on the canvas drawing the rendered texture instead. It was quite cool at the time.
##### Picking Up Items (Finished November 2nd)
The pickup item was pretty straight forward where you collect the item's data then send it to the Inventory System. The Problem, believe it or not, resides in who is suppose to be showing the pick up text in the game and where should the pick up text be. 

Should the InventoryUIManager shows it ? or should I add a script inside the character to show it, since that script would had more information on how and when to show the pick up text. Mainly because there's a trigger collider event for whenever an item enter its range. As such it is easier to send this signal to something inside the character rather than some god manager in the scene. 

Both of them could works, of course. It is just the matter of the correct responsisbily of these objects. Ended up using the small interaction script inside the character instead. 

The decision was made because we also going to have the talking to NPC. It is also an interaction that need a text to highlight it. Furthermore, the Inventory UI Manager shouldn't be worrying about interaction with the NPC.

A lot said just for this:

![PickupText](./process-journal-TungCaoImages/pickupItem.gif "Pickup text")


##### Fixing the Jittering on the camera (Finished November 2nd)

Well, I think this image said all that need to be said.

![Fixing Camera](./process-journal-TungCaoImages/fixingCameraJiterring.png "Fixing Camera")

---
## Sprint #2 (October 28th to November 18th, 2019)
One might wonder why was this sprint started while the other sprint was running. This was where we made the first mistake in project management, I would say. Instead of sending tasks that was not finished to the backlog then start a new sprint, we started a new sprint and add new tasks there. This result in some sprints running for a very long time.

So for this sprint, there are 3 big tasks that I was able to get done which was the AI behaviour, The Quest System and the integration of attack animations.

Of course, besides that, there are also miscellaneous tasks that I was able to get done as well.

### Let's there be Intelligence (AI Behavior or behaviour) 
Now, for this task I would like to split it into 3 sections. The controller, The behaviors themselves and the pathfinding. 
#### The Controller
Ever since I thought of __The Setup__ I thought above, I always been thinking of how should I control a character in the game. I used to combine the Input for a character and the behavior of the character themself into one gigantic character script.

I stopped doing that since it always creates trouble  whenever I approach the AI. Moreover, I had always been thinking of changing the character I control in game and if I made a huge script then it wouldn't be impossible.

Then I thought of controlling a puppet instead. You know, no matter the puppet if I rig it with string I can control it. 

![](./process-journal-TungCaoImages/puppet.jpg)

So I started to look at the character script not as the big script where I do all my character related things. I began to split it into different parts. 

We have the controller part, the character and it's behaviors. This is not the same as the behaviors that I'm gonna talk about in the next section, however. What I meant is moving, attacking, jumping, e.t.c. 

I did separate some of the character's behaviors but I gotta say it was not worth it due to complexity reason.

On the other hand though, seperating the input and the character did wonders.

![](./process-journal-TungCaoImages/controllerCharacter.png)

Where the player controller will control the character and the character do what the character do without knowing who is controlling it.

![](./process-journal-TungCaoImages/snippetRequestJump.png)

so if I want my character to jump I just request jump then the character will check if he can jump. If he can he will jump, otherwise he will not. This is extremely useful since the controller doens't need to know all the nuisances like when can this character jump, how does this character jump and so on. Same can be apply for attacking, rotating and moving.

![](./process-journal-TungCaoImages/characterRef.png)

Of course the character is assigned in the editor. This kind of sepration create special oppotunities in the future where we can switch the character ref at any point in the game and it would still works. This is a saying I've been telling my group "you guys are always one drag away from playing anything character in the game". Which was true, since we have this:

![](./process-journal-TungCaoImages/crabboWalk0.gif)
![](./process-journal-TungCaoImages/playAsChicken.gif)

To be honest, though, at the time that I made this speration. I didn't even thinkg that this was possible. As you can see, the footage above is way later in the project.

#### The Behaviors
The behaviors are the decisions that the AI made in the game. For example, whether he should continue to chase a target or should he return to patroling.

To achieve these behaviors in game. I choosed to follow Unity's Pluggable AI for a couple of reasons. 

One of them is because it is pluggable. Hmm, to further explain this, I have to show the end result first. So in the game, the Ai can do the 2 following things: He can make decisions and he can do actions.

The amount of actions that he can do depends on his current state.
With each decision, he can change into a different state or stay in his current state.

![AI State](./process-journal-TungCaoImages/chaseState.png "AIState")

In this example, we are in the chase state, as such, the action that we will perform would be the Chase action. Of course, a state can do more than one action if so desired. 

After each action, it will run through all the decisions that it can make. In this case The ActiveState decision decides whether chasing action is still possible. In our case, it is whether the chase target is still alive. Then, if it is true then we will continue chasing by remain in the state. Otherwise, we would go to the patrol state and perform the actions and decisions there.

Of course, because all of these decisions and actions are scriptable  object, so is the state itself. We have the freedom to create, drag and drop to change the behavior of our AI. For Further implementation, check my code inside the project or follow [Pluggable AI with scriptable Objects](https://www.youtube.com/watch?v=cHUXh5biQMg&list=PLX2vGYjWbI0ROSj_B0_eir_VkHrEkd4pi)

#### The pathfinding

One would think that this might be the easiest thing to do in the game, since unity has its own pathfinding system such as Agents and the Navmesh. The problem with using the unity's agents is that the agent dictates the movement of our game object or character. 

![Agent](./process-journal-TungCaoImages/agent.png "agent")

We didn't want that because we had our own movement system that was already implemented. 

---
### In Class, True Story (Tuesday, 5th October 2019) 

---
### Weekly Meeting #5 (Monday, 11th November 2019) 

---
### Project Week (Monday, 11th November 2019 - Sunday 17th November 2019) 

---
### Weekly Meeting #6 (Monday, 18th November 2019)

---
### In Class, True Story (Tuesday, 19th November 2019) 

---
### Playtest Session #2 (Tuesday, 19th November 2019) 

---
### Rehearse Milestone presentation (Monday, 25th November 2019)

---
### Milestone presentation (Tuesday, 26th November 2019)

--- 
### Working together At Neon Wood (Saturday, 30th November 2019)

---
### Weekly Meeting #7 (Monday, 2nd December 2019)

---
### In Class, True Story (Tuesday, 3rd December 2019) 

--- 
### Working together At Neon Wood (Thursday, 5th December 2019)
Canceled Hari and sarah are sick
Freddy is out of town

--- 
### Discord Talk (Thursday, 5th December 2019)
Doing discord talk instead

--- 
### Working together At Neon Wood (Friday, 6th December  2019)

--- 
### Working together At Neon Wood (Saturday, 7th December 2019)

--- 
### Weekly Meeting #8(Monday, 9th December 2019)

---
### In Class, True Story (Tuesday, 10th December 2019) 

---
### Working together At Neon Wood(Saturday, 14th December 2019)

--- 
### Weekly Meeting #9 (Monday, 16th December 2019)

---
### In Class, True Story (Tuesday, 17th December 2019) 

---
### Playtest session #3 (Tuesday, 17th December 2019) 

--- 
### Discord Talk (Thusday, 19th December 2019)
Freddy not there

---
### Chrismas Break (Monday, 22nd December - Sunday, 5 January )

---
### Conclusion (Unidentify date)

