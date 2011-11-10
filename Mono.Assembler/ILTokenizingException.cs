//
// Mono.ILASM.ILTokenizingException
//
// Author(s):
//  Jackson Harper (jackson@ximian.com)
//
// Copyright 2004 Novell, Inc (http://www.novell.com)
//


using System;

namespace Mono.Assembler
{
	public class ILTokenizingException : Exception
	{
		public readonly Location Location;
		public readonly string Token;

		public ILTokenizingException(Location location, string token)
			: base(token)
		{
			Location = location;
			Token = token;
		}
	}
}
