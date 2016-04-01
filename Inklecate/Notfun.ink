=== Table_of_Contents === 
* Simple
-> Simple
* Simple Options (Doesn't hide text)
-> Simple_Options
* Simple Options (Does hide text)
-> Simple_Options_Hides_Text
* Multiple Options and Loop back
-> Multiple_Options
* Keep Option In Loop
-> Keep_Option_In_Loop
* What if you run out of options?
-> Fallback_Option
* Knot Example (See file)
-> Knot_Example
* Do you have the required Level?
-> Mission_Requirement_Example

=== Simple === //No spaces or characters treat this as a file name! This is code.
"Paragraphs of line" said by Person A. 
"That's cool" said by Person B.
-> END //This is how you do "paragraphs" this goes to Paragraph_Two

=== Simple_Options === 
This is how you do options.
*   Option 1
    Option 1 text goes here.
-> END

=== Simple_Options_Hides_Text ===
This is how you hide the options from the result.
	*   [Hide Option]
    	Text goes here.
-> END

=== Multiple_Options ===
	Multiple_options
	* Option 1
	Option 1 text.  
	-> END

	* Option 2
	Option 2 text.
	-> END

	* Option 3
	Option 3 text.
	-> END

	* Loop back
	This will loop back.
	-> Multiple_Options

=== Keep_Option_In_Loop === 
	* Option 1 (Disappears)
	This one dissapears.
	-> Keep_Option_In_Loop
	* Option 2 (Disappears)
	This one dissapears.
	-> Keep_Option_In_Loop
	+ Option 3 (Stays)
	This one stays.
	-> Keep_Option_In_Loop
	* End
	-> END

=== Fallback_Option ===
	* Option 1
	Gone
	-> Fallback_Option
	* Option 2
	Gone 
	-> Fallback_Option
	* []This is your fallback text //Notice no space betweeen []This
	-> END

=== Knot_Example === //They call it knots shrugs.
	(Look in the code to understand this)
	* Knot 1 Default
	-> Store_Knots //This will always be the default "First Knot" (name doesn't matter, in this case it's called First_Knot).

	* Knot 1 
	-> Store_Knots.First_Knot

	* Knot 2
	-> Store_Knots.Second_Knot

=== Store_Knots ===
 = First_Knot //These are sub sections, accessed by the . syntax.
 First Knot
 -> END

 = Second_Knot
 Second Knot
 -> END

VAR Level_2 = false //This can be a number or anything else, I used a boolean just cause. 
 === Mission_Requirement_Example ===
 	* Level up
 	~ Level_2 = true 
 	-> Mission_Requirement_Example
	
	+ {Level_2 == false} 
	[You are not level 2!] 
	:( 
	-> Mission_Requirement_Example
	
	+ {Level_2} 
	[You are Level 2] 
	:) 
	-> END


