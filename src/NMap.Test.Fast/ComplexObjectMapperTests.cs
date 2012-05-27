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

namespace NMap.Test.Fast
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using NUnit.Framework;
	using Rhino.Mocks;

	public class ComplexObjectMapperTests
	{
		/// <summary>
		/// 	Provides an object model and a complex fake domain type to instantiate and initialise from a flat type "SimpleObject".
		/// </summary>
		/// <remarks>
		/// 	Here we manually construct the object factory, but in production code, such a type can be constructed by an IoC container, thereby removing the code from the point of use, resulting in cleaner code.
		/// </remarks>
		[TestFixture, Category("Fast")]
		public class When_I_map_a_flat_object_to_a_complex_object_with_external_object_dependencies
		{
			[Test]
			public void The_complex_object_is_instantiated_correctly() {
				//arrange
				var simpleObject = new SimpleObject {
					Id = "1",
					Name = "a",
					Numbers = new[] {2},
					SubObjectId = Guid.NewGuid().ToString()
				};
				var stubRepo = MockRepository.GenerateStub<ISubSubObjectRepository>();
				stubRepo.Stub(r => r.GetById(default(int)))
					.IgnoreArguments()
					.Return(new SubSubObject {Id = 2});
				var factory = new ComplexObjectFactory(stubRepo);

				//act - this is all we need in the client to instantiate a complex object
				//not an extension method for improved testability
				var complexObject = new ObjectCreator().CreateFrom<SimpleObject, IComplexObject, ComplexObject>(simpleObject, factory);

				//assert - multiple assertions in a single test for brevity
				Assert.That(simpleObject.Id == complexObject.Id);
				Assert.That(simpleObject.Name == complexObject.Name);
				Assert.That(simpleObject.SubObjectId == complexObject.SubObject.Id.ToString());
				Assert.That(simpleObject.Numbers[0] == complexObject.SubObject.ObjectArray.ToArray()[0].Id);
			}
		}
	}

	internal class ComplexObjectFactory : IFactory<SimpleObject, IComplexObject>
	{
		private readonly ISubSubObjectRepository _subSubObjectRepository;

		public ComplexObjectFactory(ISubSubObjectRepository subSubObjectRepository) {
			_subSubObjectRepository = subSubObjectRepository;
		}

		public IComplexObject Create<T>(SimpleObject sourceObject, params object[] additionalParameters) where T : IComplexObject {
			var complexObject = sourceObject.MapToNew<SimpleObject, ComplexObject>();
			var subObject = new SubObject {
				Id = new Guid(sourceObject.SubObjectId),
				ObjectArray = sourceObject.Numbers
					.Select(n => _subSubObjectRepository
					             	.GetById(n))
			};
			complexObject.SubObject = subObject;

			return complexObject;
		}
	}

	internal class SimpleObject : IMappable<ComplexObject>, IObjectCreatorSource
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public int[] Numbers { get; set; }
		public string SubObjectId { get; set; }
		void IMappable<ComplexObject>.MapConfigurator() {}
	}

	internal interface IComplexObject
	{
		string Id { get; set; }
		string Name { get; set; }
		SubObject SubObject { get; set; }
	}

	internal class ComplexObject : IComplexObject
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public SubObject SubObject { get; set; }
	}

	internal class SubObject
	{
		public Guid Id { get; set; }
		public IEnumerable<SubSubObject> ObjectArray { get; set; }
	}

	public class SubSubObject
	{
		public int Id { get; set; }
		public string Value { get; set; }
	}

	public interface ISubSubObjectRepository
	{
		SubSubObject GetById(int id);
	}
}