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
	using System.Linq;
	using AutoMapper;
	using NBasicExtensionMethod;
	using NHelpfulException.FrameworkExceptions;
	using NSure;

	public static class ObjectMappingExtensions
	{
		/// <summary>
		/// 	Maps an existing object to a new instance of the destination type.
		/// </summary>
		public static TDestination MapToNew<TSource, TDestination>(this TSource source)
			where TSource : IMappable<TDestination> {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Source is null.");

			Mapper.CreateMap<TSource, TDestination>();
			source.MapConfigurator();

			return Mapper.Map<TSource, TDestination>(source);
		}

		/// <summary>
		/// 	Maps each object in a collection to a destination type in a new collection.
		/// </summary>
		public static IEnumerable<TDestination>
			MapToNewIEnumerable<TSource, TDestination>(this IEnumerable<TSource> sourceCollection)
			where TSource : IMappable<TDestination> {
			Ensure.That<ArgumentNullException>(sourceCollection.IsNotNull(), "Source collection is null.");

			if (!sourceCollection.Any()) {
				return new List<TDestination>();
			}

			Mapper.CreateMap<TSource, TDestination>();
			sourceCollection.First().MapConfigurator();

			return Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(sourceCollection);
		}

		/// <summary>
		/// 	Maps an existing object to another existing object.
		/// </summary>
		public static TDestination
			MapTo<TSource, TDestination>(this TSource source, TDestination destination) {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Source object is null.")
				.And<ArgumentNullException>(destination.IsNotNull(), "destination");

			Mapper.CreateMap<TSource, TDestination>();

			return Mapper.Map(source, destination);
		}
	}
}