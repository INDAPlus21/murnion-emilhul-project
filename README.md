# murnion-emilhul-project

Game is broken down into 3 essential parts:
Collection
Crafting
Use

## Schedule 
### Week 13 

Design work, e.g. tasks, mana patterns, full elemental graph, verbs/nouns, and component list.

### Week 14 

Finish core design
Make the underlying grid.
Design a puzzle to test the work.
Emil V/LA

### Week 15 

Programming tracks and components.
Elements and transformations.

### Week 16

Verbs/nouns 
Implement and test puzzle
MVP finished.
Further design work.
Siphons.

### Week 17 

### Week 18 

### Week 19 

### Week 20 

### Week 21 

### Week 22

## Design Document 
[x] Gameplay Doc
[] Energy Graph
[] Component List
[] Verb and Noun List
[] Task List
[] Energy Pattern List

### Collection
Much like use, collection is handled through a series of “harvest” quests in which the player must fulfill a series of time-mana-complexity requirements for certain effects.

Additionally, the player can purchase the “blueprints” of certain components for their Siphons and Arrays from merchants, along with rarer materials or worked materials.

### Crafting
The player creates spells from two parts, the Siphon and the Array. Both parts work in a very zachtronics-esque fashion, the Siphon being planted above a field of patterned energy, whereas the Array is on an empty field.

The Siphon needs to draw in the energy into the Siphon outputs, and these outputs are then passed to the Array through inputs in a certain pattern depending on the Siphon chosen. The array can then use these energies to produce certain effects, again, much like a zachtronics game.

These effects come in two types: Verbs and Nouns. Each spell commits each of its Verbs to each of its Nouns. A Verb is an action, such as Harm, Divine or Summon. Nouns are generally targets, but depending on context can also be a descriptor of the effect, such as Health, Object or Human. Finally, certain Nouns are spell descriptors, such as Great Ritual, Duel-safe, or Silent.

The player can choose different types of Siphons, which varies how large a field the Siphon gets to draw from, along with where the inputs are on the Array. The player can also choose different types of Arrays, which varies how large a field the Array is constructed on, along with introducing certain rules on the components, generally extra time-complexity-mana cost.

Spells are tuned along three axes, time, mana and complexity. The player has a store of mana to use throughout the day. Each spell has a certain amount of complexity it must stay under, and every component in a Siphon or Array increases complexity. Time is how many cycles it takes for a spell to finish, and some tasks have time requirements. Some components additionally require special ingredients, which are used every time the spell is cast.

### Use
The player uses spells to solve tasks. Each “biome” has a particular patterned field that the Siphon draws from, along with several tasks to complete. Tasks come in varieties such as “Combat banditry.” to “Find missing valuables.”, etc. Tasks, concretely, require the usage of a series of spells that produce specific effects. The time requirement and effect requirement of the spells is given by the task, while mana and complexity are player-side.

A task, in code, is a struct with a List of Lists of Requirements, along with a time requirement. A requirement is a struct including any amount of Verbs and Nouns. To satisfy a task, one Requirement from each List must be satisfied.

Each “biome” also has certain rarities of tasks. More rare tasks have greater requirements from the player, may require the player to invest special ingredients or gold to even undertake, but have greater rewards. The tasks go from Common, to Uncommon, to Rare, to Mythic. Each biome has one Mythic task, two Rare tasks, three Uncommon tasks, and four Common tasks.

These tasks, generally, are only done to gain gold or valuable materials for components.

A second type of task exists, and exists as the medium and long term goals for the player. Some of these increase the mana and complexity available to the player. Some grant items that have special effects, such as reducing the mana cost of certain effects. Some are goals. Some unlock more biomes.

### Art Assets
To begin with, three different sets of assets need to be made, just for the core gameplay loop of crafting spells: backgrounds, the hexes that make up the hex-grid field; energies, the orbs that are laid upon the siphon field; and components, the actual pieces the player will be setting down on both the Array and the Siphon.

The backgrounds are the easiest, just a grey or metallic hex for the Array background, along with one hex for each planned biome to use in the Siphon backgrounds.

The energies are equally easy to make, since you just need one for each energy, along with variants to add for each imprint to make.

The components are more difficult, mainly since some may want animation. You need one for each component, and certain moving or actuating components may want animation.

Some basic elements will need to be made for the UI as well, such as the component list and the programming track. Mock up puts it roughly like this:

Along with a separate UI which is similar, for debugging, where you can run the Siphon to see how well it operates in different biomes, with a running track of its output energy. Additionally, a debug is required for the Array, where you choose one of your saved Siphons to run alongside it, and can step through.

Once you get to longer gameplay loops, there’ll need to be a separate UI for the entering of tasks, goals (rituals?) and harvest.

### Energy Graph
Notes for being made later: made in much the same fashion as the Opus Magnum graph:

Practically, it's a flowchart that leads from the basic four(?) elements of energy into every form of energy attainable.

The flowchart goes from the four elements: terra, aqua, aer and ignis. Effects are produced through simple forms using complicated reagents, which are transformed through a variety of means. An extra element can be obtained by pushing two opposing elements into an equilibrium station, which turns both into salt. Additionally, two extra elements exist in the form of fulgens and umbra, which are created by pushing two salt through a polarization station.

The means include: 
distillation, which produces a smaller essence; 
transfusion, which reinforces the energy with an essence; 
polarization, which requires to opposing elements to work, but refines the elements;
equilibrium, which will try to make two elements into one middle element;

Elements (current):
* Aer
* Terra
* Ignis
* Aqua
* Salt
* Tenebrae
* Fulgens
* Vitae
* Cognitio
* Potentia
* Oculus

### Component List
S

### Verb and Noun List
Verbs:
* Restore:
* Repair:
* Find:
* Create:
* Damage:
* Disable:
* Refine:
* Banish:
* Move:
* See:
Nouns:
* Earth
* Plant
* Fire
* Human
* Animal
* Water
* Dead
* Wind
* Higher Being
* Ritual
* Great Ritual

Task List (By Biome):
* Frontier Village
   * Fertilize the Fields (Restore Earth or Plant): Common
   * Heal Injuries (Restore Human): Common
   * Find Herbs (Find Plant): Common
   * Heat Homes (Create Fire): Common
   * Combat Banditry (Damage or Disable Humans): Uncommon
   * Gather Food (Find Plant or Animal): Uncommon
   * Clean Water (Refine Water or Create Warmth, Ritual): Uncommon
   * Exorcize Spirit (Banish or Damage or Disable Dead, Ritual): Rare
   * Celebrate the Coming Wind (Move Wind, Ritual): Rare
   * Coming of the Harvest God (See or Find Higher Being, Great Ritual): Mythic

Energy Pattern List (By Biome):


[Design Document](https://docs.google.com/document/d/1EvKw42rOrrKOPUNEtpm3v0FVfLEmR5syY7Dhh01svg8/edit?usp=sharing)
