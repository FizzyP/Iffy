using System;
using System.Linq;
using IffySharp.SubParser;
using IffySharp.Simulation;
using EeekSoft.Text;

namespace IffySharp.Parser
{
	public class Parser
	{
		public delegate void SymbolicationTask(object[] symbols);

		private SymbolicKnowledge knowledge;

		public Parser (Dispatch exec, SymbolicKnowledge knowledge)
		{
			this.knowledge = knowledge;
		}

		public void parse(string text)
		{
			StringSearchResult[] results = findWordsInString (scrubString(text));

			// Write all results  
			foreach(StringSearchResult r in results)
			{
				Console.WriteLine("Keyword='{0}', Index={1}", r.Keyword, r.Index);

			}
		}

		private StringSearchResult[] findWordsInString(string text)
		{
			IStringSearchAlgorithm searchAlg = new StringSearch();
			searchAlg.Keywords = knowledge.AllWords.ToArray ();
			return searchAlg.FindAll(text);
		}

		private string scrubString(string text)
		{
			//	TODO elimniate repeat whitespace and apply ToLower
			return text;
		}
	}
}

