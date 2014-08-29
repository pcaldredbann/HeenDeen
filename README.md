What the hell is HeenDeen?!
==

HeenDeen is a fluent API for creating and initializing objects (and collections of objects) with data.  At the moment, you can only really initialize properties with a static value, but my plan further down the line is to slowly introduce randomization and dictionary lookups to get them fleshed out properly.

How does it work? It's REALLY easy! I'll show you.

Making a single object
--

Let's make something simple, say a `Person`

    public class Person
    {
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    
So, we want to make a `Person` with an identity, easy, you do this:

    Person person = 
        new HeenDeen<Person>()
        .Init(e => e.Forename).AsA().Constant("Paul")
        .Init(e => e.Surname).AsA().Constant("Aldred-Bann")
        .Init(e => e.DateOfBirth).AsA().Constant(DateTime.Parse("25 June 1982"))
        .DoIt();

You see the `.Constant` this bit will eventually change to become dynamic data generators, all done through the magic of `.AsA()` but baby steps for now.  The `.DoIt()` bombs out of the HeenDeen chain and returns your initialized `TType` back to you.

Making a collection of objects
--

So you've made your one object, but surely you don't want to iterate the above! You can also do this:

    ICollection<Person> collection = 
        new HeenDeenCollection<Person>()
        .GiveMe(10)
        .ConfigureWith(config => {
            config
                .Init(e => e.Forename).AsA().Constant("Paul")
                .Init(e => e.Surname).AsA().Constant("Aldred-Bann")
                .Init(e => e.DateOfBirth).AsA().Constant(DateTime.Parse("25 June 1982"));
        })
        .DoIt();

The above looks fairly obvious I hope, you tell the initializer how many you want with `.GiveMe(N)` and pass it a configuration through `.ConfigureWith(config).

That's pretty much it for now, I've got quite a few plans for this because it's something I've been wanting to do for a while now, specifically the fluent API thing so keep checking in.
