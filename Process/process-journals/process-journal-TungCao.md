# Process Journal - Tung Cao

This is the process journal of Tung T. Cao the programmer and narrative designer in the group. I do unserstand that a journal should be written as things happened not after. Nevertheless, it was written after all the events had happened. As such, this is not much of a journal neither a story but rather my own reflections and assetments looking back at them. __Well with all things, however, there is always an exception, an outliar if you will, and that would be the initial thought section.__

This journal will be written from sprint to sprint. The reason for that is because we worked closely with each other during the project so doing from meetings to meetings would be quite hard. Of course, all the important events such as Playtest session, milestone presentation or break points in the process of making this game will be included as well.

As the programmer of the project, most of my sprints are revolved around programming tasks. At least, until after the milestone presentation where I am more involve with the Narrative design of the game. So in the end, I am both a programmer and a Narrative designer.

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
### Weekly Meeting #2 (Thursday, 24th October 2019)
discord group 

---

### Weekly Meeting #3 (Monday, 28th October 2019) 
discord group created

---

### In Class, True Story (Tuesday, 29th October 2019) 

---
### Weekly Meeting #4 (Monday, 4th November 2019) 

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

