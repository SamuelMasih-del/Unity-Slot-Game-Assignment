# Unity 3-Reel Slot Game - Assignment

A complete 3-Reel Slot Machine game made in Unity (C#) with RNG, Winning Logic, Balance/Bet system and Smooth Reel Animations.

## Features
- 3 Reels with smooth spinning animation and slow-stop effect
- RNG based result - Random.Range() for fair spin
- Winning Logic: 3 of a Kind = Jackpot, 2 Match = Small Win
- 6 Symbols: Cherry, Lemon, Bell, Bar, Seven, Diamond
- Balance System: Start with 1000 coins
- Bet System: Increase / Decrease bet (10 to 200)
- Win Effects: Win Panel + Particles + Jackpot message

## Payout Table
- 3x Diamond = MEGA JACKPOT 1000
- 3x Seven = 500
- 3x Bar = 300
- 3x Bell = 200
- 3x Lemon = 100
- 3x Cherry = 50
- Any 2 Match = 20

## Project Structure
Assets/Scripts/
- SlotManager.cs - Main game controller, Spin logic, Balance
- ReelController.cs - Reel spinning animation, Infinite scroll
- WinCalculator.cs - Payout calculation, Win check
- UIManager.cs - UI update, Win effects

## How to Play in Unity
1. Open Unity Hub > Create New 2D Project
2. Copy Assets/Scripts folder into your project
3. Create Canvas with 3 Reels, Spin Button, Balance/Bet Text
4. Attach SlotManager to GameManager object
5. Assign Reels, Symbols, UI in Inspector
6. Press Play and Click SPIN!

## How It Works
1. Player clicks SPIN -> Bet deducted from Balance
2. RNG generates 3 random symbols (0-5)
3. Reels spin one by one with slow-down effect
4. WinCalculator checks result and calculates win
5. Balance updated, Win message shown

## Tech Used
- Unity 2021+ / 2022+
- C# - Coroutines for animation
- TextMeshPro for UI

## Author
Samuel Masih - Slot Game Assignment
