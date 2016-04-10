//	./inklecate -p  SaveTheWorld.ink

=== Paragraph_One === 
You must make a choice!
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Save Maria!]
    No, that can't be right ...
    -> Paragraph_Two

=== Paragraph_Two === 
//You must make a choice!
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Save Maria!]
    No, that can't be right ...
    -> Paragraph_Three

=== Paragraph_Three === 
//You must make a choice!
*   [Save the world, kill Maria!]
    I choose to save the world!
    -> Save_The_World
*   [Kill Maria!]
    I choose to kill Maria!
    -> Save_The_World

=== Save_The_World ===
The world has been saved!
-> END