NMap
====

A library to simplify type creation and mapping whilst maintaining loose coupling.

Example of use:

```C#


	var complexObject = new ObjectCreator().CreateFrom<SimpleObject, IComplexObject, ComplexObject>(simpleObject, factory);

```

If NMap helps you or your team develop great software please [let me know](mailto:ben@bj.ma "Ben's email address")! It will help motivate me to develop and improve NMap.


How to build and/or run the tests:
--------

1. Run `/build/build.bat`
1. Type in the desired option
1. Hit return

License & Copyright
--------

This software is released under the GNU Lesser GPL. It is Copyright 2012, Ben Aston. I may be contacted at ben@bj.ma.

How to Contribute
--------

Pull requests including bug fixes, new features and improved test coverage are welcomed. Please do your best, where possible, to follow the style of code found in the existing codebase.