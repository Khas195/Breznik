KRISTOSLAV

Short description.

Copyright (c) YEAR by Tung T. Cao <tungthanhcao1091995@gmail.com>, Christopher Bukal Chilicuisa <christopher.bukal.chilicuisa@gmail.com>, Frederic Wendt <frederic.wendt.98@gmail.com>, Sarah Junger <junger.sarah@web.de>, Hariharan Anpalagan <hari82302@gmail.com>


List and link to software required to build and run here.
 - Unity 2019.2.6f1

Getting Started

- For any scene to be played a game object of Persistence_pfb need to exist. The scene of which you play FIRST in the Unity Editor required a Persistence_pfb (except for the loading scene). Then navigation between each scene can be done via the in game's UI.

Explain where to start to understand your project. Name the main script or the main scene.

- Any entity in the game is setup as follow: 

    - Character Entity:

        - Character Model: contains all models that this entity has. Also include rigidbody, colliders if needed.

        - Behavior: Contains any scripts that is needed to run this entity.

            - Each script should has it's own game object as holder for clarency. 

            - These Holders should be the child of the game object behavior.

            - As such each script need to have a property called "hostGameObject" or "host" to signalfy which model that it is working on.

            - Normally, all properties that are exposed to the Unity Editor are compulsary properties that are needed to be assign by the user in the Unity Editor. 



License

MIT License

Copyright (c) [2019] [Tung T. Cao]

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.