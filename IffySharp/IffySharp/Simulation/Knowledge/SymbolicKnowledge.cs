using System;
using System.Collections.Generic;

namespace IffySharp.Simulation
{
	public class SymbolicKnowledge
	{
		public readonly Dictionary<string, WordAssociation> Associations = new Dictionary<string, WordAssociation> ();

		public SymbolicKnowledge ()
		{
		}

		public void associate(string word, object obj)
		{
			WordAssociation assoc;
			if (Associations.ContainsKey (word)) {
				assoc = Associations [word];
			} else {
				assoc = new WordAssociation (word);
				Associations [word] = assoc;
			}
			assoc.Add (obj);
		}

		public void addAll(SymbolicKnowledge knowledge)
		{
			foreach (KeyValuePair<string, WordAssociation> kv in knowledge.Associations) {
				string word = kv.Key;
				if (!Associations.ContainsKey(word)) {
					Associations [word] = new WordAssociation (word);
				}

				WordAssociation addMe = kv.Value;
				WordAssociation toMe = Associations [word];

				foreach (object association in addMe) {
					toMe.Add (association);
				}
			}
		}

		public IEnumerable<string> AllWords
		{
			get {
				return Associations.Keys;
			}
		}


//		public SortedSet<object> this[string word]
//		{
//			get {
//				if (Associations.ContainsKey (word)) {
//				}
//			}
//		}

		public class WordAssociation : HashSet<object>
		{
			public readonly string Word;

			public WordAssociation(string word)
			{
				Word = word;
			}
		}
	}
}

