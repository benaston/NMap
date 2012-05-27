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
	/// 	Responsible for defining the interface for types that support custom mapping behavior. For example, DTO types that encapsulate the logic for construction of a domain object.
	/// </summary>
	/// <typeparam name="TDestination"> The type to map to. </typeparam>
	public interface IMappable<in TDestination>
	{
		/// <summary>
		/// 	Responsible for configuring AutoMapper such that the object can be mapped successfully to a target object.
		/// </summary>
		void MapConfigurator();
	}
}