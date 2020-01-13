# Process Journal
### Christopher Bukal Chilicuisa

This is the journal of my experiances working on this project. The entries are semi-regular, attempting to log a summary of as many meetings as possible, supplemented with my own thoughts.
The entries were noted on a personal item, and will be transribed onto the repository after the fact.

---

## 15th October, 2019.
This is the day where the process can arguably said to truly have started. On this day we were to present our third, and final game prototype, after which we would all vote on the availabe prototypes and 
the chosen ideas would select their team.

I should detail the idea I had. My concept was admittedly quite nebulous; it was more of a feeling accompanied by visuals and actions than it was a proper game concept. 
I am someone who prefers games with what I would call physicality, which is to say, a game in which the paler controls and contextual character or avatar, and that avatar 
serves as a conduit to the player's actions, and may interact with the world of the game. These are typically first, or third-person action/adventure games. A game which
allows me to jump at will (and gives me a high degree of control in this process) is far more likely to appeal to me that one that does not (notable exceptions being games such as _Dark Souls_, etc.).

Added to this is my preference for combat in games (or perhaps not '_combat_' per se, but a way to actively engage with the environment, such as in the game _Portal_), my concept was of a third-person game 
where the player would control a boy-like character from a small village with a certain number of characters to interact with, and a surrounding area filled with threats to combat. The tone was to be cheerful
and adventurous. The whole idea was based on my experiences as a child playing around in my grandmother's village with my cousin.

The problem which was not so clear to me then, but which is painfully obvious to me in retrospect, is that I had no clear ending, or even central conflict around which the events of the game would revolve.
This did not deter me, however, as I was excited to work on this immagined venture; though this leads me to my second fatal mistake. My main interest through working on this project was to dive deeper
into the pipeline of creating 3D characters, retopologizing them, texturing them, rigging them, and finally animating and implementing them in the Unity engine. I viewed the project through this lense, 
and that lead me to neglect much more vital elemnts concerning the project.

Nevertheless, Tung had already previously agreed to work with me regardless of what project I would come up with. And with them, Hariharan, Frederic, and Sarah had all decided to join.

As for the tasks to be assigned, my choices were thus: Tung, obviously would handle the code, as he is by far the most advanced among us in this respect, I would handle the character designs, modelling, 
and animation, Sarah would be resposible for the environment (as she had already stated that she was skilled in this area, and wished to work on it), and Fredi would handle the modelling of the houses (as
he similarly expressed a wish to do so). Hari was an uncertainty; I knew his personal preference would be to to programming, but considering that that position was already filled, and Tung's reluctance to 
work with another, I appointed him the position of modelling various hard-surface props.

The rest of the class was spent talking amongst eachother, with me trying to explain a more detailed conept for the game, and Tung going over the tools we would work with in the production.

---

## 17th October, 2019.
We held our first meeting the following Thursday. The point here was two-fold: go into more detail on the tools we had chosen to use (Hacknplan, SmartGit), also deciding on a nameing convention, and to
determine what we would do for the fast-upcoming playtest. We had less than five days to com eup with something playable, as a sort of proof of concept.

We decided the best way would be to do everything in graybox. Meaning, a rudimentary box-character with animations, for running, jumping, and attacking, with the environment also being constructed out of
Bare blocks.

Later, Tung would bring up a point concerning this early playtest which I agree with, which is that a playtest this early on in the production doesn't really serve any constructive point, as our ideas
aren't yet a t the level where we would be testing certain game design decisions.

---

## 22nd October, 2019.
We were introduced to big boards this class.

We started quickly writing down ideas and elements we wanted in the game. I expressed I wanted an sense of vagueness and abiguity. I wanted to acheive this through the presence of anachronistic elements,
such as early 20th century houses along with 1980s electronics. Additionally, I wanted the player to feel excitment when ecnountering enemies, as opposed to caution or fright. At first we agreed to simply
put up as many things as we could think of, regardless of priority, and to sort them out in the coming weeks.

After this, we decided to hold regular weekly meetings where we would go over the developments through the week. Since Tung already had a ready library of handy scripts governing character movement, I 
gave him the task of developing the basic inventory and quest systems we would need. The rest of the team each had the task of designing the laylout for their respective areas, Fredi would do the Village,
Sarah would do the Vorest, and Hari the Field. Additionally for each area we would have some kind of central marker: the Village would have the Grandmother's house, the Forest the small lake and cabin, and
the Field would have an abandoned barn.

