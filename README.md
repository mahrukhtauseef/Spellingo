# Spellingo

**Spellingo** is a fun, interactive Unity-based app designed to help children (especially first graders) learn how to spell commonly used English words in an engaging way. This project was built using Unity with a focus on rapid prototyping and educational design.

---

## What It Does

- Presents a cartoon image and plays audio of the word (e.g., “cat”).
- Lets children type the spelling of the word using letter buttons.
- Encourages retrying if they misspell the word.
- Rewards correct answers with sound effects and visual celebration.
- Offers the option to see and hear the correct spelling.
- Cycles through multiple common first-grade words.

---

## Why This Project?

> _"Learning to spell can be demotivating. I wanted to make it playful and interactive."_  
> — Mahrukh Tauseef

Research shows that many adults in the U.S. struggle with English spelling. This app addresses the root of that challenge — spelling education in childhood — with an inviting, tech-forward experience designed to help kids succeed early.

---

## Key Features

- **Grade 1 Word Carousel:** Includes 9 high-frequency Fry words like `ball`, `cat`, `book`, etc.
- **Touch-to-hear functionality:** Tap a picture to hear the pronunciation.
- **Phonics reinforcement:** Optionally spells the word aloud.
- **Positive feedback system:** Encouraging audio + visual celebration.
- **Panels and transitions:** Seamlessly switch between spelling, retry, success, and review panels.

---

## Scripts Overview

| Script Name     | Purpose |
|----------------|---------|
| `MenuScript.cs` | Controls navigation between grade levels in the main menu. |
| `WordCarousel.cs` | Manages the word flow, feedback, and transitions in Grade 1 mode. |
| `TypeLetter.cs` | Updates the typed word when a letter button is pressed. |
| `AudioManager.cs` | Handles all sound playback, including intro, word pronunciation, and feedback. |
| `LoadMenu.cs` | Returns the user to the main menu after completion. |

---

## UI & Visuals

- Colorful cartoon images
- Large tap-friendly buttons
- Positive, low-pressure UI design
- Custom font and background styling

---

## Audio Integration

- Word pronunciations
- Celebration sounds (`Tada`, `CongratSpeech`)
- Encouragement and retry audio
- "See the word" phonics breakdown

Audio clips are dynamically loaded from the `/Resources/Sound` folder.

---

## Words Used (Grade 1)

- `ball`, `bed`, `book`, `boy`, `car`, `cat`, `dog`, `girl`, `man`  
These are drawn from the Fry high-frequency word list appropriate for early readers.

---

## How to Run It

1. **Install Unity Hub** (Recommended Unity version: 2022.x or higher)
2. **Clone this repo:**
   git clone git@github.com:mahrukhtauseef/Spellingo.git
3.	Open the project in Unity.
4.	Press ▶️ to run the app inside Unity.
5.	Navigate from the Main Menu to try Grade 1 spelling.


### Resources and guides

- [Canvas & UI in Unity](https://www.youtube.com/watch?v=mNioSjbbEIs)  
- [Adding Buttons](https://www.youtube.com/watch?v=gSfdCke3684)  
- [Working with Panels](https://www.youtube.com/watch?v=dZ7wrUV11io)  
- [Audio Integration in Unity](https://www.youtube.com/watch?v=iNRl7b9RQpw)  
- [Voice clips generated with Typecast AI](https://typecast.ai/text-to-speech/68484cdbfae5b3396539f7ec)  
- [Free sound effects from Pixabay](https://pixabay.com/sound-effects/)  
- [Fonts from Google Fonts](https://fonts.google.com/)

---

### Project Inspiration

This app was built as part of the **LIVE Learning** challenge — a rapid prototyping exercise to build creative tools for learning. After reading that many adults in the U.S. struggle with spelling, the idea was born to make spelling fun and rewarding at the foundational level. This project is a small step toward playful, tech-supported learning.

---

### Demo Preview

[![Watch the demo](https://img.youtube.com/vi/i8EyyrIMYtE/0.jpg)](https://www.youtube.com/watch?v=i8EyyrIMYtE)

---

### Feedback & Contributions

You're welcome to:

-  Fork the project (Grade 2 and Grade 3 can use your help!)
-  Report bugs
-  Suggest new features
-  Reach out if you're an educator or researcher

Feel free to [open an issue](https://github.com/mahrukhtauseef/Spellingo/issues) or email me at **mahrukh.tauseef@vanderbilt.edu** — I’d love to hear from you!




