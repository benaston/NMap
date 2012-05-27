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
	using NBasicExtensionMethod;
	using NHelpfulException.FrameworkExceptions;
	using NSure;

	/// <summary>
	/// 	See comments on iface.
	/// </summary>
	public class ObjectCreator : IObjectCreator
	{
		/// <summary>
		/// 	Use this if you want the returned type to be a base type e.g. an interface instance.
		/// </summary>
		public virtual TDestinationBase CreateFrom<TSource, TDestinationBase, TDestination>
			(TSource source,
			 IFactory<TSource, TDestinationBase> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource
			where TDestination : TDestinationBase {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Object creator source is null.")
				.And<ArgumentNullException>(factory.IsNotNull(), "Object factory is null.");

			return factory.Create<TDestination>(source, additionalParameters);
		}

		/// <summary>
		/// 	Returns a concrete instance as oppsoed to the other overload.
		/// </summary>
		public virtual TDestination CreateFrom<TSource, TDestination>
			(TSource source,
			 IFactory<TSource, TDestination> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Object creator source is null.")
				.And<ArgumentNullException>(factory.IsNotNull(), "Object factory is null.");

			return factory.Create<TDestination>(source, additionalParameters);
		}

		public virtual IEnumerable<TDestinationBase> CreateFrom<TSource, TDestinationBase, TDestination>
			(IEnumerable<TSource> source,
			 IFactory<TSource, TDestinationBase> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource
			where TDestination : TDestinationBase {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Object creator source is null.")
				.And<ArgumentNullException>(factory.IsNotNull(), "Object factory is null.");

			return source.Select(item => factory.Create<TDestination>(item, additionalParameters)).ToList();
		}

		public virtual IEnumerable<TDestination> CreateFrom<TSource, TDestination>
			(IEnumerable<TSource> source,
			 IFactory<TSource, TDestination> factory,
			 params object[] additionalParameters)
			where TSource : IMappable<TDestination>, IObjectCreatorSource {
			Ensure.That<ArgumentNullException>(source.IsNotNull(), "Object creator source is null.")
				.And<ArgumentNullException>(factory.IsNotNull(), "Object factory is null.");

			return source.Select(item => factory.Create<TDestination>(item, additionalParameters)).ToList();
		}
	}
}