We talked more about the narrative of the game and the motives behind it. My conception was that the narrative wouldn't be a concrete thing, more like a collection of humorous characters, and things to
find around the environment. The various narratives we would have int hte game would be told in large part through cues and indirect implications. Tung's conception however was much more ecplicitly
centered on the grandmother. I should probably state outright that Tung and I have very different ideas about what constitues good stories, and how storytelling should be approached. Neither is correct
in their view, of course, but this can lead to clashes. To be specific, Tung suggested several ideas in which to approach the narrative, such as there being two stages of the main character, one as an
adult, and one as the child. The game would be us--the player--as the adult revisiting old locaions which would activate '_memory_' sequences played out as a child. I strongly objected to this, as it would
completely went counter to my original vision and spirit of the game.

Additionally we were one week into our first sprint--periods of time during which we would try to accomplish certain tasks--and here is where my work load would be the most intensive. I had to sculpt,
retopologize, and texture the main character.

---

## 28th October, 2019.
Third meeting.

With the character modelling and texturing done, my next tasks for the sprint were to create a rig for the character and animate him.

For Fredi, I had him create three iterations for the village houses based on various reference house images I found on the web. Sarah was to complete a ground and grass texture, and additionally to 
look into how best to create a terrain in Unity, as the default tool is quite limited for what we wanted, or needed, to accomplish. Hari had to create a model for the scarecrow.

Tung, evidently, had enough skill to think of appropriate tasks for himself, so I assumed a more advisory role when it came to delegating his tasks.

I sent out the character model to everyone, so that they could model the environemnt to the correct scale.

---

## 4th November, 2019.
My mind is almost entirely on the character production.

I completed the rigging ahortly after the last meating. The weight painting gave some headaches, but it didn't take too long thankfully. For some reason I really struggled with the run animation.
Ironic, since the run animation for the graybox character was created in one draft. But after a day of effort, I arrived at a satisfactory, if somewhat anatomically exaggerated, result.
The jump and idle animations went suprisingly smoothly, I even had enough time to animate the attacks as a bonus, and implement the animations in Unity.

Sarah's textures were reassuringly good. She definitely knows her way around Substance Designer. Fredi's houses, while a good start, seemed a bit on the bland side. I asked to exaggerate the features
to make it feel more _cartoony_ but not overly so. I might have been a bit too vague with that request. I find I often suffer from a lack of words when trying to effectively convey a concept to others.
Hari's scarecrow had it's good sides; I know Hari isn't a modeller, nor wants to be one, so would have been unfair to task with complex models. 

We originally wanted to start holding one-week sprints, but considering that the following would be the project week, we were forced to make it a two-week one.

We had spent some time discussing enemies for the game. My first, rather obvious, idea was an oversized chicken with cartoon anrgy eyebrows (2D textures). Additionally, I thought of a feral pheasant
as an enhanced version of the chicken enemy. However, Tung pointed out that there would be too many bird themed enemies, to which I agreed, and scrapped the idea. A nother idea, partly for the ease
of its implementation, was the humble slime, sword-fodder in many an adventure. Tung had suggested we have a scene where a gang of crabs are dancing to music in the manner of the crab party meme.
My first thought was that animating _ten limbs_ would have been hell, but my personal liking for crabs made me not dismiss the idea, and I agreed under the condition that the crabs would be two-legged, 
making for a much more managable four limbs, counting their claws. We thought of having the scarecrows as enemies for the field, although this was still merely a suggestion. We also once contemplated
a toxic butterfly as an aerial enemy.

My task until the 18th was to create all attack animations, damage taking animaiton, and death animation for the main character, and to create and texture the Chicken, Crab, and Slime models.
Sarah was to design the foliage and to start the terrain layout fo rthe forest. Hari to create a graybox layout for the field, and model the barn. Fredi to iterate over the houses a second time, and to
create a graybox layout for the village.

---

## 5th November, 2019.
Today we had a consultation the Prof. Berger.
Upon viewing the game, he asked us what we hoped to accomplish through working on this project. I answered that I had hoped to develop my production and animation skills, which was true, due to the fact
that 3D animation had surprisingly appealed to me last semester. This--in retrospect--is another one of my mistakes, which is viewing this project in some part as an extention in the DCC course from last
semester, instead of focusing on design primarily. The others gave similar replies, and Berger noted that not one of us had mentioned creating a good game as a goal. This hit me as strange. It is true
that none of us had stated this, but to be honest I assumed that was implied, and the question was meant to ask us what practical skills we wished to work on, which might have been quite naïve of me.
Additionally, he bemoaned the fact that the game lacked ambition. Ambition? I thought. Surely a game with such complex production goals had no lack of it! However, Prof. Berger explained that he was talking
about ambition in a design sense. True--the idea for the game was entirely derivative, but I thought it was a bit unfair to so nonchalantly dismiss what I thought was good work. Prof. Berger left us with
the advice that we comu up with a hook of some kind.

