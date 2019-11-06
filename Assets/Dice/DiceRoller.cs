using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Orpheus.Dice 
{
	public class DiceRoller : MonoBehaviour {
		[SerializeField] Button roll;
		[SerializeField] Button clear;
		[SerializeField] Button d2;
		[SerializeField] Button d4;
		[SerializeField] Button d6;
		[SerializeField] Button d8;
		[SerializeField] Button d10;
		[SerializeField] Button d12;
		[SerializeField] Button d20;
		[SerializeField] Button d100;
		[SerializeField] Text totalRollText;
		[SerializeField] Text resultText;

		DiceRoll currentRoll = new DiceRoll();

		void Start()
		{
			if(roll)
				roll.onClick.AddListener(Roll);
			if(clear)
				clear.onClick.AddListener(Clear);
			if(d2)
				d2.onClick.AddListener(currentRoll.AddD2);
			if(d4)
				d4.onClick.AddListener(currentRoll.AddD4);
			if(d6)
				d6.onClick.AddListener(currentRoll.AddD6);
			if(d8)
				d8.onClick.AddListener(currentRoll.AddD8);
			if(d10)
				d10.onClick.AddListener(currentRoll.AddD10);
			if(d12)
				d12.onClick.AddListener(currentRoll.AddD12);
			if(d20)
				d20.onClick.AddListener(currentRoll.AddD20);
			if(d100)
				d100.onClick.AddListener(currentRoll.AddD100);
		}

		void OnDestroy()
		{
			if(roll)
				roll.onClick.RemoveAllListeners();
			if(clear)
				clear.onClick.RemoveAllListeners();
			if(d2)
				d2.onClick.RemoveAllListeners();
			if(d4)
				d4.onClick.RemoveAllListeners();
			if(d6)
				d6.onClick.RemoveAllListeners();
			if(d8)
				d8.onClick.RemoveAllListeners();
			if(d10)
				d10.onClick.RemoveAllListeners();
			if(d12)
				d12.onClick.RemoveAllListeners();
			if(d20)
				d20.onClick.RemoveAllListeners();
			if(d100)
				d100.onClick.RemoveAllListeners();
		}

		void Update()
		{
			if(totalRollText.text != currentRoll.ToString())
				totalRollText.text = currentRoll.ToString();
		}

		void Roll()
		{
			int total = 0;
			for(int i = 0; i < currentRoll.dice["d2"]; i++)
				total += RollD2();
			for(int i = 0; i < currentRoll.dice["d4"]; i++)
				total += RollD4();
			for(int i = 0; i < currentRoll.dice["d6"]; i++)
				total += RollD6();
			for(int i = 0; i < currentRoll.dice["d8"]; i++)
				total += RollD8();
			for(int i = 0; i < currentRoll.dice["d10"]; i++)
				total += RollD10();
			for(int i = 0; i < currentRoll.dice["d12"]; i++)
				total += RollD12();
			for(int i = 0; i < currentRoll.dice["d20"]; i++)
				total += RollD20();
			for(int i = 0; i < currentRoll.dice["d100"]; i++)
				total += RollD100();

			resultText.text = total.ToString();
		}

		void Clear()
		{
			currentRoll.Clear();
			resultText.text = "";
		}

		int RollD2()
		{
			return Random.Range(0, 3);
		}

		int RollD4() 
		{
			return Random.Range(0, 5);
		}

		int RollD6()
		{
			return Random.Range(0, 7);
		}

		int RollD8()
		{
			return Random.Range(0, 9);
		}

		int RollD10()
		{
			return Random.Range(0, 11);
		}

		int RollD12()
		{
			return Random.Range(0, 13);
		}

		int RollD20()
		{
			return Random.Range(0, 21);
		}

		int RollD100()
		{
			return Random.Range(0, 101);
		}
	}

	public class DiceRoll
	{
		public Dictionary<string, int> dice = new Dictionary<string, int> 
		{
			{"d2", 0},
			{"d4", 0},
			{"d6", 0},
			{"d8", 0},
			{"d10", 0},
			{"d12", 0},
			{"d20", 0},
			{"d100", 0}
		};

		private const bool showLogs = true;

		public override string ToString()
		{
			string rtnval = "";
			foreach(string size in dice.Keys)
			{
				if(dice[size] > 0)
				{
					if(rtnval != "")
						rtnval +=", "; 
					rtnval += dice[size] + size;
				}
			}

			return rtnval;
		}

		public void AddD2()
		{
			dice["d2"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d2", this);
		}

		public void AddD4()
		{
			dice["d4"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d4", this);
		}

		public void AddD6()
		{
			dice["d6"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d6", this);
		}

		public void AddD8()
		{
			dice["d8"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d8", this);
		}

		public void AddD10()
		{
			dice["d10"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d10", this);
		}

		public void AddD12()
		{
			dice["d12"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d12", this);
		}

		public void AddD20()
		{
			dice["d20"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d20", this);
		}

		public void AddD100()
		{
			dice["d100"] += 1;
			if(showLogs)
				Debug.LogFormat("[{0}]: Added d100", this);
		}

		public void Clear()
		{
			dice = dice.ToDictionary(p => p.Key, p => 0);
			if(showLogs)
				Debug.LogFormat("[{0}]: cleared dice", this);
		}
	}
}
