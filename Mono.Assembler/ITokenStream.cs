// ITokenStream.cs
// (C) Sergey Chaban (serge@wildwestsoftware.com)

using System;
using System.Collections;

namespace Mono.Assembler
{
	public interface ITokenStream
	{
		ILToken NextToken { get; }
		ILToken LastToken { get; }
	}
}