using Microsoft.EntityFrameworkCore;

namespace MovieApp_Web_Api.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonMovie> PersonMovies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMovie> GenreMovies { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryMovie> CountryMovies { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) 
        { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonMovie>()
                .HasKey(bc => new { bc.PersonId, bc.MovieId });
            modelBuilder.Entity<PersonMovie>()
                .HasOne(bc => bc.Person)
                .WithMany(b => b.PersonMovies)
                .HasForeignKey(bc => bc.PersonId);
            modelBuilder.Entity<PersonMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.PersonMovies)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<GenreMovie>()
                .HasKey(bc => new { bc.GenreId, bc.MovieId });
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Genre)
                .WithMany(b => b.GenreMovies)
                .HasForeignKey(bc => bc.GenreId);
            modelBuilder.Entity<GenreMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.GenreMovies)
                .HasForeignKey(bc => bc.MovieId);

            modelBuilder.Entity<CountryMovie>()
                .HasKey(bc => new { bc.CountryId, bc.MovieId });
            modelBuilder.Entity<CountryMovie>()
                .HasOne(bc => bc.Country)
                .WithMany(b => b.CountryMovies)
                .HasForeignKey(bc => bc.CountryId);
            modelBuilder.Entity<CountryMovie>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.CountryMovies)
                .HasForeignKey(bc => bc.MovieId);


            modelBuilder.Entity<Movie>().HasData(new Movie[] {
                new() {
                    Id=1,
                    Title="Avatar",
                    Description="Avatar (also marketed as James Cameron's Avatar) is a 2009 American[7][8] epic science fiction film directed, written, produced, and co-edited by James Cameron and starring Sam Worthington, Zoe Saldana, Stephen Lang, Michelle Rodriguez, and Sigourney Weaver. It is set in the mid-22nd century when humans are colonizing Pandora, a lush habitable moon of a gas giant in the Alpha Centauri star system, in order to mine the valuable mineral unobtanium.[9][10][11] The expansion of the mining colony threatens the continued existence of a local tribe of Na'vi – a humanoid species indigenous to Pandora. The film's title refers to a genetically engineered Na'vi body operated from the brain of a remotely located human that is used to interact with the natives of Pandora.[12]",
                    Duration=160,
                    Year=2009,
                    ImageName="78dfgr5HY6.jpg",
                    VideoName = "aFe3gkYu78.mp4"
                },
                new() {
                    Id=2,
                    Title = "Birdman",
                    Description = "Birdman or (The Unexpected Virtue of Ignorance), or simply Birdman, is a 2014 American black comedy-drama film directed by Alejandro G. Iñárritu. It was written by Iñárritu, Nicolás Giacobone, Alexander Dinelaris Jr., and Armando Bó. The film stars Michael Keaton as Riggan Thomson, a faded Hollywood actor best known for playing the superhero \"Birdman\", as he struggles to mount a Broadway adaptation of Raymond Carver's short story, \"What We Talk About When We Talk About Love\". The film also features a supporting cast of Zach Galifianakis, Edward Norton, Andrea Riseborough, Amy Ryan, Emma Stone, and Naomi Watts.",
                    Duration = 120,
                    Year = 2014,
                    ImageName = "r435t349AB.jpg",
                    VideoName = "t349FF8111.mp4",
                },
                new() {
                    Id=3,
                    Title = "The Dark Knight",
                    Description = "The Dark Knight is a 2008 superhero film directed by Christopher Nolan from a screenplay he co-wrote with his brother Jonathan. Based on the DC Comics superhero Batman, it is the sequel to Batman Begins (2005) and the second installment in The Dark Knight Trilogy. The film follows the vigilante Batman, police lieutenant James Gordon, and district attorney Harvey Dent as they form an alliance to dismantle organized crime in Gotham City. Their efforts are derailed by the intervention of the Joker, an anarchistic mastermind who seeks to test how far Batman will go to save the city from complete chaos. The ensemble cast includes Christian Bale, Michael Caine, Heath Ledger, Gary Oldman, Aaron Eckhart, Maggie Gyllenhaal, and Morgan Freeman.",
                    Duration = 152,
                    Year = 2008,
                    ImageName = "eht58T9ef4.jpg",
                    VideoName = "3wer5YtUiO.mp4",
                },
                new() {
                    Id=4,
                    Title = "American Psycho",
                    Description = "American Psycho is a 2000 slasher film directed by Mary Harron, who co-wrote the screenplay with Guinevere Turner. Based on Bret Easton Ellis's 1991 novel American Psycho, it stars Christian Bale as Patrick Bateman, a New York City investment banker who leads a double life as a serial killer. Willem Dafoe, Jared Leto, Josh Lucas, Chloë Sevigny, Samantha Mathis, Cara Seymour, Justin Theroux, and Reese Witherspoon appear in supporting roles. The film blends horror and black comedy to satirize 1980s yuppie culture and consumerism, exemplified by Bateman.",
                    Duration = 162,
                    Year = 2000,
                    ImageName = "ehT58T9FG2.jpg",
                    VideoName = "3We15YyUiO.mp4",
                },
                new() {
                    Id=5,
                    Title = "Joker",
                    Description = "Joker is a 2019 American psychological thriller film directed and produced by Todd Phillips, who co-wrote the screenplay with Scott Silver. The film, based on DC Comics characters, stars Joaquin Phoenix as the Joker and provides a possible origin story for the character. Set in 1981, it follows Arthur Fleck, a failed clown and aspiring stand-up comedian whose descent into insanity and nihilism inspires a violent countercultural revolution against the wealthy in a decaying Gotham City. Robert De Niro, Zazie Beetz, Frances Conroy, Brett Cullen, Glenn Fleshler, Bill Camp, Shea Whigham, and Marc Maron appear in supporting roles. Distributed by Warner Bros. Pictures, Joker was produced by Warner Bros. Pictures and DC Films in association with Village Roadshow Pictures, Bron Creative and Joint Effort.",
                    Duration = 139,
                    Year = 1999,
                    ImageName = "ut45eDfGhw.jpg",
                    VideoName = "3ewUiOf69Z.mp4",
                },
                new() {
                    Id=6,
                    Title = "Pulp Fiction",
                    Description = "Pulp Fiction is a 1994 American black comedy crime film written and directed by Quentin Tarantino, who conceived it with Roger Avary.[4] Starring John Travolta, Samuel L. cckson, Bruce Willis, Tim Roth, Ving Rhames, and Uma Thurman, it tells several stories of crime in Los Angeles. The title refers to the pulp magazines and hardboiled crime novels popular during the mid-20th century, known for their graphic violence and punchy dialogue.",
                    Duration = 154,
                    Year = 1994,
                    ImageName = "dfhtyWR586.jpg",
                    VideoName = "qwi49Tfget.mp4",
                },
                new() {
                    Id=7,
                    Title = "The Hangover",
                    Description = "The Hangover is a 2009 American comedy film directed by Todd Phillips, co-produced with Daniel Goldberg, and written by Jon Lucas and Scott Moore. It is the first installment in The Hangover trilogy. The film stars Bradley Cooper, Ed Helms, Zach Galifianakis, Heather Graham, Justin Bartha, Ken Jeong, and Jeffrey Tambor. It tells the story of Phil Wenneck (Cooper), Stu Price (Helms), Alan Garner (Galifianakis), and Doug Billings (Bartha), who travel to Las Vegas for a bachelor party to celebrate Doug's impending marriage. However, Phil, Stu, and Alan wake up with Doug missing and no memory of the previous night's events, and must find the groom before the wedding can take place.",
                    Duration = 100,
                    Year = 2009,
                    ImageName = "dfetyeR586.jpg",
                    VideoName = "qwi49Tttet.mp4",
                },
            });

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new()
                {
                    Id=1,
                    FirstName="Sam",
                    LastName="Worthington",
                    // Birthday=new DateTime(1976, 8, 2),
                    Birthday="1976-8-2",
                    Height=178,
                    Bio="Samuel Henry John Worthington[1] (born 2 August 1976) is an Australian actor. He is best known for playing Jake Sully in Avatar, Marcus Wright in Terminator Salvation, and Perseus in Clash of the Titans and its sequel Wrath of the Titans. He later took more dramatic roles, appearing in The Debt (2010), Everest (2015), Hacksaw Ridge (2016), The Shack (2017), Manhunt: Unabomber (2017), and Fractured (2019). On television, he appeared in his native Australia as Howard in Love My Way and as Phillip Schuler in the television drama mini-series Deadline Gallipoli, for which he was also an executive producer. He voiced the protagonist, Captain Alex Mason, in the video games Call of Duty: Black Ops (2010), Call of Duty: Black Ops II (2012), and Call of Duty: Black Ops 4 (2018). In 2022, he starred in the true crime miniseries Under the Banner of Heaven.",
                    ImageName="abdcs34RTf.jfif"
                },
                new()
                {
                    Id=2,
                    FirstName="Zoe",
                    LastName="Saldaña",
                    //Birthday=new DateTime(1978, 6, 19),
                    Birthday="1978-6-19",
                    Height=170,
                    Bio="Zoe Yadira Saldaña-Perego (née Saldaña Nazario; born June 19, 1978) is an American actress. After performing with the theater group Faces she appeared in two 1999 episodes of Law & Order. Her film career began a year later with Center Stage (2000) in which she portrayed a ballet dancer.\r\n\r\nAfter receiving early recognition for her work opposite Britney Spears in the road film Crossroads (2002), Saldaña achieved her career breakthrough with her work in numerous science fiction films, beginning in 2009 with her first of multiple appearances as Nyota Uhura in the Star Trek film series and her first appearance as Neytiri in the Avatar film series. She portrays Gamora in the Marvel Cinematic Universe, beginning with Guardians of the Galaxy (2014).[1] Saldaña appeared in three of the five highest-grossing films of all time (Avatar, Avengers: Infinity War, and Avengers: Endgame), a feat not achieved by any other actor.[2] Her films grossed more than $11 billion worldwide,[3] and she is the second-highest-grossing film actress of all time as of 2019.[4]",
                    ImageName="erp54RtY3s.jpg"
                },
                new()
                {
                    Id=3,
                    FirstName="Sigourney",
                    LastName="Weaver",
                    //Birthday=new DateTime(1949, 10, 8),
                    Birthday="1949-10-8",
                    Height=185,
                    Bio="Susan Alexandra \"Sigourney\" Weaver (/sɪˈɡɔːrni/;[1] born October 8, 1949) is an American actress. An influential figure in science fiction and popular culture,[2] Weaver has received several accolades, including a British Academy Film Award, two Golden Globe Awards, a Grammy Award, and nominations for three Academy Awards, four Primetime Emmy Awards, and a Tony Award.[3] She was voted Number 20 in Channel 4's countdown of the 100 Greatest Movie Stars of All Time, being one of only two women in the Top 20.[4]",
                    ImageName="erTyUiP42a.jfif"
                },
                new()
                {
                    Id=4,
                    FirstName="Stephen",
                    LastName="Lang",
                    //Birthday=new DateTime(1952, 7, 11),
                    Birthday="1952-7-11",
                    Height=179,
                    Bio="Stephen Lang (born July 11, 1952) is an American actor. He is known for roles in films including Manhunter (1986), Gettysburg, Tombstone (both 1993), Gods and Generals (2003), Public Enemies (2009), Conan the Barbarian (2011), The Girl on the Train (2013) and Don't Breathe (2016). Outside of these roles, he has had an extensive career on Broadway, and has received a Tony Award nomination for his role in the 1992 production of The Speed of Darkness and won the Saturn Award for Best Supporting Actor for his performance in James Cameron's Avatar (2009). From 2004 to 2006, he was co-artistic director of the Actors Studio.",
                    ImageName="eraaUiP42a.jfif"
                },
                new()
                {
                    Id=5,
                    FirstName="Michael",
                    LastName="Keaton",
                    Birthday="1952-7-11",
                    Height=175,
                    Bio="Michael John Douglas (born September 5, 1951), professionally known as Michael Keaton, is an American actor. He is best known for portraying the DC Comics superhero Bruce Wayne / Batman in the films Batman (1989) and Batman Returns (1992), and is set to reprise the role in the 2023 DC Extended Universe (DCEU) film The Flash. Keaton is also known for his work as Jack Butler in Mr. Mom (1983), Betelgeuse in Beetlejuice (1988), and Adrian Toomes / Vulture in Spider-Man: Homecoming (2017) and Morbius (2022).",
                    ImageName="erbbUiP42a.jfif"
                },
                new()
                {
                    Id=6,
                    FirstName="Edward",
                    LastName="Norton",
                    Birthday="1952-7-11",
                    Height=183,
                    Bio="Edward Harrison Norton (born August 18, 1969) is an American actor and filmmaker. He has received numerous awards and nominations, including a Golden Globe Award and three Academy Award nominations. Born in Boston, Massachusetts and raised in Columbia, Maryland,[1] Norton was drawn to theatrical productions at local venues as a child. After graduating from Yale College in 1991, he worked for a few months in Japan before moving to New York City to pursue an acting career.",
                    ImageName="erbbUieeea.jfif"
                },
                new()
                {
                    Id=7,
                    FirstName="Christopher",
                    LastName="Walken",
                    Birthday="1952-7-11",
                    Height=183,
                    Bio="Christopher Walken (born Ronald Walken; March 31, 1943) is an American actor. Prolific in films, television and on stage, Walken is the recipient of numerous accolades including an Academy Award, a BAFTA Award and a Screen Actors Guild Award, as well as nominations for two Primetime Emmy Awards and two Tony Awards. His films have grossed more than $1.6 billion in the United States alone.[1]",
                    ImageName="erbbUi2e0a.jfif"
                },
                new()
                {
                    Id=8,
                    FirstName="Zach",
                    LastName="Galifianakis",
                    Birthday="1952-7-11",
                    Height=170,
                    Bio="Zachary Knight Galifianakis (born October 1, 1969) is an American actor, comedian, musician and screenwriter. He appeared in Comedy Central Presents special and presented his show Late World with Zach on VH1.\r\n\r\nGalifianakis has starred in films including The Hangover trilogy (2009–2013), Due Date (2010), The Campaign (2012), Birdman or (The Unexpected Virtue of Ignorance) (2014) and Masterminds (2016). He has also voiced characters in animated films such as Puss in Boots (2011), The Lego Batman Movie (2017), Missing Link (2019), The Bob's Burgers Movie (2022), and Ron's Gone Wrong (2021).",
                    ImageName="abcbUi2e0a.jfif"
                },
                new()
                {
                    Id=9,
                    FirstName="Emma",
                    LastName="Stone",
                    Birthday="1952-7-11",
                    Height=168,
                    Bio="Emily Jean \"Emma\" Stone[a] (born November 6, 1988) is an American actress. She is the recipient of various accolades, including an Academy Award, a British Academy Film Award, and a Golden Globe Award. In 2017, she was the world's highest-paid actress and named by Time magazine as one of the 100 most influential people in the world.",
                    ImageName="abcbFF2e0a.jfif"
                },
                new()
                {
                    Id=10,
                    FirstName="Heath",
                    LastName="Ledger",
                    Birthday="1952-7-11",
                    Height=185,
                    Bio="Heath Andrew Ledger[a] (4 April 1979 – 22 January 2008) was an Australian actor and music video director. After playing roles in several Australian television and film productions during the 1990s, Ledger moved to the United States in 1998 to develop his film career further. His work consisted of twenty films, including 10 Things I Hate About You (1999), The Patriot (2000), A Knight's Tale (2001), Monster's Ball (2001), Lords of Dogtown (2005), Brokeback Mountain (2005), Candy (2006), I'm Not There (2007), The Dark Knight (2008), and The Imaginarium of Doctor Parnassus (2009), the latter two being posthumous releases.[1] He also produced and directed music videos and aspired to be a film director.[2]",
                    ImageName="abgbHF2e0a.jfif"
                },
                new()
                {
                    Id=11,
                    FirstName="Christian",
                    LastName="Bale",
                    Birthday="1952-7-11",
                    Height=183,
                    Bio="Christian Charles Philip Bale (born 30 January 1974) is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards. Forbes magazine ranked him as one of the highest-paid actors in 2014.",
                    ImageName="abg3456e0a.jfif"
                },
                new()
                {
                    Id=12,
                    FirstName="Gary",
                    LastName="Oldman",
                    Birthday="1952-7-11",
                    Height=174,
                    Bio="Gary Leonard Oldman (born 21 March 1958) is an English actor and filmmaker. Known for his versatility and intense acting style, he has received various accolades, including an Academy Award, a Golden Globe Award, and three British Academy Film Awards. His films have grossed over $11 billion worldwide, making him one of the highest-grossing actors of all time.[1]",
                    ImageName="aSSS456e0a.jfif"
                },
                new()
                {
                    Id=13,
                    FirstName="Aaron",
                    LastName="Eckhart",
                    Birthday="1952-7-11",
                    Height=179,
                    Bio="Aaron Edward Eckhart (born March 12, 1968) is an American actor. Born in Cupertino, California, Eckhart moved to the United Kingdom at an early age, when his father relocated the family. Several years later, he began his acting career by performing in school plays, before moving to Australia for his high school senior year. He left high school without graduating, but earned a diploma through a professional education course, and graduated from Brigham Young University (BYU) in 1994 with a Bachelor of Fine Arts (BFA) degree in film. For much of the mid-1990s, he lived in New York City as a struggling, unemployed actor.",
                    ImageName="a4SS454e0a.jfif"
                },
                new()
                {
                    Id=14,
                    FirstName="Michael",
                    LastName="Caine",
                    Birthday="1952-7-11",
                    Height=188,
                    Bio="Sir Michael Caine CBE (born Maurice Joseph Micklewhite; 14 March 1933) is an English actor. Known for his distinctive South London accent, he has appeared in more than 160 films in a career spanning seven decades, and is considered a British film icon.[2][3] He has received various awards including two Academy Awards, a BAFTA Award, three Golden Globe Awards, and a Screen Actors Guild Award. As of February 2017, the films in which Caine has appeared have grossed over $7.8 billion worldwide.[4] Caine is one of only five male actors to be nominated for an Academy Award for acting in five different decades.[nb 1] He has appeared in seven films that featured in the British Film Institute's 100 greatest British films of the 20th century. In 2000, he received a BAFTA Fellowship and was knighted by Queen Elizabeth II for his contribution to cinema.",
                    ImageName="eyt74RT9iF.jfif"
                },
                new()
                {
                    Id=15,
                    FirstName="Morgan",
                    LastName="Freeman",
                    Birthday="1952-7-11",
                    Height=188,
                    Bio="Morgan Freeman[2] (born June 1, 1937) is an American actor, director, and narrator. He is known for his distinctive deep voice and various roles in a wide variety of film genres. Throughout his career spanning over five decades, he has received multiple accolades, including an Academy Award, a Screen Actors Guild Award, and a Golden Globe Award.",
                    ImageName="df46T8Uipr.jfif"
                },
                new()
                {
                    Id=16,
                    FirstName="Joaquin",
                    LastName="Phoenix",
                    Birthday="1952-7-11",
                    Height=173,
                    Bio="Joaquin Rafael Phoenix[a] (/hwɑːˈkiːn/; né Bottom; born October 28, 1974) is an American actor. Known for playing dark and unconventional characters in independent films, he has received various accolades, including an Academy Award, a British Academy Film Award, a Grammy Award, and two Golden Globe Awards. In 2020, The New York Times named him one of the greatest actors of the 21st century.[3]",
                    ImageName="3246T8wipr.jfif"
                },
                new()
                {
                    Id=17,
                    FirstName="Jared",
                    LastName="Leto",
                    Birthday="1952-7-11",
                    Height=180,
                    Bio="Jared Joseph Leto (/ˈlɛtoʊ/; born December 26, 1971) is an American actor and musician. Known for his method acting in a variety of roles, he has received numerous accolades over a career spanning three decades, including an Academy Award and a Golden Globe Award.[1] Additionally, he is recognised for his musicianship and eccentric stage persona as a member of the rock band Thirty Seconds to Mars.[2]",
                    ImageName="dF46fghipr.jfif"
                },
                new()
                {
                    Id=18,
                    FirstName="Reese",
                    LastName="Witherspoon",
                    Birthday="1952-7-11",
                    Height=156,
                    Bio="Laura Jeanne Reese Witherspoon (born March 22, 1976) is an American actress and producer. The recipient of various accolades, including an Academy Award, a British Academy Film Award, a Primetime Emmy Award, and two Golden Globe Awards, she has consistently ranked among the world's highest-paid actresses. Time magazine named her one of the 100 most influential people in the world in 2006 and 2015, and Forbes listed her among the World's 100 Most Powerful Women in 2019. In 2021, Forbes named her the world's richest actress with an estimated net worth of $400 million.[1]",
                    ImageName="dfddc8Uhpr.jfif"
                },
                new()
                {
                    Id=19,
                    FirstName="Robert",
                    LastName="De Niro",
                    Birthday="1952-7-11",
                    Height=175,
                    Bio="Robert Anthony De Niro Jr. (/də ˈnɪəroʊ/ də NEER-oh, Italian: [de ˈniːro]; born August 17, 1943) is an American actor and producer. He is particularly known for his nine collaborations with filmmaker Martin Scorsese, and is the recipient of various accolades, including two Academy Awards, a Golden Globe Award, the Cecil B. DeMille Award, and a Screen Actors Guild Life Achievement Award. In 2009, De Niro received the Kennedy Center Honor, and received a Presidential Medal of Freedom from U.S. President Barack Obama in 2016.",
                    ImageName="df11c7Uhpr.jfif"
                },
                new()
                {
                    Id=20,
                    FirstName="Uma",
                    LastName="Thurman",
                    Birthday="1952-7-11",
                    Height=175,
                    Bio="Uma Karuna Thurman (born April 29, 1970) is an American actress, producer and fashion model. Prolific in film and television productions encompassing a variety of genres, she had her breakthrough in Dangerous Liaisons (1988), following appearances on the December 1985 and May 1986 covers of British Vogue. Thurman rose to international prominence with her role as Mia Wallace in Quentin Tarantino's Pulp Fiction (1994),[1] for which she was nominated for the Academy Award, the BAFTA Award, and the Golden Globe Award for Best Supporting Actress. Hailed as Tarantino's muse,[2] she reunited with the director to play The Bride in Kill Bill: Volume 1 and 2 (2003 and 2004),[3] which brought her two additional Golden Globe Award nominations.[4]",
                    ImageName="df89c2Uhpr.jfif"
                },
                new()
                {
                    Id=21,
                    FirstName="John",
                    LastName="Travolta",
                    Birthday="1952-7-11",
                    Height=188,
                    Bio="John Joseph Travolta (born February 18, 1954)[1][2] is an American actor and singer. He came to public attention during the 1970s, appearing on the television sitcom Welcome Back, Kotter (1975–1979) and starring in the box office successes Carrie (1976), Saturday Night Fever (1977), Grease (1978), and Urban Cowboy (1980). His acting career declined throughout the 1980s, but he enjoyed a resurgence in the 1990s with his role in Pulp Fiction (1994), and went on to star in films including Get Shorty (1995), Broken Arrow (1996), Phenomenon (1996), Face/Off (1997), A Civil Action (1998), Primary Colors (1998), Hairspray (2007), and Bolt (2008).",
                    ImageName="dfiuc2RRpr.jfif"
                },
                new()
                {
                    Id=22,
                    FirstName="Tim",
                    LastName="Roth",
                    Birthday="1952-7-11",
                    Height=170,
                    Bio="Timothy Simon Roth (born 14 May 1961) is an English actor. He began acting on films and television series in the 1980s. He was among a group of prominent British actors of the era, the \"Brit Pack\".",
                    ImageName="sd11c34Rpr.jfif"
                },
                new()
                {
                    Id=23,
                    FirstName="Bradley",
                    LastName="Cooper",
                    Birthday="1952-7-11",
                    Height=185,
                    Bio="Bradley Charles Cooper (born January 5, 1975) is an American actor and filmmaker. He is the recipient of various accolades, including a British Academy Film Award and two Grammy Awards, in addition to nominations for nine Academy Awards, six Golden Globe Awards, and a Tony Award. Cooper appeared on the Forbes Celebrity 100 three times and on Time's list of the 100 most influential people in the world in 2015. His films have grossed $11 billion worldwide and he has placed four times in annual rankings of the world's highest-paid actors.",
                    ImageName="sd55c64yDr.jfif"
                },
                new()
                {
                    Id=24,
                    FirstName="Ken",
                    LastName="Jeong",
                    Birthday="1952-7-11",
                    Height=162,
                    Bio="Kendrick Kang-Joh Jeong (Korean: 정강조; Hanja: 鄭康祖, /dʒɒŋ/; born July 13, 1969) is an American stand-up comedian, actor, producer, writer and licensed physician.[1][2] He rose to prominence for playing Leslie Chow in The Hangover film series (2009–2013) and Ben Chang in the NBC series Community (2009–2015). He created, wrote and produced the ABC sitcom Dr. Ken (2015–2017), in which he portrays the titular character, and he has appeared in the films Knocked Up (2007), Role Models (2008), Furry Vengeance (2010), The Duff (2015), Ride Along 2 (2016), Crazy Rich Asians (2018) and Tom & Jerry (2021).[3]",
                    ImageName="qw55d54yDF.jfif"
                },
                new()
                {
                    Id=25,
                    FirstName="Ed",
                    LastName="Helms",
                    Birthday="1952-7-11",
                    Height=182,
                    Bio="Edward Parker Helms[1] (born January 24, 1974) is an American actor, comedian, singer, writer, and producer. From 2002 to 2006 he was a correspondent on Comedy Central's The Daily Show with Jon Stewart. He then played paper salesman Andy Bernard in the NBC sitcom The Office (2006–2013), and starred as Stuart Price in The Hangover trilogy. He currently stars in the comedy series Rutherford Falls (2021–present).",
                    ImageName="qw00d54yDF.jfif"
                },
                new()
                {
                    Id=26,
                    FirstName="Justin",
                    LastName="Bartha",
                    Birthday="1952-7-11",
                    Height=173,
                    Bio="Justin Lee Bartha (born July 21, 1978) is an American actor, known for his roles as Riley Poole in the National Treasure film series, Doug Billings in The Hangover trilogy, and David Sawyer in the NBC comedy series The New Normal. He starred as Colin Morrello in the CBS All Access legal and political drama The Good Fight.",
                    ImageName="qw11c5ryjF.jfif"
                },
                new()
                {
                    Id=27,
                    FirstName="Samuel",
                    LastName="L. Jackson",
                    Birthday="1952-7-11",
                    Height=189,
                    Bio="Samuel Leroy Jackson (born December 21, 1948) is an American actor. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time, only behind Stan Lee (who was most notable for his cameo appearances).[1][2][3]",
                    ImageName="qw789hrdjF.jfif"
                },
                new()
                {
                    Id=28,
                    FirstName="Heather",
                    LastName="Graham",
                    Birthday="1952-7-11",
                    Height=173,
                    Bio="Heather Joan Graham (born January 29, 1970[1]) is an American actress. After appearing in television commercials, her first starring role in a feature film came with the teen comedy License to Drive (1988), followed by the critically acclaimed film Drugstore Cowboy (1989).[2][3] She then played supporting roles on the television series Twin Peaks (1991), and in films such as Six Degrees of Separation (1993) and Swingers (1996). She gained critical praise for her role as \"Rollergirl\" in the film Boogie Nights (1997).[4] This led to major roles in the comedy films Bowfinger and Austin Powers: The Spy Who Shagged Me (both 1999).",
                    ImageName="qw44chryjF.jfif"
                },
                new()
                {
                    Id=29,
                    FirstName="Bruce",
                    LastName="Willis",
                    Birthday="1952-7-11",
                    Height=183,
                    Bio="Walter Bruce Willis (born March 19, 1955) is a retired American actor. His career began on the off-Broadway stage in the 1970s.[1] He achieved fame with a leading role on the comedy-drama series Moonlighting (1985–1989) and appeared in over a hundred films, gaining recognition as an action hero after his portrayal of John McClane in the Die Hard franchise (1988–2013) and other roles.[2][3]",
                    ImageName="qw66cgr1jF.jfif"
                },
                new()
                {
                    Id=30,
                    FirstName="Willem",
                    LastName="Dafoe",
                    Birthday="1952-7-11",
                    Height=175,
                    Bio="Willem James Dafoe (/dəˈfoʊ/;[1] born July 22, 1955) is an American actor. He is the recipient of various accolades, including the Volpi Cup for Best Actor, in addition to receiving nominations for four Academy Awards, four Screen Actors Guild Awards, three Golden Globe Awards, and a British Academy Film Award. He frequently collaborates with filmmakers Paul Schrader, Abel Ferrara, Lars von Trier, Julian Schnabel, and Wes Anderson.",
                    ImageName="e4R5t6y7uI.jfif"
                },
                new()
                {
                    Id=31,
                    FirstName="James",
                    LastName="Cameron",
                    Birthday="1952-7-11",
                    Height=187,
                    Bio="James Francis Cameron CC (born August 16, 1954) is a Canadian filmmaker. Best known for making science fiction and epic films, he first gained recognition for directing The Terminator (1984). He found further success with Aliens (1986), The Abyss (1989), Terminator 2: Judgment Day (1991), and the action comedy True Lies (1994). He also directed Titanic (1997) and Avatar (2009), with Titanic earning him Academy Awards in Best Picture, Best Director and Best Film Editing. Avatar, filmed in 3D technology, earned him nominations in the same categories.",
                    ImageName="q2Er1Xavt7.jfif"
                },
                new()
                {
                    Id=32,
                    FirstName="Alejandro",
                    LastName="González Iñárritu",
                    Birthday="1952-7-11",
                    Height=184,
                    Bio="Alejandro González Iñárritu (/ɪˈnjɑːrɪtuː/; American Spanish: [aleˈxandɾo ɣonˈsales iˈɲaritu]; credited since 2014 as Alejandro G. Iñárritu; born 15 August 1963) is a Mexican filmmaker and screenwriter. He is primarily known for making modern psychological drama films about the human condition. His projects have garnered critical acclaim and numerous accolades including eight Academy Awards with a Special Achievement Award, six Golden Globe Awards, eight British Academy Film Awards, two American Film Institute Awards, two Directors Guild of America Awards and a Producers Guild of America Award. His most notable films include Amores perros (2000), 21 Grams (2003), Babel (2006), Biutiful (2010), Birdman (2014), and The Revenant (2015).",
                    ImageName="gheCBni7tP.jfif"
                },
                new()
                {
                    Id=33,
                    FirstName="Quentin",
                    LastName="Tarantino",
                    Birthday="1952-7-11",
                    Height=185,
                    Bio="Quentin Jerome Tarantino (/ˌtærənˈtiːnoʊ/; born March 27, 1963)[1] is an American filmmaker and actor. His films are characterized by frequent references to popular culture and film genres, nonlinear storylines, dark humor, stylized violence, extended dialogue, pervasive use of profanity, cameos and ensemble casts. Other directorial tropes that identify his style include the use of songs from the 1960s and 70s; fictional brand parodies; and imagery of women's bare feet.",
                    ImageName="12wsFGyU76.jfif"
                },
                new()
                {
                    Id=34,
                    FirstName="Christopher",
                    LastName="Nolan",
                    Birthday="1952-7-11",
                    Height=181,
                    Bio="Christopher Nolan[1] CBE (/ˈnoʊlən/; born 30 July 1970) is a British-American film director, producer, and screenwriter. His films have grossed more than US$5 billion worldwide and have garnered 11 Academy Awards from 36 nominations.\r\n\r\nBorn and raised in London, Nolan developed an interest in filmmaking from a young age. After studying English literature at University College London, he made his feature debut with Following (1998). Nolan gained international recognition with his second film, Memento (2000), for which he was nominated for the Academy Award for Best Original Screenplay.",
                    ImageName="aSQwcGb538.jfif"
                },
                new()
                {
                    Id=35,
                    FirstName="Todd",
                    LastName="Phillips",
                    Birthday="1952-7-11",
                    Height=183,
                    Bio="Todd Phillips (né Bunzl, born December 20, 1970)[1] is an American filmmaker and occasional actor. Phillips began his career in 1993 and directed films in the 2000s such as Road Trip, Old School, Starsky & Hutch, and School for Scoundrels. He came to wider prominence in the early 2010s for directing The Hangover film series. In 2019, he co-wrote and directed the psychological thriller film Joker, based on the DC Comics character of the same name, which premiered at the 76th Venice International Film Festival where it received the top prize, the Golden Lion. Joker went on to earn Phillips three Academy Award nominations for Best Picture, Best Director, and Best Adapted Screenplay, with his co-writer Scott Silver.",
                    ImageName="Rt56YuiO98.jfif"
                },
                new()
                {
                    Id=36,
                    FirstName="Mary",
                    LastName="Harron",
                    Birthday="1952-7-11",
                    Height=167,
                    Bio="Mary Harron (born January 12, 1953)[1] is a Canadian filmmaker and screenwriter, and former entertainment critic. She gained recognition for her role in writing and directing several independent films, including I Shot Andy Warhol (1996), American Psycho (2000), and The Notorious Bettie Page (2005). She co-wrote American Psycho and The Notorious Bettie Page with Guinevere Turner.",
                    ImageName="yui86PMvd2.jfif"
                }
            });

            modelBuilder.Entity<PersonMovie>().HasData(new PersonMovie[]
            {
                new() { Id=1, MovieId=1, PersonId=1, IsActor=true },
                new() { Id=2, MovieId=1, PersonId=2, IsActor=true },
                new() { Id=3, MovieId=1, PersonId=3, IsActor=true },
                new() { Id=4, MovieId=1, PersonId=4, IsActor=true },
                new() { Id=5, MovieId=1, PersonId=31, IsDirector=true },

                new() { Id=6, MovieId=2, PersonId=5, IsActor=true },
                new() { Id=7, MovieId=2, PersonId=6, IsActor=true },
                new() { Id=8, MovieId=2, PersonId=8, IsActor=true },
                new() { Id=9, MovieId=2, PersonId=9, IsActor=true },
                new() { Id=10, MovieId=2, PersonId=32, IsDirector=true },

                new() { Id=11, MovieId=3, PersonId=10, IsActor=true },
                new() { Id=12, MovieId=3, PersonId=11, IsActor=true },
                new() { Id=13, MovieId=3, PersonId=12, IsActor=true },
                new() { Id=14, MovieId=3, PersonId=13, IsActor=true },
                new() { Id=15, MovieId=3, PersonId=14, IsActor=true },
                new() { Id=16, MovieId=3, PersonId=15, IsActor=true },
                new() { Id=17, MovieId=3, PersonId=34, IsDirector=true },

                new() { Id=18, MovieId=4, PersonId=17, IsActor=true },
                new() { Id=19, MovieId=4, PersonId=18, IsActor=true },
                new() { Id=20, MovieId=4, PersonId=11, IsActor=true },
                new() { Id=21, MovieId=4, PersonId=36, IsDirector=true },

                new() { Id=22, MovieId=5, PersonId=16, IsActor=true },
                new() { Id=23, MovieId=5, PersonId=19, IsActor=true },
                new() { Id=24, MovieId=5, PersonId=23, IsActor=true },
                new() { Id=25, MovieId=5, PersonId=35, IsDirector=true },

                new() { Id=26, MovieId=6, PersonId=7, IsActor=true },
                new() { Id=27, MovieId=6, PersonId=20, IsActor=true },
                new() { Id=28, MovieId=6, PersonId=21, IsActor=true },
                new() { Id=29, MovieId=6, PersonId=27, IsActor=true },
                new() { Id=30, MovieId=6, PersonId=29, IsActor=true },
                new() { Id=31, MovieId=6, PersonId=22, IsActor=true },
                new() { Id=32, MovieId=6, PersonId=33, IsDirector=true },

                new() { Id=33, MovieId=7, PersonId=8, IsActor=true },
                new() { Id=34, MovieId=7, PersonId=23, IsActor=true },
                new() { Id=35, MovieId=7, PersonId=24, IsActor=true },
                new() { Id=36, MovieId=7, PersonId=25, IsActor=true },
                new() { Id=37, MovieId=7, PersonId=26, IsActor=true },
                new() { Id=38, MovieId=7, PersonId=28, IsActor=true },
                new() { Id=39, MovieId=7, PersonId=35, IsDirector=true },
            });

            modelBuilder.Entity<Genre>().HasData(new Genre[]
            {
                new () { Id=1, Name = "Horror" },
                new () { Id=2, Name = "Action" },
                new () { Id=3, Name = "Western" },
                new () { Id=4, Name = "Science fiction" },
                new () { Id=5, Name = "Thriller" },
                new () { Id=6, Name = "Drama" },
                new () { Id=7, Name = "Romance" },
                new () { Id=8, Name = "Comedy" },
                new () { Id=9, Name = "Crime film" },
                new () { Id=10, Name = "Fantasy" },
                new () { Id=11, Name = "Historical" },
                new () { Id=12, Name = "Adventure" },
                new () { Id=13, Name = "Musical" },
                new () { Id=14, Name = "Mystery" },
                new () { Id=15, Name = "Biographical" },
                new () { Id=16, Name = "Martial arts" },
                new () { Id=17, Name = "Dark comedy" },
                new () { Id=18, Name = "Romantic comedy" },
                new () { Id=19, Name = "War" },
                new () { Id=20, Name = "Documentary" },
                new () { Id=21, Name = "Sport" },
                new () { Id=22, Name = "Detective" },
                new () { Id=23, Name = "Satire" },
                new () { Id=24, Name = "Indie film" },
                new () { Id=25, Name = "Superhero" },
                new () { Id=26, Name = "Psychological thriller" },
                new () { Id=27, Name = "Comedy horror" },
                new () { Id=28, Name = "Crime fiction" },
                new () { Id=29, Name = "Mafia" },
            });

            modelBuilder.Entity<GenreMovie>().HasData(new GenreMovie[]
            {
                new () { Id=1, MovieId=1, GenreId=2 },
                new () { Id=2, MovieId=1, GenreId=10 },
                new () { Id=3, MovieId=1, GenreId=12 },
                new () { Id=4, MovieId=1, GenreId=4 },
                new () { Id=5, MovieId=1, GenreId=14 },

                new () { Id=6, MovieId=2, GenreId=7 },
                new () { Id=7, MovieId=2, GenreId=8 },
                new () { Id=8, MovieId=2, GenreId=23 },
                new () { Id=9, MovieId=2, GenreId=6 },
                new () { Id=10, MovieId=2, GenreId=17 },
                new () { Id=11, MovieId=2, GenreId=24 },

                new () { Id=12, MovieId=3, GenreId=2 },
                new () { Id=13, MovieId=3, GenreId=25 },
                new () { Id=14, MovieId=3, GenreId=9 },
                new () { Id=15, MovieId=3, GenreId=5 },
                new () { Id=16, MovieId=3, GenreId=12 },
                new () { Id=17, MovieId=3, GenreId=6 },
                new () { Id=18, MovieId=3, GenreId=14 },

                new () { Id=19, MovieId=4, GenreId=1 },
                new () { Id=20, MovieId=4, GenreId=5 },
                new () { Id=21, MovieId=4, GenreId=23 },
                new () { Id=22, MovieId=4, GenreId=8 },
                new () { Id=23, MovieId=4, GenreId=26 },
                new () { Id=24, MovieId=4, GenreId=17 },
                new () { Id=25, MovieId=4, GenreId=14 },
                new () { Id=26, MovieId=4, GenreId=6 },
                new () { Id=27, MovieId=4, GenreId=27 },
                new () { Id=28, MovieId=4, GenreId=28 },

                new () { Id=29, MovieId=5, GenreId=5 },
                new () { Id=30, MovieId=5, GenreId=26 },
                new () { Id=31, MovieId=5, GenreId=6 },
                new () { Id=32, MovieId=5, GenreId=9 },

                new () { Id=33, MovieId=6, GenreId=8 },
                new () { Id=34, MovieId=6, GenreId=5 },
                new () { Id=35, MovieId=6, GenreId=28 },
                new () { Id=36, MovieId=6, GenreId=29 },
                new () { Id=37, MovieId=6, GenreId=17 },
                new () { Id=38, MovieId=6, GenreId=24 },
                new () { Id=39, MovieId=6, GenreId=6 },

                new () { Id=40, MovieId=7, GenreId=8 },
                new () { Id=41, MovieId=7, GenreId=12 },
            });

            modelBuilder.Entity<Country>().HasData(new Country[]
            {
                new Country { Id=1, Name="US" },
                new Country { Id=2, Name="Canada" },
                new Country { Id=3, Name="UK" },
                new Country { Id=4, Name="Italy" },
                new Country { Id=5, Name="Germany" },
                new Country { Id=6, Name="Spain" },
                new Country { Id=7, Name="Mexico" },
                new Country { Id=8, Name="Russia" },
            });

            modelBuilder.Entity<CountryMovie>().HasData(new CountryMovie[]
            {
                new () { Id=1, MovieId=1, CountryId=1 },
                new () { Id=2, MovieId=1, CountryId=3 },
                new () { Id=3, MovieId=2, CountryId=1 },
                new () { Id=4, MovieId=2, CountryId=2 },
                new () { Id=5, MovieId=3, CountryId=1 },
                new () { Id=6, MovieId=3, CountryId=3 },
                new () { Id=7, MovieId=4, CountryId=1 },
                new () { Id=8, MovieId=5, CountryId=1 },
                new () { Id=9, MovieId=5, CountryId=2 },
                new () { Id=10, MovieId=6, CountryId=1 },
                new () { Id=11, MovieId=7, CountryId=1 },
            });
        }

    }
}
