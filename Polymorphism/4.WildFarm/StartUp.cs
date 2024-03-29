﻿using Raiding.Core;
using Raiding.Core.Engine;
using Raiding.Factories;
using Raiding.Factories.Interfaces;
using Raiding.IO;
using Raiding.IO.Interfaces;

IFarm factory = new FarmFactory();
IReader reader = new ConsoleReader();
IWriter writer = new ConsoleWriter();
IEngine engine = new Engine(factory, writer, reader);

engine.Run();