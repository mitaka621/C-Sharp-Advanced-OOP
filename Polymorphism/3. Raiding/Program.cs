
using Raiding.Core;
using Raiding.Core.Engine;
using Raiding.Factories;
using Raiding.Factories.Interfaces;

IHeroFactory factory = new HeroFactory();


IEngine engine = new Engine(factory);

engine.Run();