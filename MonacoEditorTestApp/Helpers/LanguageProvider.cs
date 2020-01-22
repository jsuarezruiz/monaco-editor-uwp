﻿using Monaco;
using Monaco.Editor;
using Monaco.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;

namespace MonacoEditorTestApp.Helpers
{
    public class LanguageProvider : CompletionItemProvider
    {
        public string[] TriggerCharacters => new string[] { "c" };

        public IAsyncOperation<CompletionList> ProvideCompletionItemsAsync(IModel document, IPosition position, CompletionContext context)
        {
            return AsyncInfo.Run(async delegate (CancellationToken cancelationToken)
            {
                var textUntilPosition = await document.GetValueInRangeAsync(new Range(1, 1, position.LineNumber, position.Column));

                if (textUntilPosition.EndsWith("boo"))
                {
                    return new CompletionList()
                    {
                        Items = new List<CompletionItem>()
                        {
                            new CompletionItem("booyah", "booyah", CompletionItemKind.Folder),
                            new CompletionItem("booboo", "booboo", CompletionItemKind.File),
                        }
                    };
                }
                else if (context.TriggerKind == SuggestTriggerKind.TriggerCharacter)
                {
                    return new CompletionList()
                    {
                        Items = new List<CompletionItem>()
                        {
                            new CompletionItem("class", "class", CompletionItemKind.Keyword),
                            new CompletionItem("cookie", "cookie", CompletionItemKind.Reference),
                        }
                    };
                }

                return new CompletionList()
                {
                    Items = new List<CompletionItem>()
                    {
                        new CompletionItem("foreach", "foreach (var ${2:element} in ${1:array}) {\n\t$0\n}", CompletionItemKind.Snippet)
                    }
                };
            });
        }

        public IAsyncOperation<CompletionItem> ResolveCompletionItemAsync(CompletionItem item)
        {
            return AsyncInfo.Run(delegate (CancellationToken cancelationToken)
            {
                return Task.FromResult(item); // throw new NotImplementedException();
            });
        }
    }
}
