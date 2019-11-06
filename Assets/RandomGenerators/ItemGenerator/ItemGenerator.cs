using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Orpheus.Generate.Item 
{
	/// Generates random item descriptions
	public class ItemGenerator : MonoBehaviour {

		public Text outputText;
		public Button generateButton;

		List<List<string>> weapons;
		List<List<string>> materials;

		// Use this for initialization
		void Start () 
		{
			if(generateButton != null)
				generateButton.onClick.AddListener(Generate);

			weapons = new List<List<string>> { axes, heavyBlades, lightBlades, bows, closeWeapons, crossbows, doubleWeapons, flails, hammers, monkWeapons, polearms, spears, thrownWeapons };
			materials = new List<List<string>> { metals, hardStones, hornAndBone, timbers };
		}
		
		void OnDestroy() 
		{
			if(generateButton != null)
				generateButton.onClick.RemoveAllListeners();
		}

		// Generates a new item description
		// style:
		// adjective noun of adjective
		void Generate() 
		{
			string noun = GetRandomFromList(GetRandomFromList(weapons));
			string material = GetRandomFromList(GetRandomFromList(materials));
			string article = GetArticle(material);

			string description = article + " " + material + " " + noun;
			outputText.text = description;
		}

		// Gets a random item from a list
		T GetRandomFromList<T>(List<T> list) 
		{
			return list[Random.Range(0, list.Count)];
		}

		// Gets the appropriate article (a or an) for the passed word string
		List<char> vowels = new List<char> {'a', 'e', 'i', 'o', 'u'};
		string GetArticle(string appliedWord) 
		{
			string article;
			if(vowels.Contains(appliedWord[0]))
				article = "an";
			else
				article = "a";
			
			return article;
		}




		#region materials

		List<string> metals = new List<string>
		{
			"iron", "copper", "bronze", "steel", "mithril", "adamantine", "silver", "brass"
		};

		List<string> hardStones = new List<string>
		{
			"blackstone", "crystal"
		};

		List<string> hornAndBone = new List<string>
		{
			"horn", "bone", "claw", "antler" 
		};

		List<string> timbers = new List<string>
		{
			"oak", "yew", "fungalwood", "worldwood"
		};

		#endregion

		#region itemNouns

		#region weapons

		List<string> axes = new List<string>
		{
			"axe-gauntlet", "dwarven heavy axe", "dwarven light axe", "bardiche", "battleaxe", "boarding axe", "butchering axe", "collapsible kumade", 
			"dwarven waraxe", "gandasa", "greataxe", "handaxe", "heavy pick", "hooked axe", "knuckle axe", "kumade", "light pick", "mattock", "orc double axe", 
			"pata", "throwing axe", "tongi"
		};

		List<string> heavyBlades = new List<string>
		{
			"ankus", "bastard sword", "chakram", "double cutlass", "double chicken saber", "double walking stick katana", "dueling sword", "elven curve blade", 
			"estoc", "falcata", "falchion", "flambard", "greatsword", "great terbutje", "katana", "khopesh", "klar", "longsword", "nine-ring broadsword", "nodachi", 
			"rhoka sword", "sawtooth sabre", "scimitar", "scythe", "seven-branched sword", "shotel", "sickle-sword", "split-blade sword", "switchscythe", 
			"temple sword", "terbutje", "two-bladed sword"
		};

		List<string> lightBlades = new List<string>
		{
			"bayonet", "broken-back seax", "butterfly knife", "butterfly sword", "chakram", "dagger", "deer horn knife", "dogslicer", "drow razor", "dueling dagger", 
			"gladius", "hunga munga", "kama", "katar", "kerambit", "kukri", "machete", "madu", "manople", "pata", "quadrens", "rapier", "sanpkhang", "sawtooth sabre", 
			"scizore", "shortsword", "sica", "sickle", "spiral rapier", "starknife", "swordbreaker dagger", "sword cane", "wakizashi", "war razor"
		};

		List<string> bows = new List<string>
		{
			"composite longbow", "composite shortbow", "composite greatbow", "greatbow", "longbow", "orc hornbow", "shortbow"
		};

		List<string> closeWeapons = new List<string>
		{
			"brass knuckles", "cestus", "dan bong", "dwarven war-shield", "emei piercer", "fighting fan", "gauntlet", "heavy shield", "iron brush", "light shield", 
			"mere club", "punching dagger", "sap", "scizore", "tekko-kagi", "tonfa", "tri-bladed katar"
		};

		List<string> crossbows = new List<string>
		{
			"double crossbow", "hand crossbow", "heavy crossbow", "light repeating crossbow", "heavy repeating crossbow",  "dwarven heavy pelletbow", 
			"dwarven light pelletbow", "underwater heavy crossbow", "underwater light crossbow"
		};

		List<string> doubleWeapons = new List<string>
		{
			"bo staff", "boarding gaff", "chain-hammer", "chain spear", "dire flail", "double-chained kama", "dwarven urgrosh", "gnome hooked hammer", "kusarigama", 
			"monk’s spade", "orc double axe", "quarterstaff", "taiaha", "weighted spear"
		};

		List<string> flails = new List<string>
		{
			"battle poi", "bladed scarf", "cat-o’-nine-tails", "dwarven dorn-dergar", "flail", "flying talon", "gnome pincher", "halfling rope-shot", "heavy flail", 
			"kusarigama", "kyoketsu shoge", "meteor hammer", "morningstar", "nine-section whip", "nunchaku", "sansetsukon", "scorpion whip", "spiked chain", "urumi", "whip"
		};

		List<string> hammers = new List<string>
		{
			"aklys", "battle aspergillum", "club", "earth breaker", "greatclub", "heavy mace", "lantern staff", "light hammer", "light mace", "planson", 
			"dwarven ram hammer", "tetsubo", "wahaika", "warhammer"
		};

		List<string> monkWeapons = new List<string>
		{
			"bo staff", "brass knuckles", "butterfly sword", "cestus", "dan bong", "deer horn knife", "double chained kama", "double chicken saber", "emei piercer", 
			"fighting fan", "hanbo", "jutte", "kama", "kusarigama", "kyoketsu shoge", "lungshuan tamo", "monk’s spade", "nine-ring broadsword", "nine-section whip", 
			"nunchaku", "quarterstaff", "rope dart", "sai", "sanpkhang", "sansetsukon", "seven-branched sword", "shang gou", "shuriken", "siangham", "temple sword", 
			"tiger fork", "tonfa", "traveling kettle", "tri-point double-edged sword", "urumi", "wushu dart"
		};

		List<string> polearms = new List<string>
		{
			"bardiche", "bec de corbin", "bill", "boarding gaff", "crook", "fauchard", "glaive", "glaive-guisarme", "guisarme", "halberd", "hooked lance", "horsechopper", 
			"lucerne hammer", "mancatcher", "monk’s spade", "naginata", "nodachi", "ogre hook", "ranseur", "rhomphaia", "tepoztopilli", "tiger fork"
		};

		List<string> spears = new List<string>
		{
			"amentum", "boar spear", "chain spear", "double spear", "elven branched spear", "harpoon", "javelin", "lance", "longspear", "orc skull ram", "pilum", 
			"planson", "shortspear", "sibat", "spear", "tiger fork", "trident", "weighted spear"
		};

		List<string> thrownWeapons = new List<string>
		{
			"aklys", "amentum", "atlatl", "blowgun", "bola", "boomerang", "brutal bola", "chain-hammer", "chakram", "dagger", "dart", "deer horn knife", "dueling dagger",
			"harpoon", "hunga munga", "javelin", "kestros", "lasso", "light hammer", "net", "pilum", "shortspear", "shuriken", "sibat", "sling", "spear", "starknife", 
			"throwing axe", "throwing shield", "trident", "wushu dart"
		};

		List<string> tribalWeapons = new List<string>
		{
			"Club", "dagger", "greatclub", "handaxe", "heavy shield", "light shield", "shortspear", "spear", "throwing axe"
		};

		#endregion

		#endregion
	}
}
