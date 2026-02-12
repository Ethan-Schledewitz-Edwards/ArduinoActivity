Controller design challenge


Today, February 11th, we came to class prepared with two Arduino kits from the Game Lab. Once the instructional portion of the lecture ended, we decided to replicate Mario Kart, which we would control using a custom Arduino controller. Not long into the activity, we realized that neither of the Arduino kits had breadboards. Fortunately, Professor Alvaro lent us one of his breadboards, enabling us to complete this assignment.
The Unity game portion of the assignment and most of the documentation were completed by Ethan. During class, Ethan created a simple Unity scene with primitives. The player could drive around the scene by steering using A and D and accelerating using the Spacebar. The Unity scene was intentionally left with low fidelity, as our focus for this project was controlling the player using the Arduino controller. 
After class, the input code was modified by Andrew to read inputs using the .NET serial ports API using the custom Arduino controller. The state of the controller is sent over the serial bus as a 1 byte bitfield. This allows Unity to simply read the next byte on the serial port each frame without having to deal with synchronization issues.
In the simple Unity scene, the player can drive Mario around.



The physical build portion of the project was handled by Andrew. Additionally, Andrew helped with documentation. During class, he built the custom controller using the Arduino, a breadboard, three buttons, and wires.




Video link of the final controller paired with Unity:
https://drive.google.com/file/d/1XyWlxGcK7aqdEueH65RGttYl1nn4N6o_/view 
