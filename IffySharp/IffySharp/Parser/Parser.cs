// #define CATCH_INVALID_DISPATCH

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
		TerminalDispatch executor;

		public Parser (TerminalDispatch exec, SymbolicKnowledge knowledge)
		{
			this.knowledge = knowledge;
			this.executor = exec;
		}

		public void parse(string text)
		{
			StringSearchResult[] results = findWordsInString (scrubString(text));
			var tokenMap = convertResultsToTokenMap (results);

			var validDispatchFinder = new ValidDispatchFinderParsingTask (executor);
			traverseTokens (tokenMap, text.Length, new ParsingTask (validDispatchFinder.task));

			resolveValidDispatches (validDispatchFinder.validDispatches);

			// Write all results  
			foreach(StringSearchResult r in results)
			{
				Console.WriteLine("Keyword='{0}', Index={1}", r.Keyword, r.Index);
			}
		}


		private void resolveValidDispatches(List<ValidDispatch> dispatches)
		{
			if (dispatches.Count == 1) {
				#if CATCH_INVALID_DISPATCH
				try {
				#endif
					Dispatch.dispatch (executor, dispatches [0].dispatchArgs);
				#if CATCH_INVALID_DISPATCH
				}
				catch {
					throw new ImplementationError ("Dispatch.isValid() not backed by Dispatch.dispatch() method.");
				}
				#endif
			} else if (dispatches.Count == 0) {
				Console.WriteLine ("That sentence had no meanings.");
			} else {
				Console.WriteLine ("That sentence was ambiguous.");
				foreach (ValidDispatch dispatch in dispatches) {
					Console.WriteLine ("\t" + dispatch.description);
				}
			}

		}

		private void traverseTokens(Dictionary<int, MatchedToken> tokenMap, int length, ParsingTask task)
		{
			if (!tokenMap.ContainsKey(0))
				return;

			object[] tokens = new object[length];
			recursivelyTraverseTokens (tokenMap, tokenMap[0], length, tokens, 0, task);
		}

		private void recursivelyTraverseTokens(Dictionary<int, MatchedToken> tokenMap, MatchedToken currToken, int length, object[] tokens, int tokenIndex, ParsingTask task)
		{
			object[] assocs = currToken.associatedObjects;

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


		private class MatchedToken {
			public string text;
			public int index;
			public object[] associatedObjects;
		}

		private class ValidDispatch {
			public object[] dispatchArgs;
			public string description;
		}


		private class ValidDispatchFinderParsingTask
		{
			public readonly List<ValidDispatch> validDispatches = new List<ValidDispatch>();
			private Dispatch exec;


			public ValidDispatchFinderParsingTask(Dispatch exec)
			{
				this.exec = exec;
			}

			public void task(object[] symbols, int count)
			{
				try {
					var trimmedSymbols = new object[count];
					Array.Copy(symbols, trimmedSymbols, count);

					bool isValid = Dispatch.isValid(exec, trimmedSymbols);
					if (isValid) {
						var validDispatch = new ValidDispatch();
						validDispatch.dispatchArgs = (object[]) trimmedSymbols.Clone();
						try {
							validDispatch.description = Dispatch.getDescription(exec, trimmedSymbols);
						}
						catch {
							validDispatch.description = "(no description given)";
						}
						validDispatches.Add(validDispatch);
					}

				}
				catch {
					return;
				}
			}
		}

	}
}

