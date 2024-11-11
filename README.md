## Design Patterns Practice in Asp Net Core 8.0 C# (GoF) design patterns




<div class="flex w-full flex-col gap-1 empty:hidden first:pt-[3px]">
<div class="markdown prose w-full break-words dark:prose-invert light">
<p>A design pattern is a general repeatable/reusable solution to a commonly occurring problem with a given context in software design. It can be treated as a description or template for how to solve a problem that can be used in many different situations.</p>
<h3>1. <strong>Creational Patterns</strong></h3>
<p>These patterns deal with object creation mechanisms, trying to create objects in a manner suitable to the situation. Examples include:</p>
<ul>
<li><strong>Singleton</strong>: Ensures a class has only one instance and provides a global point of access to it.</li>
<li><strong>Factory Method</strong>: Defines an interface for creating an object but allows subclasses to alter the type of objects that will be created.</li>
<li><strong>Abstract Factory</strong>: Provides an interface for creating families of related or dependent objects without specifying their concrete classes.</li>
<li><strong>Builder</strong>: Separates the construction of a complex object from its representation, allowing the same construction process to create different representations.</li>
<li><strong>Prototype</strong>: Creates new objects by copying an existing object, known as a prototype.</li>
</ul>
<h3>2. <strong>Structural Patterns</strong></h3>
<p>These patterns deal with object composition, focusing on how objects are assembled into larger structures. Examples include:</p>
<ul>
<li><strong>Adapter</strong>: Allows incompatible interfaces to work together by wrapping one of the interfaces.</li>
<li><strong>Decorator</strong>: Adds additional functionality to an object dynamically without altering its structure.</li>
<li><strong>Facade</strong>: Provides a simplified interface to a complex subsystem.</li>
<li><strong>Composite</strong>: Composes objects into tree structures to represent part-whole hierarchies, allowing clients to treat individual objects and compositions uniformly.</li>
<li><strong>Proxy</strong>: Provides a surrogate or placeholder for another object to control access to it.</li>
</ul>
<h3>3. <strong>Behavioral Patterns</strong></h3>
<p>These patterns are concerned with object interaction, focusing on communication between objects. Examples include:</p>
<ul>
<li><strong>Observer</strong>: Defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.</li>
<li><strong>Strategy</strong>: Defines a family of algorithms, encapsulates each one, and makes them interchangeable. The strategy pattern allows the algorithm to vary independently from clients that use it.</li>
<li><strong>Command</strong>: Encapsulates a request as an object, thereby allowing for parameterization of clients with different requests, queuing of requests, and logging of requests.</li>
<li><strong>Iterator</strong>: Provides a way to access the elements of an aggregate object sequentially without exposing its underlying representation.</li>
<li><strong>State</strong>: Allows an object to alter its behavior when its internal state changes. The object will appear to change its class.</li>
</ul>
<p>Each of these patterns has its own use case, advantages, and trade-offs. Understanding when and how to apply them can significantly improve the design and structure of your C# applications.</p>
</div>
</div>