To be honest, this meeting had me demoralized. I felt I had already set on a doomed project, and wasting not only my time but also the time of my fellow team-mates, it being too late to start thinking
of a completely new direction.

---

## 18th November, 2019.
The day before the second playtest. We tried to have no bugs for the following day, which was successful to a certain degree.
As for our sprint tasks, I had completed the enemy models and textures, they needed still to be rigged and animated. This was my task for next week. It seemed Fredi had constucted his houses by modelling
individual bricks and using them to build houses, and made the roofs similarly--_tile by tile_. I honestly did not think anyone would do that, but here we are. A major problem with this is that it would
be virtually impossible to UV unwrap such a building; one would have to unwrap each single brick and tile and beam. So I told him to remake the houses with simpler topology.

---

## 19th November, 2019.
During another consultation session with Prof. Berger, we decided that, intead of one great area, we would have each area situated upon a separate floating island, connected by minor 'platform' islands.
We didn't know how to accomplish this, as this would not be doable with Unity's native terrain tool.

--

## 26th November, 2019.
The day before the Milestone presenations we gathered in order to assemble the slides we each had individually made for our own parts into a whole. Sarah was not present so we had to improvise her part
during rehersal. The meeting was straight forward: we would start by introducing the idea of the game, then we would each talk about our roles in the team, finishing with a demonstration of the game.

The feedback we received on our presentation was quite less that positive. Prof. Csongor commented that the presentation had gone completely into the modes of production, and neglected the design elements.
As a result he got no sense of how the different parts of the game come together as a whole. One from the audience stated, in a tone I would describe as annoyed or agry even, that the game was generic.
Needless to say, I was not left feeling very spirited after our presentation. Perhaps I wasn't much for creating games, as much I was for creating assets for games, and I had childishly dived into waters
I was not ready for, and dragged a bunch of  unfortunates along. 

I asked Sam--who easily had the best presentation out of all the participating students--what I should do going forward. He answered that we should have someone focusing almost exclusively on the design;
how the game feels and plays, how the world looks, the narrative behind design elements. He finished with "those people are usually called visionkeepers."

Damn.

I asked all to meet the following Saturday at the Neon Wood where Sam is staying (since we usually socialize there).

---

## 30th November, 2019.
The purpose of the meeting was to determine our next steps. We discussed the lack of regular updates to our discord channel from Hari, Fredi, and Sarah, which lead to us not having an idea of where we
were progress-wise. Sarah protested, claiming that the frquent posts for TUng and myself were spam, and that she would prefer to restrict her posts to relevant updates. Fredi expressed a similar sintiment.


We came to the reasization that we would need to drastically scale down the scope of the game. We cut out all NPC's, and we decided to focus on the narrative between the main character and the grandmother.
The character would have to gather three items--the Cake, the Musicbox, and the Sweater--connected to the grandmother, and we would tell these stories through cutscenes which would appear as a series of hand-drawn panels non-verbally telly the
story specific to that item.

I also came to the realization that there was no real way to regain health in the game. So we decided that health would be replenished upon killin an enemy, making them both a drain on, and a sourfe of health.

---

## 2th December, 2019.
A short meeting was held to discuss minor mechanical tweaks, such as shaking the screen when landing an attack. We also decided that someone ought to start looking into sound effects, as we had completely
neglected sound design. We gave this task to Hari, which admittedly, was my default choice when something miscellanious had to be done. _This is probably not a good way to lead a team._

I am also noticing that the progress on the village houses is rather slow. I brought this up to Fredi, who assures me he will be dedicated to this task.

---

## 9th December, 2019.
I've created the cake prop, along with the table on which it will be placed. In addition, I made some props, a pot, a chair, and a shovel.

I gave Fredi the design the the grandmother's house. Hari was given the task to start developing particles.

I suggested we try moving from Unity's standard render pipeline to the high definition render pipeline. My reasoning was that Unity's default lighting method was quite underwhelming and I wanted to reach
a greater level of visual fidelity. Unfortunately this would mean completely reworking all the materials to HDRP materials.

---

## 16th December, 2019.
This was our last meeting before the Christmas break.

I spent most of the week creating rock props to bre used as level dressing. It might be a bit awkward as one can clearly see the rise in quality from the first one and the last one (about 9 in total). 
Along with these rocks, I created so-called slabs, larger rocks with one flat side, that would have a one of the item symbols engraved, and serve as a way marker.

We decided that we would achieve the floating islands by first making the general land masses with the terrain tool, and then exporting those to ZBrush and sculpt the islands using the exported geometry
as a reference, and then finally importing it back into Unity.

The move to HDRP was not without its hiccoughs. The free water shader Sarah had downloaded for the asset store would no longer work, and our old particle systems no longer worked (sometimes they would,
sometimes not, seemingly completely at random).

