# Dictionary Custom Editor (Unity / C#)

![Dictionary Custom Image](/doc/dictionary_custom_editor.png)

## What is it?

Unity Editor serialization system doesn't allow one to serialized C# Dictionaries, although it is possible to create a list of custom key value pair objects. However, if one wants to serialize Dictionaries, it must be done in slightly roundabout way. Luckily Unity documentation has an example how to do this, however - it doesn't show how to create a Custom Editor for diplaying Dictionary contents. 

In this example it is possible to see one way how Dictionary data can be displayed in Unity Inspector. I've added a UI to list Dictionary key value pairs, and a possiblity to edit item value, add new items, remove items and an option to clear the dictionary. Undo works for all of the operations, but it is a bit glitchy - if you press Undo, you have to deselect and select the object/asset where the list is located, otherwise changes don't get reflected in the UI.

# Classes

## DictionaryEditor.cs
Custom Editor / Inspector class which shows how to implement dictionary value editing. I'm quite sure it is not possible to use Unity SerializableObject to edit values, as Unity doesn't serialize the Dictionary to begin with.

## DictionaryTest.cs
The class containing the Dictionary and its backing fields to circumvent the fact that dictionary can't be serialized - Note: this class is pretty similar to one you can find in Unity API documentation.

# Copyright
Created by Sami S. use of any kind without a written permission from the author is not allowed. But feel free to take a look.
