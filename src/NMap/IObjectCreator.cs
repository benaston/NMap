// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NMap.
// 
// NMap is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NMap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NMap. If not, see <http://www.gnu.org/licenses/>.

namespace NMap
{
	using System.Collections.Generic;

	/// <summary>
	/// 	Responsible for providing framework functionality to enable the construction of types from other types. Similar to automapper, but more powerful in that you supply factory objects to be used to construct the destination object. Enables externalization of object initialization.
	/// </summary>
	/// <example>
	/// 	You might want to construct a "MobileAppeal" given a "Urn". You would supply the Urn instance and a "MobileAppealFactory" to this type, and your MobileAppeal will be returned.
	/// </example>
	public interface IObjectCreator
	{
		/// <summary>
		/// 	Provides functionality for the construction of single objects that implement the TDestinationBase base type.
		/// </summary>
		TDestinationBase CreateFrom<TSource, TDestinationBase, TDestination>
			(TSource source,
			 IFactory<TSource, TDestinationBase> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource
			where TDestination : TDestinationBase;

		/// <summary>
		/// 	Provides functionality for the construction of single objects that implement the TDestination base type.
		/// </summary>
		TDestination CreateFrom<TSource, TDestination>
			(TSource source,
			 IFactory<TSource, TDestination> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource;

		/// <summary>
		/// 	Provides functionality for the construction of collections of objects that implement the TDestinationBase base type.
		/// </summary>
		IEnumerable<TDestinationBase> CreateFrom<TSource, TDestinationBase, TDestination>
			(IEnumerable<TSource> source,
			 IFactory<TSource, TDestinationBase> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource
			where TDestination : TDestinationBase;

		/// <summary>
		/// 	Provides functionality for the construction of collections of objects that implement the TDestinationBase base type.
		/// </summary>
		IEnumerable<TDestination> CreateFrom<TSource, TDestination>
			(IEnumerable<TSource> source,
			 IFactory<TSource, TDestination> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource;
	}
}