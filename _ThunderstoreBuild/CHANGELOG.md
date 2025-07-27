# 0.1.5
Additional stability updates with local data. Also text box for goals! Hit reload with the ArchipelaGun to show and hide the text box.

- Item history should persist without needing to pull from server multiple times.
- Stability update to randomizer completion check
- Now sending multiple location checks in single server call
- Added Archipelago Info Box
	- Automatically opens when connecting to server
	- Reload on the Archipelagun open/closes menu
- Added console command to standard console (default to tilde key) to send command to Archipelago console
	- In format 'archipel console [input A] [input B] [etc]'
- Added unit test system, should speed up testing between versions

# 0.1.4
Major refactor of randomizer progress to local save files. This should make the Archipelago Server connection much more stable. Please.

- Count data no longer sent to server, now saved locally
- Added last connection fast connect, Reload on run start to load the last valid connection!

# 0.1.3
Stability fixes!
- Check to only handle 1 deathlink event per run
- Error fallback on item give to stop the loud loop error
- Delaying initialize events on successive runs to picking up Archipelagun
- Tentatively removed misfire beast from shuffle
- Fix to enemy shuffle error

# 0.1.2
Emergency hotfix to stop debug writer writing GB's worth of text data.
My bad,

# 0.1.1
Major update adding multiple new features tied to APWorld update

**V0.1.1 expects APWorld V0.1.1**

- **Reload on the ArchipelaGun cycles connection**
	- Reconnecting will prioritize pulling stats not already pulled	
- Paradox Mode implemented
	- Character swap restricted until corresponding item received for character
	- Character item checks!
- Reverse Curse implemented
	- Gain 8 curse (either after 1 Past is cleared or immediately)
	- Item Check to reduce curse created "Reverse Curse Reversal"
- Shop items can now be replaced by APItem
	- Replaced items will have their sprites flipped and display 'AP Item' as their name 
- Chest items now only replace every other chest
- When Mastery Chambers are given, an APItem will spawn
- Infuriating Notes automatically given if Resourceful Rat is marked as game completion on server
- Bullet to the Past automatically given if Pasts are marked as game completion on server
- Location checks make sense on the server now!!
- Milestones added as location checks
	- Floor Clears
	- Pasts cleared
- Fixed endless recursive enemies on enemy swap logic 

# 0.0.8
Debugging!

- When an exception occurs a crash log is placed in the BepInEx root folder
- Entering 'debugtool fullDebug' will also write the crash log
- Reload with the ArchipelaGun swaps between the first 6 characters
        - Setting up for future Archipelago item check


# 0.0.7
Multiclient Newtonsoft.Json exception fix. Now mod should only have ArchipelaGun.dll and c-wspp.dll

# 0.0.6
Major fixes around Multiclient & websocket issues

- Using async calls for server pulls to reduce performance hitch
- Fixes items not being received, items not sent synced up will be sent at room clears
- Additional debug commands under the 'debugtools' category in the Mod Menu
- Disconnect command
- Fallback cases on data being set below 0

# 0.0.5
- Fix to bug breaking core behavior on returning to Breach
- Fix to bug breaking core behavior on restarting a Run
- Fix to co-op breaking functionality
- Deathlink now properly kills Player 2, then Player 1
- Disconnect archipelago command implemented
- Added Deathlink toggle
- Added images to main page readme
	- Archipelagun, lil buddy!

# 0.0.4
- Renaming to match github versioning
- Hotfix for sprites layout

# 0.0.1
- Initial upload
