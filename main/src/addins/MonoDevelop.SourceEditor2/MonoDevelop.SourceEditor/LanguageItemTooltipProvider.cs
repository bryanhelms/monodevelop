// LanguageItemTooltipProvider.cs
//
// Author:
//   Lluis Sanchez Gual <lluis@novell.com>
//
// Copyright (c) 2008 Novell, Inc (http://www.novell.com)
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//
//

using System;
using Mono.TextEditor;
using MonoDevelop.Projects.Parser;

namespace MonoDevelop.SourceEditor
{
	public class LanguageItemTooltipProvider: ITooltipProvider
	{
		public LanguageItemTooltipProvider()
		{
		}

		#region ITooltipProvider implementation 
		
		public object GetItem (TextEditor editor, int offset)
		{
			ExtendibleTextEditor ed = (ExtendibleTextEditor) editor;
			return ed.GetLanguageItem (offset);
		}
		
		public Gtk.Window CreateTooltipWindow (TextEditor editor, object item)
		{
			ExtendibleTextEditor ed = (ExtendibleTextEditor) editor;
			
			IParserContext pctx = ed.View.GetParserContext ();
			if (pctx == null)
				return null;

			return new LanguageItemWindow ((ILanguageItem)item, pctx, ed.View.GetAmbience (), null);
		}
		
		public int GetRequiredWidth (TextEditor editor, Gtk.Window tipWindow)
		{
			LanguageItemWindow win = (LanguageItemWindow) tipWindow;
			return win.SetMaxWidth (win.Screen.Width);
		}
		
		#endregion 
		
	}
}
