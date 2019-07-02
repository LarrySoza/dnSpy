/*
    Copyright (C) 2014-2019 de4dot@gmail.com

    This file is part of dnSpy

    dnSpy is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    dnSpy is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with dnSpy.  If not, see <http://www.gnu.org/licenses/>.
*/

using System.Diagnostics;

namespace dnSpy.Debugger.DotNet.CorDebug.Impl {
	[DebuggerDisplay("{Rid} {Version} Offset={RelPathOffset}")]
	readonly struct AppHostInfo {
		public readonly string Rid;
		public readonly string Version;
		public readonly uint RelPathOffset;
		public readonly uint HashDataOffset;
		public readonly uint HashDataSize;
		public readonly byte[] Hash;
		// The last byte of the hashed data. The reason the last byte is used instead of the first byte
		// is that the first byte is most likely the first byte of a function, so it's not very random.
		public readonly byte LastByte;

		public const int MaxAppHostRelPathLength = 1024;

		public AppHostInfo(string rid, string version, uint relPathOffset, uint hashDataOffset, uint hashDataSize, byte[] hash, byte lastByte) {
			Rid = rid;
			Version = version;
			RelPathOffset = relPathOffset;
			HashDataOffset = hashDataOffset;
			HashDataSize = hashDataSize;
			Hash = hash;
			LastByte = lastByte;
		}
	}
}