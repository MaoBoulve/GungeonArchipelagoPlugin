using System.Collections.Generic;
using UnityEngine;

namespace NevernamedsItems;

public static class ActorTemplateGenerator
{
	public static Dictionary<string, Color> colourNameToDef = new Dictionary<string, Color>
	{
		{
			"red",
			Color.red
		},
		{
			"orange",
			new Color(1f, 48f / 85f, 0.16078432f)
		},
		{
			"yellow",
			Color.yellow
		},
		{
			"green",
			Color.green
		},
		{
			"blue",
			Color.blue
		},
		{
			"purple",
			new Color(57f / 85f, 0.08627451f, 0.9411765f)
		},
		{
			"white",
			Color.white
		},
		{
			"black",
			Color.black
		},
		{
			"pink",
			new Color(0.9490196f, 0.45490196f, 0.88235295f)
		},
		{
			"brown",
			new Color(0.2901961f, 0.08627451f, 1f / 51f)
		}
	};

	public static string GenerateActorTemplate(string TEMPLATEACTORNAME, string INSERTGUID, string MODPREFIX, ActorType ACTORTYPE, bool FLIGHTSTATE, AllAnimations Animations, float movementSpeed, float contactDamage, bool hasShadow, bool ignoreForRoomClear, bool killOnRoomClear, bool targetPlayersTrueEnemiesFalse, bool immuneToPits, float collisionKnockback, bool hasOutlines, bool canBeJammed, float actorWeight, float HEALTHMAX, bool INVULNERABLE, bool rigidBodyCollideWithOthers, bool rigidBodyCollideWithWalls, int RigidBodyOffsetX, int RigidBodyOffsetY, int RigidBodyWidth, int RigidBodyHeight, bool faceSouthWhenStopped, bool faceTargetWhenStopped, float hitReactionChance, bool DOBOSSINTRO, bool DOBOSSSPLASHSCREEN, string introAnimationName, string bossSplashScreenPath, string bossMusicEventName, string bossSplashScreenQuote, string bossSplashScreenSubtitle, bool verticalBossBar, string bossSplashScreenColour, bool useDefaultTargetBehaviour, bool useDefaultMovementBehaviour, bool stopWalkingWhenInRange, float desiredRange, bool lineOfSightRequired, bool returnToSpawnPointWithoutTarget, float spawnTetherRange, bool specificRange, float minRange, float maxRange, bool companionFollowsPlayer, string AmmonomiconSprite, string AmmonomiconPageSprite, bool showInAmmonomicon, string AmmonomiconShortDesc, string AmmonomiconLongDesc, int positionInAmmonomicon)
	{
		//IL_0335: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_062b: Unknown result type (might be due to invalid IL or missing references)
		//IL_05bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0921: Unknown result type (might be due to invalid IL or missing references)
		//IL_08b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c17: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bab: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f0d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ea1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1197: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_153c: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		string text = "";
		string text2 = "";
		string text3 = " ";
		if (FLIGHTSTATE)
		{
			text3 = "companion.aiActor.SetIsFlying(true, \"Flying Entity\");";
		}
		string text4 = TEMPLATEACTORNAME;
		text4 = text4.Replace(" ", "");
		string text5 = TEMPLATEACTORNAME;
		text5 = text5.Replace(" ", "_");
		string text6 = " ";
		string text7 = " ";
		string text8 = " ";
		string text9 = " ";
		string text10 = " ";
		string text11 = " ";
		string text12 = " ";
		string text13 = "";
		if (Animations.idleAnimation != null)
		{
			text6 = SetupAnimationSegment(Animations.idleAnimation);
			foreach (DirectionalAnimationData directionalAnimation in Animations.idleAnimation.DirectionalAnimations)
			{
				string text14 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list2 = new List<int>();
				foreach (AnimationFrameData frame in directionalAnimation.Frames)
				{
					list.Add(frame.filePath);
					list2.Add(list.Count - 1);
					string text15 = Animations.idleAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation.suffix))
					{
						text15 = text15 + "_" + directionalAnimation.suffix;
					}
					if (!string.IsNullOrEmpty(frame.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text15}\").frames[{list.Count - 1}].eventAudio = \"{frame.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text15}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text15}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame.frameXOffset / 16}f, {frame.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text15}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame.hitboxXOffset / 16}f, {frame.hitboxYOffset / 16}f, 0f);\n";
				}
				string text16 = ConvertIntListToString(list2);
				text14 += text16;
				text14 = ((!string.IsNullOrEmpty(directionalAnimation.suffix)) ? (text14 + "}, \"" + Animations.idleAnimation.animShortname + "_" + directionalAnimation.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation.wrap}).fps = {directionalAnimation.fps};\n") : (text14 + "}, \"" + Animations.idleAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation.wrap}).fps = {directionalAnimation.fps};\n"));
				text13 += text14;
			}
		}
		if (Animations.walkAnimation != null)
		{
			text7 = SetupAnimationSegment(Animations.walkAnimation);
			foreach (DirectionalAnimationData directionalAnimation2 in Animations.walkAnimation.DirectionalAnimations)
			{
				string text17 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list3 = new List<int>();
				foreach (AnimationFrameData frame2 in directionalAnimation2.Frames)
				{
					list.Add(frame2.filePath);
					list3.Add(list.Count - 1);
					string text18 = Animations.walkAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation2.suffix))
					{
						text18 = text18 + "_" + directionalAnimation2.suffix;
					}
					if (!string.IsNullOrEmpty(frame2.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text18}\").frames[{list.Count - 1}].eventAudio = \"{frame2.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text18}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text18}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame2.frameXOffset / 16}f, {frame2.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text18}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame2.hitboxXOffset / 16}f, {frame2.hitboxYOffset / 16}f, 0f);\n";
				}
				string text19 = ConvertIntListToString(list3);
				text17 += text19;
				text17 = ((!string.IsNullOrEmpty(directionalAnimation2.suffix)) ? (text17 + "}, \"" + Animations.walkAnimation.animShortname + "_" + directionalAnimation2.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation2.wrap}).fps = {directionalAnimation2.fps};\n") : (text17 + "}, \"" + Animations.walkAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation2.wrap}).fps = {directionalAnimation2.fps};\n"));
				text13 += text17;
			}
		}
		if (Animations.hitAnimation != null)
		{
			text8 = SetupAnimationSegment(Animations.hitAnimation);
			foreach (DirectionalAnimationData directionalAnimation3 in Animations.hitAnimation.DirectionalAnimations)
			{
				string text20 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list4 = new List<int>();
				foreach (AnimationFrameData frame3 in directionalAnimation3.Frames)
				{
					list.Add(frame3.filePath);
					list4.Add(list.Count - 1);
					string text21 = Animations.hitAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation3.suffix))
					{
						text21 = text21 + "_" + directionalAnimation3.suffix;
					}
					if (!string.IsNullOrEmpty(frame3.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text21}\").frames[{list.Count - 1}].eventAudio = \"{frame3.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text21}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text21}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame3.frameXOffset / 16}f, {frame3.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text21}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame3.hitboxXOffset / 16}f, {frame3.hitboxYOffset / 16}f, 0f);\n";
				}
				string text22 = ConvertIntListToString(list4);
				text20 += text22;
				text20 = ((!string.IsNullOrEmpty(directionalAnimation3.suffix)) ? (text20 + "}, \"" + Animations.hitAnimation.animShortname + "_" + directionalAnimation3.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation3.wrap}).fps = {directionalAnimation3.fps};\n") : (text20 + "}, \"" + Animations.hitAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation3.wrap}).fps = {directionalAnimation3.fps};\n"));
				text13 += text20;
			}
		}
		if (Animations.flightAnimation != null)
		{
			text9 = SetupAnimationSegment(Animations.flightAnimation);
			foreach (DirectionalAnimationData directionalAnimation4 in Animations.flightAnimation.DirectionalAnimations)
			{
				string text23 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list5 = new List<int>();
				foreach (AnimationFrameData frame4 in directionalAnimation4.Frames)
				{
					list.Add(frame4.filePath);
					list5.Add(list.Count - 1);
					string text24 = Animations.flightAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation4.suffix))
					{
						text24 = text24 + "_" + directionalAnimation4.suffix;
					}
					if (!string.IsNullOrEmpty(frame4.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text24}\").frames[{list.Count - 1}].eventAudio = \"{frame4.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text24}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text24}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame4.frameXOffset / 16}f, {frame4.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text24}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame4.hitboxXOffset / 16}f, {frame4.hitboxYOffset / 16}f, 0f);\n";
				}
				string text25 = ConvertIntListToString(list5);
				text23 += text25;
				text23 = ((!string.IsNullOrEmpty(directionalAnimation4.suffix)) ? (text23 + "}, \"" + Animations.flightAnimation.animShortname + "_" + directionalAnimation4.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation4.wrap}).fps = {directionalAnimation4.fps};\n") : (text23 + "}, \"" + Animations.flightAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation4.wrap}).fps = {directionalAnimation4.fps};\n"));
				text13 += text23;
			}
		}
		if (Animations.talkAnimation != null)
		{
			text10 = SetupAnimationSegment(Animations.talkAnimation);
			foreach (DirectionalAnimationData directionalAnimation5 in Animations.talkAnimation.DirectionalAnimations)
			{
				string text26 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list6 = new List<int>();
				foreach (AnimationFrameData frame5 in directionalAnimation5.Frames)
				{
					list.Add(frame5.filePath);
					list6.Add(list.Count - 1);
					string text27 = Animations.talkAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation5.suffix))
					{
						text27 = text27 + "_" + directionalAnimation5.suffix;
					}
					if (!string.IsNullOrEmpty(frame5.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text27}\").frames[{list.Count - 1}].eventAudio = \"{frame5.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text27}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text27}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame5.frameXOffset / 16}f, {frame5.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text27}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame5.hitboxXOffset / 16}f, {frame5.hitboxYOffset / 16}f, 0f);\n";
				}
				string text28 = ConvertIntListToString(list6);
				text26 += text28;
				text26 = ((!string.IsNullOrEmpty(directionalAnimation5.suffix)) ? (text26 + "}, \"" + Animations.talkAnimation.animShortname + "_" + directionalAnimation5.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation5.wrap}).fps = {directionalAnimation5.fps}\n;") : (text26 + "}, \"" + Animations.talkAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation5.wrap}).fps = {directionalAnimation5.fps}\n;"));
				text13 += text26;
			}
		}
		if (Animations.fidgetAnimation != null)
		{
			text11 = SetupAnimationSegment(Animations.fidgetAnimation, isFidget: true);
			foreach (DirectionalAnimationData directionalAnimation6 in Animations.fidgetAnimation.DirectionalAnimations)
			{
				string text29 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
				List<int> list7 = new List<int>();
				foreach (AnimationFrameData frame6 in directionalAnimation6.Frames)
				{
					list.Add(frame6.filePath);
					list7.Add(list.Count - 1);
					string text30 = Animations.fidgetAnimation.animShortname;
					if (!string.IsNullOrEmpty(directionalAnimation6.suffix))
					{
						text30 = text30 + "_" + directionalAnimation6.suffix;
					}
					if (!string.IsNullOrEmpty(frame6.frameAudioEvent))
					{
						text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text30}\").frames[{list.Count - 1}].eventAudio = \"{frame6.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text30}\").frames[{list.Count - 1}].triggerEvent = true;\n";
					}
					text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text30}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame6.frameXOffset / 16}f, {frame6.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text30}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame6.hitboxXOffset / 16}f, {frame6.hitboxYOffset / 16}f, 0f);\n";
				}
				string text31 = ConvertIntListToString(list7);
				text29 += text31;
				text29 = ((!string.IsNullOrEmpty(directionalAnimation6.suffix)) ? (text29 + "}, \"" + Animations.fidgetAnimation.animShortname + "_" + directionalAnimation6.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation6.wrap}).fps = {directionalAnimation6.fps}\n;") : (text29 + "}, \"" + Animations.fidgetAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation6.wrap}).fps = {directionalAnimation6.fps}\n;"));
				text13 += text29;
			}
		}
		if (Animations.deathAnimation != null)
		{
			Animations.otherAnimations.Add(Animations.deathAnimation);
		}
		if (Animations.pitfallAnimation != null)
		{
			Animations.otherAnimations.Add(Animations.pitfallAnimation);
		}
		if (Animations.spawnAnimation != null)
		{
			Animations.otherAnimations.Add(Animations.spawnAnimation);
		}
		if (Animations.awakenAnimation != null)
		{
			Animations.otherAnimations.Add(Animations.awakenAnimation);
		}
		if (Animations.otherAnimations != null && Animations.otherAnimations.Count > 0)
		{
			text12 = SetupOtherAnimationSegments(Animations.otherAnimations);
			foreach (WholeAnimationData otherAnimation in Animations.otherAnimations)
			{
				foreach (DirectionalAnimationData directionalAnimation7 in otherAnimation.DirectionalAnimations)
				{
					string text32 = "SpriteBuilder.AddAnimation(companion.spriteAnimator, " + text4 + "Collection, new List<int>{";
					List<int> list8 = new List<int>();
					foreach (AnimationFrameData frame7 in directionalAnimation7.Frames)
					{
						list.Add(frame7.filePath);
						list8.Add(list.Count - 1);
						string text33 = otherAnimation.animShortname;
						if (!string.IsNullOrEmpty(directionalAnimation7.suffix))
						{
							text33 = text33 + "_" + directionalAnimation7.suffix;
						}
						if (!string.IsNullOrEmpty(frame7.frameAudioEvent))
						{
							text = text + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text33}\").frames[{list.Count - 1}].eventAudio = \"{frame7.frameAudioEvent}\";\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text33}\").frames[{list.Count - 1}].triggerEvent = true;\n";
						}
						text2 = text2 + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text33}\").frames[{list.Count - 1}].colliderVertices[0] = new Vector3({frame7.frameXOffset / 16}f, {frame7.frameYOffset / 16}f, 0f);\n" + $"companion.GetComponent<tk2dSpriteAnimator>().GetClipByName(\"{text33}\").frames[{list.Count - 1}].colliderVertices[1] = new Vector3({frame7.hitboxXOffset / 16}f, {frame7.hitboxYOffset / 16}f, 0f);\n";
					}
					string text34 = ConvertIntListToString(list8);
					text32 += text34;
					text32 = ((!string.IsNullOrEmpty(directionalAnimation7.suffix)) ? (text32 + "}, \"" + otherAnimation.animShortname + "_" + directionalAnimation7.suffix + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation7.wrap}).fps = {directionalAnimation7.fps};\n") : (text32 + "}, \"" + otherAnimation.animShortname + "\", " + $"tk2dSpriteAnimationClip.WrapMode.{directionalAnimation7.wrap}).fps = {directionalAnimation7.fps};\n"));
					text13 += text32;
				}
			}
		}
		string text35 = "";
		string text36 = "";
		text35 = "bs.TargetBehaviors = new List<TargetBehaviorBase>{ //Add your target behaviours here!\n";
		if (useDefaultTargetBehaviour)
		{
			text35 += "new TargetPlayerBehavior{Radius = 1000,LineOfSight = false,ObjectPermanence = true,SearchInterval = 0.25f,PauseOnTargetSwitch = false,PauseTime = 0.25f,},\n";
		}
		text35 += "};";
		text36 = "bs.MovementBehaviors = new List<MovementBehaviorBase>() { //Add your movement behaviours here!\n";
		if (useDefaultMovementBehaviour)
		{
			text36 = text36 + "new SeekTargetBehavior() { StopWhenInRange = " + stopWalkingWhenInRange.ToString().ToLower() + "," + $"CustomRange = {desiredRange}," + "LineOfSight = " + lineOfSightRequired.ToString().ToLower() + ",ReturnToSpawn = " + returnToSpawnPointWithoutTarget.ToString().ToLower() + "," + $"SpawnTetherDistance = {spawnTetherRange}," + "PathInterval = 0.25f,SpecifyRange = " + specificRange.ToString().ToLower() + "," + $"MinActiveRange = {minRange}," + $"MaxActiveRange = {maxRange}" + "},\n";
		}
		if (ACTORTYPE == ActorType.COMPANION && companionFollowsPlayer)
		{
			text36 += "new CompanionFollowPlayerBehavior{IdleAnimations = new string[]{\"idle\"},}\n";
		}
		text36 += "};";
		string text37 = "";
		if (ACTORTYPE == ActorType.COMPANION)
		{
			text37 = "var companionController = companion.AddComponent<CompanionController>(); //Replace with a component of your choice that extends CompanionController if you have one, for special behaviours.\ncompanionController.companionID = CompanionController.CompanionIdentifier.NONE;";
		}
		string text38 = "";
		if (ACTORTYPE != 0 && showInAmmonomicon)
		{
			string text39 = TEMPLATEACTORNAME;
			text39 = text39.Replace(" ", "_");
			text38 = "SpriteBuilder.AddSpriteToCollection(\"AmmonomiconSprite\", AdvEnemyBuilder.ammonomiconCollection);\ncompanion.encounterTrackable = companion.gameObject.AddComponent<EncounterTrackable>();\ncompanion.encounterTrackable.journalData = new JournalEntry();\ncompanion.encounterTrackable.EncounterGuid = \"" + MODPREFIX + ":" + text39.ToLower() + "\".ToLower();\ncompanion.encounterTrackable.prerequisites = new DungeonPrerequisite[0];\ncompanion.encounterTrackable.journalData.SuppressKnownState = false;\ncompanion.encounterTrackable.journalData.IsEnemy = true;\ncompanion.encounterTrackable.journalData.SuppressInAmmonomicon = false;\ncompanion.encounterTrackable.ProxyEncounterGuid = \"\";\ncompanion.encounterTrackable.journalData.AmmonomiconSprite = \"" + AmmonomiconSprite + "\";\ncompanion.encounterTrackable.journalData.enemyPortraitSprite = ItemAPI.ResourceExtractor.GetTextureFromResource(\"" + AmmonomiconPageSprite + "\");\n AdvEnemyBuilder.Strings.Enemies.Set(\"#" + text39.ToUpper() + "\", \"" + TEMPLATEACTORNAME + "\");\nAdvEnemyBuilder.Strings.Enemies.Set(\"#" + text39.ToUpper() + "_SHORTDESC\", \"" + AmmonomiconShortDesc + "\");\nAdvEnemyBuilder.Strings.Enemies.Set(\"#" + text39.ToUpper() + "_LONGDESC\", \"" + AmmonomiconLongDesc + "\");\ncompanion.encounterTrackable.journalData.PrimaryDisplayName = \"#" + text39.ToUpper() + "\";\ncompanion.encounterTrackable.journalData.NotificationPanelDescription = \"#" + text39.ToUpper() + "_SHORTDESC\";\ncompanion.encounterTrackable.journalData.AmmonomiconFullEntry = \"#" + text39.ToUpper() + "_LONGDESC\";\nAdvEnemyBuilder.AddEnemyToDatabase(companion.gameObject, \"" + MODPREFIX + ":" + text39 + "\".ToLower());\n" + $" EnemyDatabase.GetEntry(\"{MODPREFIX}:{text39.ToLower()}\").ForcedPositionInAmmonomicon = {positionInAmmonomicon};\n" + " EnemyDatabase.GetEntry(\"" + MODPREFIX + ":" + text39.ToLower() + "\").isInBossTab = " + (ACTORTYPE == ActorType.BOSS).ToString().ToLower() + ";\nEnemyDatabase.GetEntry(\"" + MODPREFIX + ":" + text39.ToLower() + "\").isNormalEnemy = true;\n";
		}
		string text40 = "";
		string text41 = "";
		if (ACTORTYPE == ActorType.BOSS || ACTORTYPE == ActorType.MINIBOSS)
		{
			if (DOBOSSINTRO)
			{
				text40 = "GenericIntroDoer miniBossIntroDoer = companion.AddComponent<GenericIntroDoer>(); \nminiBossIntroDoer.triggerType = GenericIntroDoer.TriggerType.PlayerEnteredRoom; \nminiBossIntroDoer.initialDelay = 0.15f; \nminiBossIntroDoer.cameraMoveSpeed = 14; \nminiBossIntroDoer.specifyIntroAiAnimator = null;\nminiBossIntroDoer.BossMusicEvent = \"" + bossMusicEventName + "\";\n" + $"miniBossIntroDoer.PreventBossMusic = {string.IsNullOrEmpty(bossMusicEventName)};\n" + "miniBossIntroDoer.InvisibleBeforeIntroAnim = false;\nminiBossIntroDoer.preIntroAnim = string.Empty;\nminiBossIntroDoer.preIntroDirectionalAnim = string.Empty;\nminiBossIntroDoer.introAnim = \"" + introAnimationName + "\";\nminiBossIntroDoer.introDirectionalAnim = string.Empty;\nminiBossIntroDoer.continueAnimDuringOutro = false;\nminiBossIntroDoer.cameraFocus = null;\nminiBossIntroDoer.roomPositionCameraFocus = Vector2.zero;\nminiBossIntroDoer.restrictPlayerMotionToRoom = false;\nminiBossIntroDoer.fusebombLock = false;\nminiBossIntroDoer.AdditionalHeightOffset = 0;\nAdvEnemyBuilder.Strings.Enemies.Set(\"#" + TEMPLATEACTORNAME.ToUpper() + "_NAME\", \"" + TEMPLATEACTORNAME.ToUpper() + "\");\nAdvEnemyBuilder.Strings.Enemies.Set(\"#" + TEMPLATEACTORNAME.ToUpper() + "_BOSSSUBTITLE\", \"" + bossSplashScreenSubtitle + "\");\nAdvEnemyBuilder.Strings.Enemies.Set(\"#" + TEMPLATEACTORNAME.ToUpper() + "_BOSSQUOTE\", \"" + bossSplashScreenQuote + "\");\nminiBossIntroDoer.portraitSlideSettings = new PortraitSlideSettings(){\nbossNameString = \"#" + TEMPLATEACTORNAME.ToUpper() + "_NAME\",\nbossSubtitleString = \"#" + TEMPLATEACTORNAME.ToUpper() + "_BOSSSUBTITLE\",\nbossQuoteString = \"#" + TEMPLATEACTORNAME.ToUpper() + "_BOSSQUOTE\",\nbossSpritePxOffset = IntVector2.Zero,\ntopLeftTextPxOffset = IntVector2.Zero,\nbottomRightTextPxOffset = IntVector2.Zero,\nbgColor = Color.blue};\n";
				if (DOBOSSSPLASHSCREEN && string.IsNullOrEmpty(bossSplashScreenPath))
				{
					text41 = "private static Texture2D BossCardTexture = ItemAPI.ResourceExtractor.GetTextureFromResource(\"" + bossSplashScreenPath + "\");";
					text40 += "miniBossIntroDoer.portraitSlideSettings.bossArtSprite = BossCardTexture;\nminiBossIntroDoer.SkipBossCard = false;\n";
				}
				else
				{
					text40 += "miniBossIntroDoer.SkipBossCard = true;\n";
				}
			}
			switch (ACTORTYPE)
			{
			case ActorType.BOSS:
				text40 = ((!verticalBossBar) ? (text40 + "companion.aiActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.MainBar;\n") : (text40 + "companion.aiActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.VerticalBar;\n"));
				break;
			case ActorType.MINIBOSS:
				text40 += "companion.aiActor.healthHaver.bossHealthBar = HealthHaver.BossBarType.SubbossBar;\n";
				break;
			}
		}
		string text42 = "tk2dSpriteAnimator EnemySpriteAnimator = companion.GetComponent<tk2dSpriteAnimator>()\n";
		if (Animations.idleAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.idleAnimation);
		}
		if (Animations.walkAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.walkAnimation);
		}
		if (Animations.hitAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.hitAnimation);
		}
		if (Animations.flightAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.flightAnimation);
		}
		if (Animations.talkAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.talkAnimation);
		}
		if (Animations.fidgetAnimation != null)
		{
			text42 += AnimationOffsetMakerMaker(Animations.fidgetAnimation);
		}
		if (Animations.otherAnimations != null && Animations.otherAnimations.Count > 0)
		{
			foreach (WholeAnimationData otherAnimation2 in Animations.otherAnimations)
			{
				text42 += AnimationOffsetMakerMaker(otherAnimation2);
			}
		}
		string text43 = "";
		if (killOnRoomClear)
		{
			text43 = "companion.gameObject.AddComponent<KillOnRoomClear>();\n";
		}
		string text44 = "";
		if (list != null && list.Count > 0)
		{
			foreach (string item in list)
			{
				text44 = text44 + "\"" + item + "\",\n";
			}
		}
		string text45 = "AdvEnemyBuilder.Strings.Enemies.Set(\"#" + text5.ToUpper() + "_NAME_SMALL\", \"" + TEMPLATEACTORNAME + "\");\ncompanion.aiActor.OverrideDisplayName = \"#" + text5.ToUpper() + "_NAME_SMALL\";";
		return "public class " + text4 + "Class : AIActor\n{\npublic static GameObject prefab;\npublic static readonly string guid = \"" + INSERTGUID + "\";\nprivate static tk2dSpriteCollectionData " + text4 + "Collection;\npublic static GameObject shootpoint;\n" + text41 + "public static void Init()\n{\n" + text4 + "Class.BuildPrefab();\n}\npublic static void BuildPrefab()\n{\nif (!(prefab != null || AdvEnemyBuilder.Dictionary.ContainsKey(guid)))\n{\n" + $"prefab = AdvEnemyBuilder.BuildPrefab(\"{TEMPLATEACTORNAME}\", guid, spritePaths[0], new IntVector2({RigidBodyOffsetX}, {RigidBodyOffsetY}), new IntVector2({RigidBodyWidth}, {RigidBodyHeight}), false);\n" + "var companion = prefab.AddComponent<EnemyBehavior>();\n//Actor Variables\n" + $"companion.aiActor.MovementSpeed = {movementSpeed}f;\n" + $"companion.aiActor.CollisionDamage = {contactDamage}f;\n" + "companion.aiActor.HasShadow = " + hasShadow.ToString().ToLower() + ";\ncompanion.aiActor.IgnoreForRoomClear = " + ignoreForRoomClear.ToString().ToLower() + ";\n" + text43 + "companion.aiActor.CanTargetPlayers = " + targetPlayersTrueEnemiesFalse.ToString().ToLower() + ";\ncompanion.aiActor.CanTargetEnemies = " + (!targetPlayersTrueEnemiesFalse).ToString().ToLower() + ";\ncompanion.aiActor.PreventFallingInPitsEver = " + immuneToPits.ToString().ToLower() + ";\n" + $"companion.aiActor.CollisionKnockbackStrength = {collisionKnockback}f;\n" + "companion.aiActor.procedurallyOutlined = " + hasOutlines.ToString().ToLower() + ";\ncompanion.aiActor.PreventBlackPhantom = " + (!canBeJammed).ToString().ToLower() + ";\n//Body Variables\ncompanion.aiActor.specRigidbody.CollideWithOthers = " + rigidBodyCollideWithOthers.ToString().ToLower() + ";\ncompanion.aiActor.specRigidbody.CollideWithTileMap = " + rigidBodyCollideWithWalls.ToString().ToLower() + ";\n" + text37 + "\n//Health Variables\ncompanion.aiActor.healthHaver.PreventAllDamage = " + INVULNERABLE.ToString().ToLower() + ";\n" + $"companion.aiActor.healthHaver.SetHealthMaximum({HEALTHMAX}f, null, false);\n" + $"companion.aiActor.healthHaver.ForceSetCurrentHealth({HEALTHMAX}f);\n" + "//Other Variables\n" + $"companion.aiActor.knockbackDoer.weight = {actorWeight}f;\n" + "//AnimatorVariables\n" + $"companion.aiAnimator.HitReactChance = {hitReactionChance}f;\n" + "companion.aiAnimator.faceSouthWhenStopped = " + faceSouthWhenStopped.ToString().ToLower() + ";\ncompanion.aiAnimator.faceTargetWhenStopped = " + faceTargetWhenStopped.ToString().ToLower() + ";\n" + text3 + "\n" + text45 + "\ncompanion.aiActor.specRigidbody.PixelColliders.Clear();\ncompanion.aiActor.gameObject.AddComponent<tk2dSpriteAttachPoint>();\ncompanion.aiActor.gameObject.AddComponent<ObjectVisibilityManager>();\ncompanion.aiActor.specRigidbody.PixelColliders.Add(new PixelCollider{\nColliderGenerationMode = PixelCollider.PixelColliderGeneration.Tk2dPolygon,\n CollisionLayer = CollisionLayer.EnemyCollider,\n IsTrigger = false,\nBagleUseFirstFrameOnly = false,\n SpecifyBagelFrame = string.Empty,\nBagelColliderNumber = 0,\n" + $"ManualOffsetX = {RigidBodyOffsetX},\n" + $"ManualOffsetY = {RigidBodyOffsetY},\n" + $"ManualWidth = {RigidBodyWidth},\n" + $"ManualHeight = {RigidBodyHeight},\n" + "ManualDiameter = 0,\nManualLeftX = 0,\nManualLeftY = 0,\nManualRightX = 0,\nManualRightY = 0\n});\ncompanion.aiActor.specRigidbody.PixelColliders.Add(new PixelCollider{\nColliderGenerationMode = PixelCollider.PixelColliderGeneration.Tk2dPolygon,\nCollisionLayer = CollisionLayer.EnemyHitBox,\nIsTrigger = false,\nBagleUseFirstFrameOnly = false,\nSpecifyBagelFrame = string.Empty,\nBagelColliderNumber = 0,\n" + $"ManualOffsetX = {RigidBodyOffsetX},\n" + $"ManualOffsetY = {RigidBodyOffsetY},\n" + $"ManualWidth = {RigidBodyWidth},\n" + $"ManualHeight = {RigidBodyHeight},\n" + "ManualDiameter = 0,\nManualLeftX = 0,\nManualLeftY = 0,\nManualRightX = 0,\nManualRightY = 0,\n });\nAIAnimator aiAnimator = companion.aiAnimator;\n" + text6 + "\n" + text7 + "\n" + text9 + "\n" + text8 + "\n" + text10 + "\n" + text11 + "\n" + text12 + "\nif (" + text4 + "Collection == null)\n{\n" + text4 + "Collection = SpriteBuilder.ConstructCollection(prefab, \"" + text4 + "Collection\");\nUnityEngine.Object.DontDestroyOnLoad(" + text4 + "Collection);\nfor (int i = 0; i < spritePaths.Length; i++)\n{\nSpriteBuilder.AddSpriteToCollection(spritePaths[i], " + text4 + "Collection);\n}\n" + text13 + "\n}\nvar bs = prefab.GetComponent<BehaviorSpeculator>();\nprefab.GetComponent<ObjectVisibilityManager>();\nBehaviorSpeculator behaviorSpeculator = EnemyDatabase.GetOrLoadByGuid(\"01972dee89fc4404a5c408d50007dad5\").behaviorSpeculator;\nbs.OverrideBehaviors = behaviorSpeculator.OverrideBehaviors;\nbs.OtherBehaviors = behaviorSpeculator.OtherBehaviors;\n\n//ATTACK BEHAVIOUR SETUP (Must be done BY HAND)\nshootpoint = new GameObject(\"fuck\");\nshootpoint.transform.parent = companion.transform;\nshootpoint.transform.position = (companion.sprite.WorldCenter + new Vector2(0, 0));\nGameObject m_CachedGunAttachPoint = companion.transform.Find(\"fuck\").gameObject;\n" + text35 + "\n\n" + text36 + "\n\n bs.AttackBehaviors = new List<AttackBehaviorBase>()\n{\n//Attack behaviours must be added here MANUALLY\n};\n\nbs.InstantFirstTick = behaviorSpeculator.InstantFirstTick;\nbs.TickInterval = behaviorSpeculator.TickInterval;\nbs.StartingFacingDirection = behaviorSpeculator.StartingFacingDirection;\nbs.PostAwakenDelay = behaviorSpeculator.PostAwakenDelay;\nbs.RemoveDelayOnReinforce = behaviorSpeculator.RemoveDelayOnReinforce;\nbs.OverrideStartingFacingDirection = behaviorSpeculator.OverrideStartingFacingDirection;\nbs.SkipTimingDifferentiator = behaviorSpeculator.SkipTimingDifferentiator;\n\n" + text42 + "\n\n" + text + "\n\n#region HitboxOffsetters\n" + text2 + "#endregion\n\nif (companion.GetComponent<EncounterTrackable>() != null) {\nUnityEngine.Object.Destroy(companion.GetComponent<EncounterTrackable>());}\nGame.Enemies.Add(\"" + MODPREFIX + ":" + text5 + "\".ToLower(), companion.aiActor);\n" + text38 + "\n" + text40 + "\n}}\nprivate static string[] spritePaths = new string[]{\n" + text44 + "\n };}\n";
	}

	public static string AnimationOffsetMakerMaker(WholeAnimationData animation)
	{
		string text = "";
		foreach (DirectionalAnimationData directionalAnimation in animation.DirectionalAnimations)
		{
			bool flag = false;
			string text2 = animation.animName;
			if (string.IsNullOrEmpty(directionalAnimation.suffix))
			{
				text2 = text2 + "_" + directionalAnimation.suffix;
			}
			int num = 0;
			foreach (AnimationFrameData frame in directionalAnimation.Frames)
			{
				if (frame.frameXOffset != 0 || frame.frameYOffset != 0)
				{
					if (!flag)
					{
						text = text + "tk2dSpriteAnimationClip " + text2 + "AnimForOffset = EnemySpriteAnimator.GetClipByName(" + text2 + ");\n";
					}
					text += $"{text2}AnimForOffset.frames[{num}].spriteCollection.spriteDefinitions[{text2}AnimForOffset.frames[{num}].spriteId].MakeOffset(new Vector2({frame.frameXOffset}, {frame.frameYOffset}));\n";
				}
				num++;
			}
		}
		return text;
	}

	public static string ConvertIntListToString(List<int> ints)
	{
		string text = "";
		foreach (int @int in ints)
		{
			text = text + @int + ",";
		}
		return text;
	}

	public static string CompileListBetweenValues(int start, int end)
	{
		string text = "";
		for (int i = start; i < end; i++)
		{
			text = text + i + ",";
		}
		return text;
	}

	public static string SetupAnimationSegment(WholeAnimationData animation, bool isFidget = false)
	{
		//IL_0136: Unknown result type (might be due to invalid IL or missing references)
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0158: Expected I4, but got Unknown
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Expected I4, but got Unknown
		string text = "";
		foreach (DirectionalAnimationData directionalAnimation in animation.DirectionalAnimations)
		{
			text = (string.IsNullOrEmpty(directionalAnimation.suffix) ? (text + "\"" + animation.animShortname + "\",") : (text + "\"" + animation.animShortname + "_" + directionalAnimation.suffix + "\","));
		}
		string text2 = "";
		if (isFidget)
		{
			return "aiAnimator.IdleFidgetAnimations.Add(new DirectionalAnimation{" + $"Type = DirectionalAnimation.DirectionType.{animation.Directionality}," + $"Flipped = new DirectionalAnimation.FlipType[{(int)animation.flipType}]," + "AnimNames = new string[]{" + text + "}});";
		}
		return "aiAnimator." + animation.animName + " = new DirectionalAnimation{" + $"Type = DirectionalAnimation.DirectionType.{animation.Directionality}," + $"Flipped = new DirectionalAnimation.FlipType[{(int)animation.flipType}]," + "AnimNames = new string[]{" + text + "}};";
	}

	public static string SetupOtherAnimationSegments(List<WholeAnimationData> animationList)
	{
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0123: Expected I4, but got Unknown
		string text = "aiAnimator.OtherAnimations = new List<AIAnimator.NamedDirectionalAnimation>{";
		foreach (WholeAnimationData animation in animationList)
		{
			string text2 = "";
			foreach (DirectionalAnimationData directionalAnimation in animation.DirectionalAnimations)
			{
				text2 = (string.IsNullOrEmpty(directionalAnimation.suffix) ? (text2 + "\"" + animation.animShortname + "\",") : (text2 + "\"" + animation.animShortname + "_" + directionalAnimation.suffix + "\","));
			}
			string text3 = "new AIAnimator.NamedDirectionalAnimation{name = \"" + animation.animShortname + "\",anim = new DirectionalAnimation {Prefix = \"" + animation.animShortname + "\"," + $"Type = DirectionalAnimation.DirectionType.{animation.Directionality}," + $"Flipped = new DirectionalAnimation.FlipType[{(int)animation.flipType}]," + "AnimNames = new string[]{" + text2 + "}}}, ";
			text += text3;
		}
		return text + "};";
	}
}
