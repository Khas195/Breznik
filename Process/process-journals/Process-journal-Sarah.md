# Process Journal - Sarah Junger

My role in Krstoslav, or now called Breznik, was mainly being the Environment and Texture Artist with a little bit of Level Design on the side.
My process journal basically consists of a small overview that I've written down after meetings or sprints:

---

The goal of "True Story" project class was to kick off with an idea for a game with the help of an experience/story from people. Each member of the class had to come up with two prototypes. When Chris presented his adventure game idea with lovely visuals, I was sold.
Lucky me, I was also able to be part of the group working making this project come true.

### First Meeting

After coming together as a group, we decided to meet up for our first meeting to lay the groundwork for the project. We pretty much brainstormed content ideas like having a quest system, collectible items, a combat system and even discussed UI elements like having a health and stamina bar.
In order to have a neat and tidy folder overview system, we determined a naming convention for models (ex. tree_model), textures (ex. tree_tex), animations (ex. character_anim) and much more.
Chris also presented us the map layout for the game. It included three main areas: the village, the field and the forest. I was going to be in charge of creating the forest.
Before the meeting was set, I had already worked on a iteration of the forest in Unreal Engine and the layout of my scene got approved by our vision keeper Chris.

---

### Sprint 1

For the first sprint nothing major happened. I was diving into Substance Designer again for a basic stylized grass and ground texture. My research for this week revolved around finding a good concept for the forest.
Since we were working in Unity instead of Unreal, I had to look for a proper way of creating the level terrain. First, I was reluctant to use the terrain feature which Unity provided since it's still a problematic integrated tool in the engine. 
Although, once I got accustomed to using it, was appreciating the possibilty to create a terrain from scratch which I could individually form and texture to a certain degree.


---

### Sprint 2

By the second week into the project, a greybox level layout of the forest was in order. With the plugin terrain tool, I replicated the size and structure from the hand-drawn map from the first meeting and my first design in Unreal.
Speaking of forest, I made the first version of a possible tree. I found this vertices transfer method which allowed for a shaded lighting on the leaves. It works like the following: with planes you make the basic shape of the leaves and then you put it all around a sphere. Afterwards you create this canope which surrounds the "leaves" and transfer the vertex normals.
The results for the leaves were nice BUT the polycount was questionable as well as the weird shininess to the leaves once you put a material with the albedo texture on it.
I tried fixing it with turning down the metallic roughness, still the shine was not going away. 
Working with my trusty Substance Designer again, I created a tree bark texture. The texture didn't get used until much later in the game though. In Zbrush, I quickly sculpted a trunk which would be suitable for the upcoming milestone presentation.
Relatively late into the week, I suddenly got assigned as the lead level designer/artist for the whole scene, so I had to compose a concept version of the village (I'm not talking about the house designs, it was more the idea of having an elevated village design).
The funny thing is, the day I was proposing the elevated village approach, Hari posted an image of an elevated town concept to Discord.

---

### Sprint 3/4

As project week was going on, barely anything happened that week on Krstoslav on my part.

---

### Milestone

It's "Milestone" presentation time! As it always happens, we presented the current state of the project to the other groups and professors.
At this point, we had the combat system, enemy AI and quest system ready.


The milestone as the name suggest was a huge turning point for our game.
Next Tuesday, the week after the milestone Mr. Berger felt that our current state of the game seemed dull and generic. He proposed the idea of having a "unique" gimmick for our game that would set it apart from the typical adventure-exploration genre.
The idea of having floating islands instead of a compact terrain was born but the group at this moment was still a bit indecisive and reluctant if we actually want to go for this approach.

20th of November was the decisive day where we were set on the "island scheme".


---

### Sprint 5


As the island idea was now in full swing, I changed the terrain to imitate three separate elevated places. The only problem that I had was, that the unused terrain was not deletable. 
I was also not set on the idea of sculpting the islands as models due to the fact that I wouldn't have been ablet to change the height or textures in the engine on the models. Another big challenge were the tree leaves. Remember when I mentioned that the polycount was too high for having a number of trees?
That now posed a performance problem and stubborn me, who wanted fluffy leaves, still haven't found an alternative at that point in time.

A major change in our meeting schedule was taking place during sprint 5. Usually we met up for a weekly meet and work on Monday but that changed drastically.
Now we reserved Moday, Wednesday (not for me since I had classes on that day), Thursday (sometimes), Friday (partially) and Saturday (mainly) for group meetings. Mondays were there to determine new sprint plans for the followig week.

### Christmas was three weeks away at this point and we changed the render pipeline to HDRP because our naive selves thought this was a brilliant idea. IT.WAS.NOT!

Until Saturday the 7th of december I painted some textures for the foliage. On our meeting, Tung suggested that I change the jumping pathway that connects each island from a "linear" path to and "s-curve" as it made the level more interesting to go through.
At that moment we learned how HDRP is an absolute garbage festival. The whole point why we changed from SRP to HDRP was a to have a decent post-processing tool and making the game look better in general but it only caused material problems, terrain problems and the water shader was not working anymore.
---

### Sprint 6

Saturday the 14th I modelled a chest for putting in the treasures which the player should collect throughout the game. I even made an interactable animation for opening the chest.
Wanting a big tree for the character to wake up under, I made a model in Maya. I mentioned that, when using the terrain to form the islands, we had space that we didn't use but couldn't delete, so Chris had me model and texture one sample island first.
HDRP as the c**t is was, displayed the textures in such a horrible way that I wasn't sure if my textures are shite or Unity's lighting.

Approaching Monday the 16th, I changed the other trees again to their final version in the game.

---

### Sprint 7

18th of december was marking a ray of light for our project. In the course "7 styles a week", we were able to play around with SRP and this is were I used my models for setting up a sample scene and realized that luckily my texture skills were not the problem but the render pipeline and lighting.

Swish swoosh, our render pipeline changed back to the standard render pipeline!

Holidays started and my task was to replace every island formed on the terrain with a proper individual model.

---

### Sprint 8

The last few days arrived until us having to upload the build to itch.io.
Tung changed the level layout again, and made it much more interesting than our previous version. I made some minor floating platform adjustments though but ultimately re-added platforms that formed "stairs" after Tung's plead to reintegrate it into the game again.

It would have been amazing if the grass and leave swaying script would have worked for the final build but that was not meant to be, sadly. It would have conveyed the feeling of being high up in the air much better and would have made the scene more lively.

Two days before the build, I inspected some props that the others made. Let's say I was not happy with the inconsistency of stylized and suddenly realistic textures.
So my final task for the project was to re-texture all the important models as well as re-model them as the polycount was sometimes insane (I'm talking about you, 1000 faces crate!).

Applying finishing and decorating touches like painting grass and foliage meshes with Polybrush on the models and swaping out models, the game was as good as ready.

---

