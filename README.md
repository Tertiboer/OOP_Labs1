# OOP_Labs1
# OOTPiSP Labs: Object-Oriented Programming & Software Design

## Overview
This repository contains a series of laboratory works focused on object-oriented programming (OOP) principles, plugin architectures, design patterns, serialization, and graphical user interfaces. The labs progressively build upon each other, starting from basic inheritance and polymorphism to advanced plugin-based functionality with digital signatures and adapter patterns.

---

## Lab 1: Inheritance & Polymorphism
Topic: Introduction to OOP concepts (inheritance, virtual methods)

- Build a class hierarchy of graphical shapes (at least 6: line, rectangle, ellipse, etc.)
- Organize classes into modules
- Implement a shape container class
- Static initialization of shapes in the main module
- Render shapes using a graphics library or text-based output

---

## Lab 2: Graphical Editor
Topic: Extending the shape editor with user interaction

- Create shapes via user interface (mouse input, dialog boxes, or scripting)
- Add new shape classes without modifying existing code (no if/else or switch on types)
- Shape classes must not contain drawing logic
- Results in a primitive graphical editor

---

## Lab 3: Serialization
Topic: Object serialization/deserialization

- Define a domain-specific class hierarchy (≥6 classes)
- Serialization format determined by variant: XML, Binary, Text, JSON, or BSON
- GUI must support:
  - Editing object properties
  - Adding/removing objects
  - Saving/loading object lists
- No reflection, if/else, or switch when adding new classes

---

## Lab 4: Plugin Hierarchy
Topic: Dynamic module loading (plugins)

- Extend the hierarchy from Lab 2 or 3 using dynamically loaded plugins
- Each plugin adds:
  - New classes in the hierarchy
  - Functions to work with those classes
  - UI elements for the new class
- Load plugins from a folder or via command-line argument
- Optional (10 pts): Plugin signing with integrity and activation time verification

---

## Lab 5: Plugin Functionality
Topic: Pre-save and post-load data processing

- Based on Lab 4, implement 2–3 plugins that process structures before saving and after loading
- Processing type depends on variant:
  1. XML → JSON transformation
  2. Archiving
  3. Encryption/decryption
  4. XML transformation (XSLT)
  5. Checksum storage
- Processing options appear in settings menu depending on loaded plugins
- Plugins load automatically from a folder or via file selection
- Optional (10 pts): Per-plugin configuration (encryption params, archiving rules, encoding, etc.)

---

## Lab 6: Design Patterns
Topic: Pattern integration and plugin adaptation

- Exchange at least one functional plugin with a colleague
- Adapt the colleague’s plugin using the Adapter pattern
- Implement two additional design patterns (any) and justify their usage
- Integrate everything into the Lab 5 application

---
