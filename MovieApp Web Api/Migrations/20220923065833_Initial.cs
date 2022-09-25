using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieApp_Web_Api.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(56)", maxLength: 56, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VideoDuration = table.Column<double>(type: "float", nullable: true),
                    ImageUniqueName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    VideoUniqueName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMovies", x => new { x.CountryId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_CountryMovies_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMovies", x => new { x.GenreId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_GenreMovies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonMovies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    IsActor = table.Column<bool>(type: "bit", nullable: true),
                    IsDirector = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonMovies", x => new { x.PersonId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_PersonMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonMovies_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "US" },
                    { 2, "Canada" },
                    { 3, "UK" },
                    { 4, "Italy" },
                    { 5, "Germany" },
                    { 6, "Spain" },
                    { 7, "Mexico" },
                    { 8, "Russia" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Action" },
                    { 3, "Western" },
                    { 4, "Science fiction" },
                    { 5, "Thriller" },
                    { 6, "Drama" },
                    { 7, "Romance" },
                    { 8, "Comedy" },
                    { 9, "Crime film" },
                    { 10, "Fantasy" },
                    { 11, "Historical" },
                    { 12, "Adventure" },
                    { 13, "Musical" },
                    { 14, "Mystery" },
                    { 15, "Biographical" },
                    { 16, "Martial arts" },
                    { 17, "Dark comedy" },
                    { 18, "Romantic comedy" },
                    { 19, "War" },
                    { 20, "Documentary" },
                    { 21, "Sport" },
                    { 22, "Detective" },
                    { 23, "Satire" },
                    { 24, "Indie film" },
                    { 25, "Superhero" },
                    { 26, "Psychological thriller" },
                    { 27, "Comedy horror" },
                    { 28, "Crime fiction" },
                    { 29, "Mafia" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "VideoDuration", "ImageUniqueName", "Title", "VideoUniqueName", "Year" },
                values: new object[,]
                {
                    { 1, "Avatar (also marketed as James Cameron's Avatar) is a 2009 American[7][8] epic science fiction film directed, written, produced, and co-edited by James Cameron and starring Sam Worthington, Zoe Saldana, Stephen Lang, Michelle Rodriguez, and Sigourney Weaver. It is set in the mid-22nd century when humans are colonizing Pandora, a lush habitable moon of a gas giant in the Alpha Centauri star system, in order to mine the valuable mineral unobtanium.[9][10][11] The expansion of the mining colony threatens the continued existence of a local tribe of Na'vi – a humanoid species indigenous to Pandora. The film's title refers to a genetically engineered Na'vi body operated from the brain of a remotely located human that is used to interact with the natives of Pandora.[12]", 160.0, "78dfgr5HY6.jpg", "Avatar", "aFe3gkYu78.mp4", 2009 },
                    { 2, "Birdman or (The Unexpected Virtue of Ignorance), or simply Birdman, is a 2014 American black comedy-drama film directed by Alejandro G. Iñárritu. It was written by Iñárritu, Nicolás Giacobone, Alexander Dinelaris Jr., and Armando Bó. The film stars Michael Keaton as Riggan Thomson, a faded Hollywood actor best known for playing the superhero \"Birdman\", as he struggles to mount a Broadway adaptation of Raymond Carver's short story, \"What We Talk About When We Talk About Love\". The film also features a supporting cast of Zach Galifianakis, Edward Norton, Andrea Riseborough, Amy Ryan, Emma Stone, and Naomi Watts.", 120.0, "r435t349AB.jpg", "Birdman", "t349FF8111.mp4", 2014 },
                    { 3, "The Dark Knight is a 2008 superhero film directed by Christopher Nolan from a screenplay he co-wrote with his brother Jonathan. Based on the DC Comics superhero Batman, it is the sequel to Batman Begins (2005) and the second installment in The Dark Knight Trilogy. The film follows the vigilante Batman, police lieutenant James Gordon, and district attorney Harvey Dent as they form an alliance to dismantle organized crime in Gotham City. Their efforts are derailed by the intervention of the Joker, an anarchistic mastermind who seeks to test how far Batman will go to save the city from complete chaos. The ensemble cast includes Christian Bale, Michael Caine, Heath Ledger, Gary Oldman, Aaron Eckhart, Maggie Gyllenhaal, and Morgan Freeman.", 152.0, "eht58T9ef4.jpg", "The Dark Knight", "3wer5YtUiO.mp4", 2008 },
                    { 4, "American Psycho is a 2000 slasher film directed by Mary Harron, who co-wrote the screenplay with Guinevere Turner. Based on Bret Easton Ellis's 1991 novel American Psycho, it stars Christian Bale as Patrick Bateman, a New York City investment banker who leads a double life as a serial killer. Willem Dafoe, Jared Leto, Josh Lucas, Chloë Sevigny, Samantha Mathis, Cara Seymour, Justin Theroux, and Reese Witherspoon appear in supporting roles. The film blends horror and black comedy to satirize 1980s yuppie culture and consumerism, exemplified by Bateman.", 162.0, "ehT58T9FG2.jpg", "American Psycho", "3We15YyUiO.mp4", 2000 },
                    { 5, "Joker is a 2019 American psychological thriller film directed and produced by Todd Phillips, who co-wrote the screenplay with Scott Silver. The film, based on DC Comics characters, stars Joaquin Phoenix as the Joker and provides a possible origin story for the character. Set in 1981, it follows Arthur Fleck, a failed clown and aspiring stand-up comedian whose descent into insanity and nihilism inspires a violent countercultural revolution against the wealthy in a decaying Gotham City. Robert De Niro, Zazie Beetz, Frances Conroy, Brett Cullen, Glenn Fleshler, Bill Camp, Shea Whigham, and Marc Maron appear in supporting roles. Distributed by Warner Bros. Pictures, Joker was produced by Warner Bros. Pictures and DC Films in association with Village Roadshow Pictures, Bron Creative and Joint Effort.", 139.0, "ut45eDfGhw.jpg", "Joker", "3ewUiOf69Z.mp4", 1999 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "VideoDuration", "ImageUniqueName", "Title", "VideoUniqueName", "Year" },
                values: new object[,]
                {
                    { 6, "Pulp Fiction is a 1994 American black comedy crime film written and directed by Quentin Tarantino, who conceived it with Roger Avary.[4] Starring John Travolta, Samuel L. cckson, Bruce Willis, Tim Roth, Ving Rhames, and Uma Thurman, it tells several stories of crime in Los Angeles. The title refers to the pulp magazines and hardboiled crime novels popular during the mid-20th century, known for their graphic violence and punchy dialogue.", 154.0, "dfhtyWR586.jpg", "Pulp Fiction", "qwi49Tfget.mp4", 1994 },
                    { 7, "The Hangover is a 2009 American comedy film directed by Todd Phillips, co-produced with Daniel Goldberg, and written by Jon Lucas and Scott Moore. It is the first installment in The Hangover trilogy. The film stars Bradley Cooper, Ed Helms, Zach Galifianakis, Heather Graham, Justin Bartha, Ken Jeong, and Jeffrey Tambor. It tells the story of Phil Wenneck (Cooper), Stu Price (Helms), Alan Garner (Galifianakis), and Doug Billings (Bartha), who travel to Las Vegas for a bachelor party to celebrate Doug's impending marriage. However, Phil, Stu, and Alan wake up with Doug missing and no memory of the previous night's events, and must find the groom before the wedding can take place.", 100.0, "dfetyeR586.jpg", "The Hangover", "qwi49Tttet.mp4", 2009 }
                });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Biography", "Birthday", "FirstName", "Height", "ImageName", "LastName" },
                values: new object[,]
                {
                    { 1, "Samuel Henry John Worthington[1] (born 2 August 1976) is an Australian actor. He is best known for playing Jake Sully in Avatar, Marcus Wright in Terminator Salvation, and Perseus in Clash of the Titans and its sequel Wrath of the Titans. He later took more dramatic roles, appearing in The Debt (2010), Everest (2015), Hacksaw Ridge (2016), The Shack (2017), Manhunt: Unabomber (2017), and Fractured (2019). On television, he appeared in his native Australia as Howard in Love My Way and as Phillip Schuler in the television drama mini-series Deadline Gallipoli, for which he was also an executive producer. He voiced the protagonist, Captain Alex Mason, in the video games Call of Duty: Black Ops (2010), Call of Duty: Black Ops II (2012), and Call of Duty: Black Ops 4 (2018). In 2022, he starred in the true crime miniseries Under the Banner of Heaven.", "1976-8-2", "Sam", 178, "abdcs34RTf.jfif", "Worthington" },
                    { 2, "Zoe Yadira Saldaña-Perego (née Saldaña Nazario; born June 19, 1978) is an American actress. After performing with the theater group Faces she appeared in two 1999 episodes of Law & Order. Her film career began a year later with Center Stage (2000) in which she portrayed a ballet dancer.\r\n\r\nAfter receiving early recognition for her work opposite Britney Spears in the road film Crossroads (2002), Saldaña achieved her career breakthrough with her work in numerous science fiction films, beginning in 2009 with her first of multiple appearances as Nyota Uhura in the Star Trek film series and her first appearance as Neytiri in the Avatar film series. She portrays Gamora in the Marvel Cinematic Universe, beginning with Guardians of the Galaxy (2014).[1] Saldaña appeared in three of the five highest-grossing films of all time (Avatar, Avengers: Infinity War, and Avengers: Endgame), a feat not achieved by any other actor.[2] Her films grossed more than $11 billion worldwide,[3] and she is the second-highest-grossing film actress of all time as of 2019.[4]", "1978-6-19", "Zoe", 170, "erp54RtY3s.jpg", "Saldaña" },
                    { 3, "Susan Alexandra \"Sigourney\" Weaver (/sɪˈɡɔːrni/;[1] born October 8, 1949) is an American actress. An influential figure in science fiction and popular culture,[2] Weaver has received several accolades, including a British Academy Film Award, two Golden Globe Awards, a Grammy Award, and nominations for three Academy Awards, four Primetime Emmy Awards, and a Tony Award.[3] She was voted Number 20 in Channel 4's countdown of the 100 Greatest Movie Stars of All Time, being one of only two women in the Top 20.[4]", "1949-10-8", "Sigourney", 185, "erTyUiP42a.jfif", "Weaver" },
                    { 4, "Stephen Lang (born July 11, 1952) is an American actor. He is known for roles in films including Manhunter (1986), Gettysburg, Tombstone (both 1993), Gods and Generals (2003), Public Enemies (2009), Conan the Barbarian (2011), The Girl on the Train (2013) and Don't Breathe (2016). Outside of these roles, he has had an extensive career on Broadway, and has received a Tony Award nomination for his role in the 1992 production of The Speed of Darkness and won the Saturn Award for Best Supporting Actor for his performance in James Cameron's Avatar (2009). From 2004 to 2006, he was co-artistic director of the Actors Studio.", "1952-7-11", "Stephen", 179, "eraaUiP42a.jfif", "Lang" },
                    { 5, "Michael John Douglas (born September 5, 1951), professionally known as Michael Keaton, is an American actor. He is best known for portraying the DC Comics superhero Bruce Wayne / Batman in the films Batman (1989) and Batman Returns (1992), and is set to reprise the role in the 2023 DC Extended Universe (DCEU) film The Flash. Keaton is also known for his work as Jack Butler in Mr. Mom (1983), Betelgeuse in Beetlejuice (1988), and Adrian Toomes / Vulture in Spider-Man: Homecoming (2017) and Morbius (2022).", "1952-7-11", "Michael", 175, "erbbUiP42a.jfif", "Keaton" },
                    { 6, "Edward Harrison Norton (born August 18, 1969) is an American actor and filmmaker. He has received numerous awards and nominations, including a Golden Globe Award and three Academy Award nominations. Born in Boston, Massachusetts and raised in Columbia, Maryland,[1] Norton was drawn to theatrical productions at local venues as a child. After graduating from Yale College in 1991, he worked for a few months in Japan before moving to New York City to pursue an acting career.", "1952-7-11", "Edward", 183, "erbbUieeea.jfif", "Norton" },
                    { 7, "Christopher Walken (born Ronald Walken; March 31, 1943) is an American actor. Prolific in films, television and on stage, Walken is the recipient of numerous accolades including an Academy Award, a BAFTA Award and a Screen Actors Guild Award, as well as nominations for two Primetime Emmy Awards and two Tony Awards. His films have grossed more than $1.6 billion in the United States alone.[1]", "1952-7-11", "Christopher", 183, "erbbUi2e0a.jfif", "Walken" },
                    { 8, "Zachary Knight Galifianakis (born October 1, 1969) is an American actor, comedian, musician and screenwriter. He appeared in Comedy Central Presents special and presented his show Late World with Zach on VH1.\r\n\r\nGalifianakis has starred in films including The Hangover trilogy (2009–2013), Due Date (2010), The Campaign (2012), Birdman or (The Unexpected Virtue of Ignorance) (2014) and Masterminds (2016). He has also voiced characters in animated films such as Puss in Boots (2011), The Lego Batman Movie (2017), Missing Link (2019), The Bob's Burgers Movie (2022), and Ron's Gone Wrong (2021).", "1952-7-11", "Zach", 170, "abcbUi2e0a.jfif", "Galifianakis" },
                    { 9, "Emily Jean \"Emma\" Stone[a] (born November 6, 1988) is an American actress. She is the recipient of various accolades, including an Academy Award, a British Academy Film Award, and a Golden Globe Award. In 2017, she was the world's highest-paid actress and named by Time magazine as one of the 100 most influential people in the world.", "1952-7-11", "Emma", 168, "abcbFF2e0a.jfif", "Stone" },
                    { 10, "Heath Andrew Ledger[a] (4 April 1979 – 22 January 2008) was an Australian actor and music video director. After playing roles in several Australian television and film productions during the 1990s, Ledger moved to the United States in 1998 to develop his film career further. His work consisted of twenty films, including 10 Things I Hate About You (1999), The Patriot (2000), A Knight's Tale (2001), Monster's Ball (2001), Lords of Dogtown (2005), Brokeback Mountain (2005), Candy (2006), I'm Not There (2007), The Dark Knight (2008), and The Imaginarium of Doctor Parnassus (2009), the latter two being posthumous releases.[1] He also produced and directed music videos and aspired to be a film director.[2]", "1952-7-11", "Heath", 185, "abgbHF2e0a.jfif", "Ledger" },
                    { 11, "Christian Charles Philip Bale (born 30 January 1974) is an English actor. Known for his versatility and physical transformations for his roles, he has been a leading man in films of several genres. He has received various accolades, including an Academy Award and two Golden Globe Awards. Forbes magazine ranked him as one of the highest-paid actors in 2014.", "1952-7-11", "Christian", 183, "abg3456e0a.jfif", "Bale" },
                    { 12, "Gary Leonard Oldman (born 21 March 1958) is an English actor and filmmaker. Known for his versatility and intense acting style, he has received various accolades, including an Academy Award, a Golden Globe Award, and three British Academy Film Awards. His films have grossed over $11 billion worldwide, making him one of the highest-grossing actors of all time.[1]", "1952-7-11", "Gary", 174, "aSSS456e0a.jfif", "Oldman" },
                    { 13, "Aaron Edward Eckhart (born March 12, 1968) is an American actor. Born in Cupertino, California, Eckhart moved to the United Kingdom at an early age, when his father relocated the family. Several years later, he began his acting career by performing in school plays, before moving to Australia for his high school senior year. He left high school without graduating, but earned a diploma through a professional education course, and graduated from Brigham Young University (BYU) in 1994 with a Bachelor of Fine Arts (BFA) degree in film. For much of the mid-1990s, he lived in New York City as a struggling, unemployed actor.", "1952-7-11", "Aaron", 179, "a4SS454e0a.jfif", "Eckhart" },
                    { 14, "Sir Michael Caine CBE (born Maurice Joseph Micklewhite; 14 March 1933) is an English actor. Known for his distinctive South London accent, he has appeared in more than 160 films in a career spanning seven decades, and is considered a British film icon.[2][3] He has received various awards including two Academy Awards, a BAFTA Award, three Golden Globe Awards, and a Screen Actors Guild Award. As of February 2017, the films in which Caine has appeared have grossed over $7.8 billion worldwide.[4] Caine is one of only five male actors to be nominated for an Academy Award for acting in five different decades.[nb 1] He has appeared in seven films that featured in the British Film Institute's 100 greatest British films of the 20th century. In 2000, he received a BAFTA Fellowship and was knighted by Queen Elizabeth II for his contribution to cinema.", "1952-7-11", "Michael", 188, "eyt74RT9iF.jfif", "Caine" },
                    { 15, "Morgan Freeman[2] (born June 1, 1937) is an American actor, director, and narrator. He is known for his distinctive deep voice and various roles in a wide variety of film genres. Throughout his career spanning over five decades, he has received multiple accolades, including an Academy Award, a Screen Actors Guild Award, and a Golden Globe Award.", "1952-7-11", "Morgan", 188, "df46T8Uipr.jfif", "Freeman" },
                    { 16, "Joaquin Rafael Phoenix[a] (/hwɑːˈkiːn/; né Bottom; born October 28, 1974) is an American actor. Known for playing dark and unconventional characters in independent films, he has received various accolades, including an Academy Award, a British Academy Film Award, a Grammy Award, and two Golden Globe Awards. In 2020, The New York Times named him one of the greatest actors of the 21st century.[3]", "1952-7-11", "Joaquin", 173, "3246T8wipr.jfif", "Phoenix" },
                    { 17, "Jared Joseph Leto (/ˈlɛtoʊ/; born December 26, 1971) is an American actor and musician. Known for his method acting in a variety of roles, he has received numerous accolades over a career spanning three decades, including an Academy Award and a Golden Globe Award.[1] Additionally, he is recognised for his musicianship and eccentric stage persona as a member of the rock band Thirty Seconds to Mars.[2]", "1952-7-11", "Jared", 180, "dF46fghipr.jfif", "Leto" },
                    { 18, "Laura Jeanne Reese Witherspoon (born March 22, 1976) is an American actress and producer. The recipient of various accolades, including an Academy Award, a British Academy Film Award, a Primetime Emmy Award, and two Golden Globe Awards, she has consistently ranked among the world's highest-paid actresses. Time magazine named her one of the 100 most influential people in the world in 2006 and 2015, and Forbes listed her among the World's 100 Most Powerful Women in 2019. In 2021, Forbes named her the world's richest actress with an estimated net worth of $400 million.[1]", "1952-7-11", "Reese", 156, "dfddc8Uhpr.jfif", "Witherspoon" },
                    { 19, "Robert Anthony De Niro Jr. (/də ˈnɪəroʊ/ də NEER-oh, Italian: [de ˈniːro]; born August 17, 1943) is an American actor and producer. He is particularly known for his nine collaborations with filmmaker Martin Scorsese, and is the recipient of various accolades, including two Academy Awards, a Golden Globe Award, the Cecil B. DeMille Award, and a Screen Actors Guild Life Achievement Award. In 2009, De Niro received the Kennedy Center Honor, and received a Presidential Medal of Freedom from U.S. President Barack Obama in 2016.", "1952-7-11", "Robert", 175, "df11c7Uhpr.jfif", "De Niro" },
                    { 20, "Uma Karuna Thurman (born April 29, 1970) is an American actress, producer and fashion model. Prolific in film and television productions encompassing a variety of genres, she had her breakthrough in Dangerous Liaisons (1988), following appearances on the December 1985 and May 1986 covers of British Vogue. Thurman rose to international prominence with her role as Mia Wallace in Quentin Tarantino's Pulp Fiction (1994),[1] for which she was nominated for the Academy Award, the BAFTA Award, and the Golden Globe Award for Best Supporting Actress. Hailed as Tarantino's muse,[2] she reunited with the director to play The Bride in Kill Bill: Volume 1 and 2 (2003 and 2004),[3] which brought her two additional Golden Globe Award nominations.[4]", "1952-7-11", "Uma", 175, "df89c2Uhpr.jfif", "Thurman" },
                    { 21, "John Joseph Travolta (born February 18, 1954)[1][2] is an American actor and singer. He came to public attention during the 1970s, appearing on the television sitcom Welcome Back, Kotter (1975–1979) and starring in the box office successes Carrie (1976), Saturday Night Fever (1977), Grease (1978), and Urban Cowboy (1980). His acting career declined throughout the 1980s, but he enjoyed a resurgence in the 1990s with his role in Pulp Fiction (1994), and went on to star in films including Get Shorty (1995), Broken Arrow (1996), Phenomenon (1996), Face/Off (1997), A Civil Action (1998), Primary Colors (1998), Hairspray (2007), and Bolt (2008).", "1952-7-11", "John", 188, "dfiuc2RRpr.jfif", "Travolta" },
                    { 22, "Timothy Simon Roth (born 14 May 1961) is an English actor. He began acting on films and television series in the 1980s. He was among a group of prominent British actors of the era, the \"Brit Pack\".", "1952-7-11", "Tim", 170, "sd11c34Rpr.jfif", "Roth" },
                    { 23, "Bradley Charles Cooper (born January 5, 1975) is an American actor and filmmaker. He is the recipient of various accolades, including a British Academy Film Award and two Grammy Awards, in addition to nominations for nine Academy Awards, six Golden Globe Awards, and a Tony Award. Cooper appeared on the Forbes Celebrity 100 three times and on Time's list of the 100 most influential people in the world in 2015. His films have grossed $11 billion worldwide and he has placed four times in annual rankings of the world's highest-paid actors.", "1952-7-11", "Bradley", 185, "sd55c64yDr.jfif", "Cooper" },
                    { 24, "Kendrick Kang-Joh Jeong (Korean: 정강조; Hanja: 鄭康祖, /dʒɒŋ/; born July 13, 1969) is an American stand-up comedian, actor, producer, writer and licensed physician.[1][2] He rose to prominence for playing Leslie Chow in The Hangover film series (2009–2013) and Ben Chang in the NBC series Community (2009–2015). He created, wrote and produced the ABC sitcom Dr. Ken (2015–2017), in which he portrays the titular character, and he has appeared in the films Knocked Up (2007), Role Models (2008), Furry Vengeance (2010), The Duff (2015), Ride Along 2 (2016), Crazy Rich Asians (2018) and Tom & Jerry (2021).[3]", "1952-7-11", "Ken", 162, "qw55d54yDF.jfif", "Jeong" },
                    { 25, "Edward Parker Helms[1] (born January 24, 1974) is an American actor, comedian, singer, writer, and producer. From 2002 to 2006 he was a correspondent on Comedy Central's The Daily Show with Jon Stewart. He then played paper salesman Andy Bernard in the NBC sitcom The Office (2006–2013), and starred as Stuart Price in The Hangover trilogy. He currently stars in the comedy series Rutherford Falls (2021–present).", "1952-7-11", "Ed", 182, "qw00d54yDF.jfif", "Helms" },
                    { 26, "Justin Lee Bartha (born July 21, 1978) is an American actor, known for his roles as Riley Poole in the National Treasure film series, Doug Billings in The Hangover trilogy, and David Sawyer in the NBC comedy series The New Normal. He starred as Colin Morrello in the CBS All Access legal and political drama The Good Fight.", "1952-7-11", "Justin", 173, "qw11c5ryjF.jfif", "Bartha" },
                    { 27, "Samuel Leroy Jackson (born December 21, 1948) is an American actor. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time, only behind Stan Lee (who was most notable for his cameo appearances).[1][2][3]", "1952-7-11", "Samuel", 189, "qw789hrdjF.jfif", "L. Jackson" },
                    { 28, "Heather Joan Graham (born January 29, 1970[1]) is an American actress. After appearing in television commercials, her first starring role in a feature film came with the teen comedy License to Drive (1988), followed by the critically acclaimed film Drugstore Cowboy (1989).[2][3] She then played supporting roles on the television series Twin Peaks (1991), and in films such as Six Degrees of Separation (1993) and Swingers (1996). She gained critical praise for her role as \"Rollergirl\" in the film Boogie Nights (1997).[4] This led to major roles in the comedy films Bowfinger and Austin Powers: The Spy Who Shagged Me (both 1999).", "1952-7-11", "Heather", 173, "qw44chryjF.jfif", "Graham" },
                    { 29, "Walter Bruce Willis (born March 19, 1955) is a retired American actor. His career began on the off-Broadway stage in the 1970s.[1] He achieved fame with a leading role on the comedy-drama series Moonlighting (1985–1989) and appeared in over a hundred films, gaining recognition as an action hero after his portrayal of John McClane in the Die Hard franchise (1988–2013) and other roles.[2][3]", "1952-7-11", "Bruce", 183, "qw66cgr1jF.jfif", "Willis" },
                    { 30, "Willem James Dafoe (/dəˈfoʊ/;[1] born July 22, 1955) is an American actor. He is the recipient of various accolades, including the Volpi Cup for Best Actor, in addition to receiving nominations for four Academy Awards, four Screen Actors Guild Awards, three Golden Globe Awards, and a British Academy Film Award. He frequently collaborates with filmmakers Paul Schrader, Abel Ferrara, Lars von Trier, Julian Schnabel, and Wes Anderson.", "1952-7-11", "Willem", 175, "e4R5t6y7uI.jfif", "Dafoe" },
                    { 31, "James Francis Cameron CC (born August 16, 1954) is a Canadian filmmaker. Best known for making science fiction and epic films, he first gained recognition for directing The Terminator (1984). He found further success with Aliens (1986), The Abyss (1989), Terminator 2: Judgment Day (1991), and the action comedy True Lies (1994). He also directed Titanic (1997) and Avatar (2009), with Titanic earning him Academy Awards in Best Picture, Best Director and Best Film Editing. Avatar, filmed in 3D technology, earned him nominations in the same categories.", "1952-7-11", "James", 187, "q2Er1Xavt7.jfif", "Cameron" },
                    { 32, "Alejandro González Iñárritu (/ɪˈnjɑːrɪtuː/; American Spanish: [aleˈxandɾo ɣonˈsales iˈɲaritu]; credited since 2014 as Alejandro G. Iñárritu; born 15 August 1963) is a Mexican filmmaker and screenwriter. He is primarily known for making modern psychological drama films about the human condition. His projects have garnered critical acclaim and numerous accolades including eight Academy Awards with a Special Achievement Award, six Golden Globe Awards, eight British Academy Film Awards, two American Film Institute Awards, two Directors Guild of America Awards and a Producers Guild of America Award. His most notable films include Amores perros (2000), 21 Grams (2003), Babel (2006), Biutiful (2010), Birdman (2014), and The Revenant (2015).", "1952-7-11", "Alejandro", 184, "gheCBni7tP.jfif", "González Iñárritu" },
                    { 33, "Quentin Jerome Tarantino (/ˌtærənˈtiːnoʊ/; born March 27, 1963)[1] is an American filmmaker and actor. His films are characterized by frequent references to popular culture and film genres, nonlinear storylines, dark humor, stylized violence, extended dialogue, pervasive use of profanity, cameos and ensemble casts. Other directorial tropes that identify his style include the use of songs from the 1960s and 70s; fictional brand parodies; and imagery of women's bare feet.", "1952-7-11", "Quentin", 185, "12wsFGyU76.jfif", "Tarantino" },
                    { 34, "Christopher Nolan[1] CBE (/ˈnoʊlən/; born 30 July 1970) is a British-American film director, producer, and screenwriter. His films have grossed more than US$5 billion worldwide and have garnered 11 Academy Awards from 36 nominations.\r\n\r\nBorn and raised in London, Nolan developed an interest in filmmaking from a young age. After studying English literature at University College London, he made his feature debut with Following (1998). Nolan gained international recognition with his second film, Memento (2000), for which he was nominated for the Academy Award for Best Original Screenplay.", "1952-7-11", "Christopher", 181, "aSQwcGb538.jfif", "Nolan" },
                    { 35, "Todd Phillips (né Bunzl, born December 20, 1970)[1] is an American filmmaker and occasional actor. Phillips began his career in 1993 and directed films in the 2000s such as Road Trip, Old School, Starsky & Hutch, and School for Scoundrels. He came to wider prominence in the early 2010s for directing The Hangover film series. In 2019, he co-wrote and directed the psychological thriller film Joker, based on the DC Comics character of the same name, which premiered at the 76th Venice International Film Festival where it received the top prize, the Golden Lion. Joker went on to earn Phillips three Academy Award nominations for Best Picture, Best Director, and Best Adapted Screenplay, with his co-writer Scott Silver.", "1952-7-11", "Todd", 183, "Rt56YuiO98.jfif", "Phillips" },
                    { 36, "Mary Harron (born January 12, 1953)[1] is a Canadian filmmaker and screenwriter, and former entertainment critic. She gained recognition for her role in writing and directing several independent films, including I Shot Andy Warhol (1996), American Psycho (2000), and The Notorious Bettie Page (2005). She co-wrote American Psycho and The Notorious Bettie Page with Guinevere Turner.", "1952-7-11", "Mary", 167, "yui86PMvd2.jfif", "Harron" }
                });

            migrationBuilder.InsertData(
                table: "CountryMovies",
                columns: new[] { "CountryId", "MovieId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 3 },
                    { 1, 3, 5 },
                    { 1, 4, 7 },
                    { 1, 5, 8 },
                    { 1, 6, 10 },
                    { 1, 7, 11 },
                    { 2, 2, 4 },
                    { 2, 5, 9 },
                    { 3, 1, 2 },
                    { 3, 3, 6 }
                });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[,]
                {
                    { 1, 4, 19 },
                    { 2, 1, 1 },
                    { 2, 3, 12 },
                    { 4, 1, 4 },
                    { 5, 3, 15 },
                    { 5, 4, 20 },
                    { 5, 5, 29 },
                    { 5, 6, 34 },
                    { 6, 2, 9 },
                    { 6, 3, 17 },
                    { 6, 4, 26 },
                    { 6, 5, 31 },
                    { 6, 6, 39 },
                    { 7, 2, 6 },
                    { 8, 2, 7 },
                    { 8, 4, 22 },
                    { 8, 6, 33 },
                    { 8, 7, 40 },
                    { 9, 3, 14 },
                    { 9, 5, 32 },
                    { 10, 1, 2 },
                    { 12, 1, 3 },
                    { 12, 3, 16 },
                    { 12, 7, 41 },
                    { 14, 1, 5 },
                    { 14, 3, 18 },
                    { 14, 4, 25 },
                    { 17, 2, 10 },
                    { 17, 4, 24 },
                    { 17, 6, 37 },
                    { 23, 2, 8 }
                });

            migrationBuilder.InsertData(
                table: "GenreMovies",
                columns: new[] { "GenreId", "MovieId", "Id" },
                values: new object[,]
                {
                    { 23, 4, 21 },
                    { 24, 2, 11 },
                    { 24, 6, 38 },
                    { 25, 3, 13 },
                    { 26, 4, 23 },
                    { 26, 5, 30 },
                    { 27, 4, 27 },
                    { 28, 4, 28 },
                    { 28, 6, 35 },
                    { 29, 6, 36 }
                });

            migrationBuilder.InsertData(
                table: "PersonMovies",
                columns: new[] { "MovieId", "PersonId", "Id", "IsActor", "IsDirector" },
                values: new object[,]
                {
                    { 1, 1, 1, true, null },
                    { 1, 2, 2, true, null },
                    { 1, 3, 3, true, null },
                    { 1, 4, 4, true, null },
                    { 2, 5, 6, true, null },
                    { 2, 6, 7, true, null },
                    { 6, 7, 26, true, null },
                    { 2, 8, 8, true, null },
                    { 7, 8, 33, true, null },
                    { 2, 9, 9, true, null },
                    { 3, 10, 11, true, null },
                    { 3, 11, 12, true, null },
                    { 4, 11, 20, true, null },
                    { 3, 12, 13, true, null },
                    { 3, 13, 14, true, null },
                    { 3, 14, 15, true, null },
                    { 3, 15, 16, true, null },
                    { 5, 16, 22, true, null },
                    { 4, 17, 18, true, null },
                    { 4, 18, 19, true, null },
                    { 5, 19, 23, true, null },
                    { 6, 20, 27, true, null },
                    { 6, 21, 28, true, null },
                    { 6, 22, 31, true, null },
                    { 5, 23, 24, true, null },
                    { 7, 23, 34, true, null },
                    { 7, 24, 35, true, null },
                    { 7, 25, 36, true, null },
                    { 7, 26, 37, true, null },
                    { 6, 27, 29, true, null },
                    { 7, 28, 38, true, null },
                    { 6, 29, 30, true, null }
                });

            migrationBuilder.InsertData(
                table: "PersonMovies",
                columns: new[] { "MovieId", "PersonId", "Id", "IsActor", "IsDirector" },
                values: new object[,]
                {
                    { 1, 31, 5, null, true },
                    { 2, 32, 10, null, true },
                    { 6, 33, 32, null, true },
                    { 3, 34, 17, null, true },
                    { 5, 35, 25, null, true },
                    { 7, 35, 39, null, true },
                    { 4, 36, 21, null, true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CountryMovies_MovieId",
                table: "CountryMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMovies_MovieId",
                table: "GenreMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title_Year",
                table: "Movies",
                columns: new[] { "Title", "Year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_FirstName_LastName",
                table: "People",
                columns: new[] { "FirstName", "LastName" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PersonMovies_MovieId",
                table: "PersonMovies",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryMovies");

            migrationBuilder.DropTable(
                name: "GenreMovies");

            migrationBuilder.DropTable(
                name: "PersonMovies");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
