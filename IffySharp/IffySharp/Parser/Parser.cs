using System;
using System.Linq;
using System.Collections.Generic;

using IffySharp.SubParser;
using IffySharp.Simulation;
using EeekSoft.Text;

namespace IffySharp.Parser
{
	public class Parser
	{
		public delegate void ParsingTask(object[] symbols, int count);

		private SymbolicKnowledge knowledge;

		public Parser (Dispatch exec, SymbolicKnowledge knowledge)
		{
			this.knowledge = knowledge;
		}

		public void parse(string text)
		{
			StringSearchResult[] results = findWordsInString (scrubString(text));
			var tokenMap = convertResultsToTokenMap (results);

			traverseTokens (tokenMap, text.Length, new ParsingTask (dummyParsingTask));

			// Write all results  
			foreach(StringSearchResult r in results)
			{
				Console.WriteLine("Keyword='{0}', Index={1}", r.Keyword, r.Index);
			}
		}

		private void traverseTokens(Dictionary<int, MatchedToken> tokenMap, int length, ParsingTask task)
		{
			object[] tokens = new object[length];
			recursivelyTraverseTokens (tokenMap, tokenMap[0], length, tokens, 0, task);
		}

		private void recursivelyTraverseTokens(Dictionary<int, MatchedToken> tokenMap, MatchedToken currToken, int length, object[] tokens, int tokenIndex, ParsingTask task)
		{
			object[] assocs = currToken.associatedObjects;
//			tokenIndex++;

			//	Can we extend this any farther?
			//	If not then we're at the end, so invoke the task on each way of copmleting the token list.
			if (currToken.index + currToken.text.Length >= length) {
				foreach (object obj in assocs) {
					tokens [tokenIndex] = obj;
					task (tokens, tokenIndex + 1);
				}
			} else {
				//	Otherwise recurse until we hit the end
				int nextIndex = currToken.index + currToken.text.Length + 1;	// + 1 for space
				if (!tokenMap.ContainsKey(nextIndex)) {
					//	No way of continuing
					return;
				}

				var nextToken = tokenMap [nextIndex];

				foreach (object obj in assocs) {
					tokens [tokenIndex] = obj;
					recursivelyTraverseTokens (tokenMap, nextToken, length, tokens, tokenIndex + 1, task);
				}
			}
		}

		private StringSearchResult[] findWordsInString(string text)
		{
			IStringSearchAlgorithm searchAlg = new StringSearch();
			searchAlg.Keywords = knowledge.AllWords.ToArray ();
			return searchAlg.FindAll(text);
		}

		private Dictionary<int, MatchedToken> convertResultsToTokenMap(StringSearchResult[] results)
		{
			var tokenMap = new Dictionary<int, MatchedToken> ();
	
			foreach (StringSearchResult result in results) {
				if (knowledge.Associations.ContainsKey (result.Keyword)) {
					var wordAssoc = knowledge.Associations [result.Keyword];

					var tok = new MatchedToken ();
					tok.text = result.Keyword;
					tok.index = result.Index;
					tok.associatedObjects = wordAssoc.ToArray<object>();

					//	Store the token in the map
					tokenMap [tok.index] = tok;

				} else {
					throw new ParsingException ("Matched word not associated with an object.");
				}
			}

			return tokenMap;
		}

		private string scrubString(string text)
		{
			//	TODO elimniate repeat whitespace and apply ToLower
			return text;
		}
	

		// public delegate void ParsingTask(object[] symbols, int count);

		private static void dummyParsingTask(object[] symbols, int count)
		{
			Console.WriteLine (count);
		}



		private class MatchedToken {
			public string text;
			public int index;
			public object[] associatedObjects;
		}

	}
}

