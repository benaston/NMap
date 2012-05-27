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
	/// <summary>
	/// 	Responsible for defining the interface for types that encapsulate object creation facilities.
	/// </summary>
	/// <typeparam name="TSource"> The type of the source object to use for the target instantiation. </typeparam>
	/// <typeparam name="TDestination"> The type of the object to construct. </typeparam>
	public interface IFactory<in TSource, TDestination>
	{
		TDestination Create<T>(TSource sourceObject, params object[] additionalParameters) where T : TDestination;
	}
}