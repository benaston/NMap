NMap
====

A library to simplify the API for type creation and mapping.

Example of use:

```C#


	var complexObject = new ObjectCreator().CreateFrom<SimpleObject, IComplexObject, ComplexObject>(simpleObject, factory);

```

If NMap helps you or your team develop great software please [let me know](mailto:ben@bj.ma "Ben's email address")! It will help motivate me to develop and improve NMap.



License & Copyright
--------

This software is released under the GNU Lesser GPL. It is Copyright 2011, Ben Aston. I may be contacted at ben@bj.ma.