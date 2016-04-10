//Prelude:
//You have been rescued by Dante's 'men'/'bodyguards', Dante has been injured by Serulian and is weak and unable to leave his home.
//You 'are a great [power/force] and can help in dispatching 'some evil man (Serulian)'
//Serulian has been locked away in the Dimension //World/Otherworld Dimension and is trying to find a way out; Dante knows that he will, given enough time. Therefore he intends to send his bodyguards to dispatch of Serulian. For this, he needs you to reopen and sustain the portal until his bodyguards return.
//Player is led through the 'Dimension City' and gets to see how the citizens think and react to certain situations

=== Intro_Dante_Step_1 === 
You awaken in a bed in a strange room. A odd assortment of trinkets and tapestries adorn the walls and floor. A man is lying in a bed next to yours. He turns to you and smiles.
* [Hello?]
	You: Uh ... hello?
	-> Dante_Knots.Polite_Hello
	
* [Who the hell are you?]
	You: Who the hell are you?
	-> Dante_Knots.Rude_Hello

=== Intro_Dante_Step_2 ===
<>y name is Dante.
* [Continue]
	You: Where am I, Dante?
	Dante: You are in my home. I had my bodyguards seek you out.
	-> Intro_Dante_Step_3

=== Intro_Dante_Step_3 ===
* [Bodyguards?]
You: Bodyguards?
-> Intro_Dante_Step_4a
* [How did you know to find me?]
You: How did you know to find me? I've never met you before.
-> Intro_Dante_Step_4b
*[] -> Intro_Dante_Step_5

=== Intro_Dante_Step_4a ===
Dante: Yes, bodyguards. They are stationed outside.
* [Continue]
You: Okay ...
-> Intro_Dante_Step_3

=== Intro_Dante_Step_4b ===
Dante: I sensed a great power surge due east of here.
* [Continue]
You: Right ...
-> Intro_Dante_Step_3

=== Intro_Dante_Step_5 ===
So what happened? All I remember is talking to some guards outside ...
* [Zion]
... Zion?
-> Dante_Knots.Correct
* [Zooblyboop]
... Zooblyboop?
-> Dante_Knots.Autocorrect
* [Zipford]
... Zipford?
-> Dante_Knots.Autocorrect
* [Zonkos]
... Zonkos?
-> Dante_Knots.Autocorrect

=== Intro_Dante_Step_6 ===
You: Oh yeah, you're right ... Zion.
-> Intro_Dante_Step_7

=== Intro_Dante_Step_7 ===
Dante: Hmm, Zion is an interesting city.
* [Continue]
-> Intro_Dante_Step_9

=== Intro_Dante_Step_9 ===
Dante: I have a small favor to ask of you.
* [Continue]
You: Okay? What is this favor?
-> Intro_Dante_Step_10

=== Intro_Dante_Step_10 ===
Dante: I need you to find a weak spot. This is essentially a thin strip of the fabric of the universe.
* [Continue]
You: Right ...
-> Intro_Dante_Step_11

=== Intro_Dante_Step_11 ===
Dante: Is this all making sense?
* [No]
You: Not really ... but continue ...
-> Intro_Dante_Step_12a
* [Hell no]
You: Not at all.
-> Intro_Dante_Step_12b

=== Intro_Dante_Step_12a ===
Dante: Fair enough, my friend. It will come in time.
-> Intro_Dante_Step_13
=== Intro_Dante_Step_12b ===
Dante: You will understand eventually.
-> Intro_Dante_Step_13

=== Intro_Dante_Step_13 ===
You: Right, sure it will.
*[Continue]
-> Intro_Dante_Step_14

=== Intro_Dante_Step_14 ===
Dante: So you need to find this weak spot and open a portal to another dimension
*[Continue]
You: Let me just stop you right there.
-> Intro_Dante_Step_15

=== Intro_Dante_Step_15 ===
Dante: Please listen. I need you to open this portal and send in my bodyguards to kill a criminal. He has a ring on him; a very powerful ring, a very dangerous ring. I need you to kill him and return this ring to me.
-> Intro_Dante_Step_16

=== Intro_Dante_Step_16 ===
* [Mission Start!]


-> DONE
-> END

=== Dante_Knots ===
=Polite_Hello
???: Hello, m
-> Intro_Dante_Step_2
=Rude_Hello
???: M
-> Intro_Dante_Step_2
=Correct
Dante: Ah yes, Zion.
-> Intro_Dante_Step_7
=Autocorrect
Dante: I think you might mean Zion?
-> Intro_Dante_Step_6