---

## 18th December, 2019.
During Seven Styles in Your Pocket today, we were introduced to The Illustrated Nature, an asset pack for creating a look that was very near to what we wanted. The kicker--it used the standard render pipeline.
So in a move that surely put me on everyone's blacklist (or make them create one with me as the sole member if they had no prior blacklist), I had everyone _revert back from HDRP to the standard pipeline_. 
This meant re-_re_-working all the materials back to their prior configurations. I hoped we would have done this by the end of Christmas break.

---

## Christmas Break, 22nd December - 6th January 2020.
During the Christmas break I didn't have as much time for the project as I had hoped. I managed to produce the music box, however.

Upon returning, Tung, Hari, and I met to work on our various projects (Sarah and Fredi had not yet returned to Berlin). I created the sweater prop, Hari was still tweaking his particle effects, and Tung
worked on designing the cutscenes for me to draw.

---

## 7th January 2020.
We had the meeting a day late since Sarah had only returned the evening prior.
I had finished the opening cutscene (and also the title screen). But this still left four cutscenes to finish (Cake, Musicbox, Sweater, and ending). Hari has made some surprisingly good props, he'd clearly
been practising. Their textures, however were a bit too realistic for the style of the game, and the models themselves had much too many polygons (in the thousands). We had given him the task of modelling the
grandmother's house since Fredi simply was not making any progress in that respect.

---

## 9th January 2020.
Today was the day we recorded music.
I managed to book the sound studio for a two-and-a-half hour slot. The Arsenal had no usb microphones, and the ones they did have required SD memory cards (not included), so I had reluctantly settled to recording
with my laptops built-in microphone, whatever the results. Thankfully, the studio itself had a microphone we could use, but the studio had someone else working there. So we were faced with a rather awkward
situation where Tung and I were recording me playing the guitar with a third party in the background.

Ultimately we managed to record three songs, one for each area, and the tracks for all the cutscenes.

---

## 11th January 2020.
The final stretch.
Here we focused on building a playable track through the game; making sure the cutscenes all played correctly, making sure that the symbols on the door of grandmother's house lit up correctly after picking
up the corresponding item, etc.

I found out that the song-file for the lake island had become corrupted, so we were left with two songs, which we decided to loop together for the whole game, irrespective of the area the player was in.

I created the title for the titlescreen, and implemented levitating rocks for a cool effect. I also fixed various unfortunate problems we rand into, regarding the disappearance of our 3rd party plugin's
folder. Meaning we had to reimport and reapply them.

---

## 12 January 2020.
Midnight today is the final deadline.

I help Tung with placing enemy patrol routes.

And just like that, we finished the project. Fourteen weeks of hard work has come to a close.

Today I begin transcribing my journal onto git.

---

# Closing Statement
In the early hours of the new year, the new decade, having just gone through a night of celebration, Sam, Tung, and myself found eachother sat in the lobby of Sam's Neon Wood talking about hardy, provocative
topics. At one point we turned towards discussing how I had managed to fail so thoroughly at leading a team. 

Now, Sam may have a tendancy to look on the bright side of things, but he is not one for dishonesty,
and such, he told me: 
My first mistake was assuming everyone had the same history of engagement with asset production as I. I had been animatig, coding, and modelling to some extend for years before coming to 
this university, and it was unfair of me to assume everyone else had the same experience as those who just last year were faced with so many new conepts.
My second, arguably deepest mistake was not starting with a core loop of the game. Again, I had gone into this semester as though it were DCC3; it wasn't and I should have realised that immediately, and not
potentially wasted a whole semester's worth of my classmates' time.
Another mistake was bad scoping. The project as originally envisioned would have taken many more months to achieve than what what we had at our disposal, so bein able to effectively scope a project to a given
time frame is a skill I am in dire need of improving. And of course, I did not learn to effectively delegate tasks to people according to their capabilities and interests. I believe this touches upon a deeper
problem within myself. I am not a very charismatic person, and social interactions are something I am very clumsy at, which makes me for a poor leader. Additionally, I am quite the poor salesman. When it comes
to convincing other people of the validity of my ideas, I fall utterly short. It is simply a skill I do not have. Every project I've worked on before was a lone project, and as such I never developed the
ability to justify creative decisions.

In spite of all the difficulties, and rough patches, I am still proud of the work we did, and deeply thankful to all the members who contributed their time and effort to the realization of the project.
None more so that Tung, who absolutely bore the lion's share of the work, as the coding and implementation were by no means trivial.
Going forward it is clear I have a great deal of personal work and growth to work on, and it is my hope that this will not go neglected.

I end my closing statement.

---
### Christopher Bukal Chilicuisa