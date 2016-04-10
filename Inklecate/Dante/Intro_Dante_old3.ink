=== Intro_Dante_Step_1 === 
You awaken in a bed in a strange room. A odd assortment of trinkets and tapestries adorn the walls and floor. A man is lying in a bed next to yours. He turns to you and smiles.
* [Hello?]
	You: Uh ... hello?
	???: Hello, my name is Dante.
	
* [Who the hell are you?]
	You: Who the hell are you?
	???: My name is Dante. 

-You: Where am I, Dante?
Dante: You are in my home. I had my bodyguards seek you out.

* [Bodyguards?]
	You: Bodyguards?
	Dante: Yes, bodyguards. They are stationed outside.
* [How did you know to find me?]
You: How did you know to find me? I've never met you before.
Dante: I sensed a great power surge due east of here.
You: Right ...

- So what happened? All I remember is talking to some guards outside ...
VAR CorrectResponse = false
* [Zion]
	... Zion?
	~ CorrectResponse = true
* [Zooblyboop]
	... Zooblyboop?
	~ CorrectResponse = false
* [Zipford]
	... Zipford?
	~ CorrectResponse = false
* [Zonkos]
	... Zonkos?
	~ CorrectResponse = false
- { 
	- CorrectResponse: 
	Dante: Ah yes, Zion.
	- else:
	Dante: I think you might mean Zion?
  }

- Dante: I have a small favor to ask of you.
  You: Okay? What is this favor?

  Dante: I need you to find a weak spot. This is essentially a thin strip of the fabric of the universe.
  You: Right ...

  Dante: Is this all making sense?
  	* [No]
  	You: Not really ... but continue ...
  	Dante: Fair enough, my friend. It will come in time.
  	* [Hell no]
	You: Not at all.
	Dante: You will understand eventually.
- You: Right, sure it will.
Dante: So you need to find this weak spot and open a portal to another dimension...

You: Let me just stop you right there.
Dante: Please listen. I need you to open this portal and send in my bodyguards to kill a criminal. He has a ring on him; a very powerful ring, a very dangerous ring. I need you to kill him and return this ring to me.
->END