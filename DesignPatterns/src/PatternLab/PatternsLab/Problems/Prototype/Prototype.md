# Prototype Design Pattern - Research & Answers

### 1. What problem does it solve?
* **The Problem:** When creating complex objects repeatedly (such as heavy 3D models or resource-intensive database queries), instantiating each object from scratch using the `new` keyword causes severe performance bottlenecks and wastes system memory.
* **The Solution:** The Prototype pattern solves this by cloning an already existing, fully initialized object in memory, bypassing costly initialization phases and drastically improving performance.

### 2. What is a prototype?
* A **prototype** is an original, pre-configured instance or template of an object that already exists in memory with all its data loaded. It serves as a model or blueprint used to create brand-new identical copies (`clones`) on demand.

### 3. What does `Clone()` do?
* The **`Clone()`** method is responsible for the duplication process. It instantiates a new object of the same concrete type and copies all state data—including hidden or private fields (like `_modelData`)—from the existing instance into the new one, yielding a complete, matching duplicate.

### 4. What is the difference between a shallow copy and a deep copy?
* **Shallow Copy:** Copies primitive values (like numbers and strings), but for nested reference types (like a `Weapon` object or a `List`), it only copies the memory reference rather than the object itself. 
  * *Consequence:* Modifying the nested object in the clone will accidentally alter the original object as well.
* **Deep Copy:** Completely duplicates the object and **all** of its nested reference types by creating brand-new, independent instances in memory for every component. 
  * *Consequence:* The cloned object becomes entirely independent, meaning any changes made to its weapon or abilities will not affect the original object.