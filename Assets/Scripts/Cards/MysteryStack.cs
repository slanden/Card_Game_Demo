﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Mystery stack.
/// This is attached to the GameObject in the scene.
/// </summary>
public class MysteryStack : CardStack<MysteryCard,MysteryCardMono>
{
	void Start()
	{
		int randPower = UnityEngine.Random.Range (0, 10);
		int randClass = UnityEngine.Random.Range (0, 2);
		foreach (var v in CardMonos) {
			v.power = randPower;
			v.cardType = (MysteryType)randClass;
		}
	}
}
